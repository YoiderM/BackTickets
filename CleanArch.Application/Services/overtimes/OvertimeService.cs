using Application.AutoMapper.Resolver;
using Application.Common.Interfaces;
using Application.Common.Response;
using Application.Core.Exceptions;
using Application.Cqrs.OvertimePeriodDetail.Commands;
using Application.Cqrs.OvertimePeriodDetail.Queries;
using Application.DTOs.OvertimePeriods;
using Application.Interfaces.Mekano;
using Application.Interfaces.Overtimes;
using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using Domain.Interfaces;
using Domain.Models.Overtimes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Overtimes
{
    public class OvertimeService : IOvertimeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private Guid _userId;
        private string _createdUpdateByName;
        private readonly ICurrentUserService _currentUserService;
        private IResponsabilityCostCenterService _responsabilityCostCenterService;
        private IBulkInsert _bulkInsert;
        private IOvertimeTypeService _overtimeTypeService;
        private IOvertimeTempService _overtimeTempService;
        private readonly IOvertimePeriodService _overtimePeriodService;

        public OvertimeService(IUnitOfWork unitOfWork,
            IMapper mapper,
            ICurrentUserService currentUserService,
            ILogger<OvertimeService> logger,
            IResponsabilityCostCenterService responsabilityCostCenterService,
            IBulkInsert bulkInsert,
            IOvertimeTempService overtimeTempService,
            IOvertimeTypeService overtimeTypeService,
            IOvertimePeriodService overtimePeriodService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _currentUserService = currentUserService;
            _responsabilityCostCenterService = responsabilityCostCenterService;
            _bulkInsert = bulkInsert;
            _overtimeTempService = overtimeTempService;
            _overtimeTypeService = overtimeTypeService;
            _overtimePeriodService = overtimePeriodService;
            _userId = (Guid)_currentUserService.GetUserInfo().Id;
            _createdUpdateByName = _currentUserService.GetUserInfo().Name;
            //_userId = new Guid("30A09E86-2631-488E-8350-C5BECF55392E");
        }
        public async Task<List<OvertimeDetail>> Get(GetOvertimesQuery request, CancellationToken cancellationToken)
        {
            var overtimes = _unitOfWork.overtimeDetail.Get();
            if (request.PeriodId != null)
                overtimes = overtimes.Where(x => x.OvertimePeriodId == request.PeriodId);

           

            return await overtimes.ToListAsync(cancellationToken);
        }

        public async Task<List<OvertimeDetail>> GetByPeriodId(int id, CancellationToken cancellationToken)
        {
            return await _unitOfWork
                .overtimeDetail
                .Get()
                .Where(x => x.OvertimePeriodId == id)
                .ToListAsync(cancellationToken);
        }

        public async Task<ApiResponse<OvertimeDetailDto>> GetOvertimeDetailById(Guid id, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<OvertimeDetailDto>();

            try
            {
                response.Data = _mapper.Map<OvertimeDetailDto>(await _unitOfWork.overtimeDetail
                                       .Get()
                                       .Include(x => x.CostCenter)
                                       .Include(x => x.OvertimePeriod)
                                       .Include(x => x.OvertimeType)
                                       .Where(x => x.Id == id)
                                       .FirstOrDefaultAsync());
            
                response.Result = true;
                response.Message = "OK";
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al consultar el registro, servicio OvertimeService en el método GetOvertimeDetailById. { ex.Message }");
                response.Result = false;
                response.Message = $"Error al consultar el registro, consulte con el administrador. { ex.Message }";
            }

            return response;
        }

        public async Task<List<OvertimeDetail>> GetByPeriodAndUserId(int PeriodId, Guid UserId, CancellationToken cancellationToken)
        {
            return await _unitOfWork
                .overtimeDetail
                .Get()
                .Where(x => x.OvertimePeriodId == PeriodId && x.CreatedBy == UserId)
                .ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Metodo muestra la lista con el detalle de horas extras no aprobadas
        /// </summary>
        /// <param name="periodId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ApiResponse<List<OvertimeDetailDto>>> GetOvertimesDetailPendingApproval(int periodId, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<List<OvertimeDetailDto>>();
            var exists = await checkByPeriodExists(periodId);

            try
            {
                if(exists)
                {
                    var source = await _unitOfWork.overtimeDetail.Get()
                                                                 .Where(x => x.OvertimePeriodId == periodId && x.Aproved == false)
                                                                 .ToListAsync(cancellationToken);

                    response.Data = _mapper.Map<List<OvertimeDetailDto>>(source);
                    response.Result = true;
                    response.Message = "OK";
                }
                else
                {
                    throw new BadRequestException("El periodo ingresado no existe.");
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al consultar los registros, Overtimeservice en el método GetOvertimesDetailPendingApproval, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al consultar los registros, consulte con el administrador. { ex.Message } ";

            }

            return response;
        }

        public async Task<bool> checkByPeriodExists(int Id)
        {
            return await _unitOfWork.overtimeDetail.Get()
                                                   .Where(x => x.OvertimePeriodId == Id && x.Aproved==false)
                                                   .CountAsync() > 0 ? true : false;

        }

        public async Task<ApiResponse<OvertimeDetailDto>> PostDetail(PostOvertimeCommand request)
        {
            var response = new ApiResponse<OvertimeDetailDto>();
            try
            {
                #region Validando Modelo
                var validate_1 = await CheckValideRangeDay((DateTime)request.OvertimeDay, request.OvertimePeriodId);

                if (validate_1.Item1)
                    throw new BadRequestException($"{ validate_1.Item2 }");

                var validate_2 = await CheckValideRangeDayCurrent(DateTime.Now, request.OvertimePeriodId);
                if (validate_2.Item1)
                    throw new BadRequestException($"{ validate_2.Item2 }");
                #endregion

                var errors = await ValidatePostOvertimeDetail(request);

                if (errors.Count() > 0)
                {
                    var messageError = string.Empty;
                    foreach (var error in errors)
                    {
                        messageError += string.Join("", $"{ error.Error }\n");
                    }

                    response.Result = false;
                    response.Message = messageError;

                }
                else
                {
                    response.Data = _mapper.Map<OvertimeDetailDto>(await _unitOfWork.overtimeDetail
                                           .Add(_mapper.Map<OvertimeDetail>(request)));
                    response.Result = true;
                    response.Message = "OK";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear el registro, Overtimeservice en el método PostOvertime, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al crear el registro, consulte con el administrador. { ex.Message } ";
            }
            return response;
        }

        public async Task<List<OvertimeTempErrors>> ValidatePostOvertimeDetail(PostOvertimeCommand request)
        {
            //se cargan los registros de la tabla temporal
            var overtimeTemps = await _overtimeTempService.GetOvertimesTempByUserId(_userId);

            //elimina los registros del usuario de sesion
            if (overtimeTemps.Count() > 0) await _overtimeTempService.DeleteRangeOvertimeTemp(overtimeTemps);

            //lleno la data para insertar en la tabla temporal
            var overtimeTemp = new OvertimeTemp()
            {
                Id = Guid.NewGuid(),
                CompensatoryApplies = request.CompensatoryApplies,
                CompensatoryAppliesText = request.CompensatoryApplies == true ? "SI" : "NO",
                CostCenterId = request.CostCenterId,
                CostCenterName = string.Empty,
                Document = request.Document,
                EndHour = request.EndHour,
                InitialHour = request.InitialHour,
                JobName = request.JobName,
                Login = request.Login,
                LoginTime = request.LoginTime,
                LoginTimeText = string.Empty,
                Names = request.Names,
                Observation = request.Observation,
                OvertimeDay = request.OvertimeDay,
                OvertimePeriodId = request.OvertimePeriodId,
                OvertimeTypeName = await _overtimeTypeService.GetOvertimeTypeNameById(request.OvertimeTypeId),
                CreatedBy = _userId

            };

            //guardo los registros
            await _overtimeTempService.AddOvertimeTemp(overtimeTemp);

            //retorno los errores

            return await _overtimeTempService.GetOvertimesTempErrorsByUserId(_userId);

        }

        public async Task<ApiResponse<Object>> PutOvertimeDetail(PutOvertimeCommand request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<Object>();

            var source = await _unitOfWork.overtimeDetail.GetById(request.Id) ?? throw new NotFoundException("Id", request.Id);

            try
            {
                var errors = await ValidateOvertimeDetail(request);

                if (errors.Count() > 0)
                {
                    var messageError = string.Empty;
                    foreach (var error in errors)
                    {
                        messageError += string.Join("", $"{ error.Error }\n");
                    }
                   
                    response.Result = false;
                    response.Message = messageError;
                   
                }
                else
                {
                 
                    source.UpdatedBy = _userId;
                    //source.AprovedBy = _userId;
                    source.UpdatedByName = _createdUpdateByName;

                    var overtimeDetail = _mapper.Map<PutOvertimeCommand, OvertimeDetail>(request, source);

                    response.Data = _mapper.Map<OvertimeDetailDto>(await _unitOfWork.overtimeDetail.Put(overtimeDetail));
                    response.Result = true;
                    response.Message = "OK";
                }
                         
            }
            catch (Exception ex)
            {          
                _logger.LogError($"Error al actualizar el registro, Overtimeservice en el método PutOvertimeDetail, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al actualizar el registro, consulte con el administrador. { ex.Message } ";
            }

            return response;
        }

        /// <summary>
        /// Método que se encarga de validar los datos ingresados, ejecutando un procedimiento almacenado
        /// y retornando los posibles errores encontrados.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<List<OvertimeTempErrors>> ValidateOvertimeDetail(PutOvertimeCommand request)
        {

            var overtimeTemps = await _overtimeTempService.GetOvertimesTempByUserId(_userId);

            if (overtimeTemps.Count() > 0) await _overtimeTempService.DeleteRangeOvertimeTemp(overtimeTemps);

            var overtimeTemp = new OvertimeTemp()
            {
                Id = Guid.NewGuid(),
                CompensatoryApplies = request.CompensatoryApplies,
                CompensatoryAppliesText = request.CompensatoryApplies == true ? "SI" : "NO",
                CostCenterId = request.CostCenterId,
                CostCenterName = string.Empty,
                Document = request.Document,
                EndHour = request.EndHour,
                InitialHour = request.InitialHour,
                JobName = request.JobName,
                Login = request.Login,
                LoginTime = request.LoginTime,
                LoginTimeText = string.Empty,
                Names = request.Names,
                Observation = request.Observation,
                OvertimeDay = request.OvertimeDay,
                OvertimePeriodId = request.OvertimePeriodId,
                OvertimeTypeName = await _overtimeTypeService.GetOvertimeTypeNameById(request.OvertimeTypeId),
                CreatedBy = _userId

            };

            await _overtimeTempService.AddOvertimeTemp(overtimeTemp);

            return await _overtimeTempService.GetOvertimesTempErrorsByUserId(_userId);

        }

        public async Task<ApiResponse<bool>> DeleteDetail(Guid id)
        {
            var response = new ApiResponse<bool>();

            var detail = await GetOvertimeDetailById(id) ?? throw new NotFoundException("El registro a procesar no existe");

            try
            {
                response.Data = _mapper.Map<bool>(await _unitOfWork.overtimeDetail
                                       .Delete(_mapper.Map<OvertimeDetail>(await GetOvertimeDetailById(detail.Id))));
                response.Message = "OK";
                response.Result = true;
                _logger.LogWarning($"Registro eliminado por: { _createdUpdateByName } con Id { _userId }");

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar el registro, OvertimeService en el método DeleteDetail, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al eliminar el registro, consulte con el administrador  { ex.Message } ";
            }

            return response;
        }

        private async Task<OvertimeDetail> GetOvertimeDetailById(Guid id)
        {
            return await _unitOfWork.overtimeDetail.GetById(id) ?? throw new NotFoundException("La entidad a procesar no existe");
        }

        /// <summary>
        /// Método para validar que la fecha de hora extra se encuentre entre los rangos de fecha permitidos por el periodo.
        /// </summary>
        /// <param name="overtimeDay"></param>
        /// <param name="periodId"></param>
        /// <returns></returns>
        public async Task<Tuple<bool, string>> CheckValideRangeDay(DateTime overtimeDay, int periodId)
        {
            var source = _unitOfWork.overtimePeriod.Get().Where(x => x.Id == periodId);

            var startPeriodDate = await source.Select(x => x.StartPeriodDate).FirstOrDefaultAsync();
            var endPeriodDate = await source.Select(x => x.EndPeriodDate).FirstOrDefaultAsync();

            var response = new Tuple<bool, string>(await source
                                .Where(x => overtimeDay < x.StartPeriodDate || overtimeDay > x.EndPeriodDate)
                                .CountAsync() > 0 ? true : false,
                                $"La fecha de hora extra { DatetimeFormatResolver.YearMonthDay(overtimeDay) }" +
                                $" debe estar entre el rango { DatetimeFormatResolver.YearMonthDay(startPeriodDate) } " +
                                $"y { DatetimeFormatResolver.YearMonthDay(endPeriodDate) }");

            return response;
        }

        /// <summary>
        /// Método para validar si la fecha actual para registrar el periodo se encuentra entre la fecha inicial permitida 
        /// y la fecha final permitida.
        /// </summary>
        /// <param name="dateCurrent"></param>
        /// <param name="periodId"></param>
        /// <returns></returns>
        public async Task<Tuple<bool, string>> CheckValideRangeDayCurrent(DateTime dateCurrent, int periodId)
        {
            var source = _unitOfWork.overtimePeriod.Get().Where(x => x.Id == periodId);
            var datec = DatetimeFormatResolver.YearMonthDay(dateCurrent);

            var startAllowedDate = await source.Select(x => x.StartAllowedDate).FirstOrDefaultAsync();
            var endAllowedDate = await source.Select(x => x.EndAllowedDate).FirstOrDefaultAsync();

            var response = new Tuple<bool, string>(await source
                                .Where(x => DateTime.Parse(datec) < x.StartAllowedDate || DateTime.Parse(datec) > x.EndAllowedDate)
                                .CountAsync() > 0 ? true : false,
                                $"La fecha actual { DatetimeFormatResolver.YearMonthDay(dateCurrent) }" +
                                $" debe estar entre el rango permitido { DatetimeFormatResolver.YearMonthDay(startAllowedDate) } " +
                                $"y { DatetimeFormatResolver.YearMonthDay(endAllowedDate) }");

            return response;

        }

        /// <summary>
        /// Método para aprobar horas extras de forma masiva.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ApiResponse<bool>> PutRangeOvertimeDetailCommand(PutRangeOvertimeDetailCommand request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<bool>();

            try
            {
                foreach (var item in request.OvertimeDetailsId)
                {
                    var overtimeDetail = await _unitOfWork.overtimeDetail.Get()
                                                                         .Where(x => x.Id == item)
                                                                         .FirstOrDefaultAsync() ?? throw new NotFoundException("Id", item);

                    overtimeDetail.Aproved = true;
                    overtimeDetail.UpdatedBy = _userId;
                    overtimeDetail.AprovedBy = _userId;
                    overtimeDetail.UpdatedByName = _createdUpdateByName;
                    await _unitOfWork.overtimeDetail.Put(overtimeDetail);

                }

                response.Data = true;
                response.Result = true;
                response.Message = "OK";
            }
            catch (Exception ex)
            {

                _logger.LogError($"Error al aprobar los registros, OvertimeService en el método PutRangeOvertimeDetailCommand, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al aprobar los registros, consulte con el administrador  { ex.Message } ";
            }

            return response;
        }

    }
}
