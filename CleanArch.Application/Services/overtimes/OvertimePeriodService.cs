using Application.Common.Mappings;
using Application.Common.Response;
using Application.Core.Exceptions;
using Application.Cqrs.OvertimePeriods.Commands;
using Application.Cqrs.OvertimePeriods.Queries;
using Application.Cqrs.OvertimePeriods.Queries.GetPeriods;
using Application.DTOs.OvertimePeriods;
using Application.Interfaces.Overtimes;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using Domain.CustomEntities;
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
    public class OvertimePeriodService : IOvertimePeriodService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private ICurrentUserService _currentUserService;
        private string _createdUpdateByName;
        private Guid _userId;

        public OvertimePeriodService(IUnitOfWork unitOfWork, IMapper mapper,ILogger<OvertimePeriodService> logger,ICurrentUserService currentUserService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _currentUserService = currentUserService;
            //_userId = new Guid("30A09E86-2631-488E-8350-C5BECF55392E");
            _userId = (Guid)_currentUserService.GetUserInfo().Id;
            _createdUpdateByName = _currentUserService.GetUserInfo().Name;


        }

        public async Task<PaginatedList<OvertimePeriodDto>> GetPeriods(GetOvertimePeriodQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.overtimePeriod.Get()
                                                   .ProjectTo<OvertimePeriodDto>(_mapper.ConfigurationProvider)
                                                   .OrderByDescending(x => x.Id)
                                                   .PaginatedListAsync(request.PageNumber, request.PageSize);
       
        }

        public async Task<PaginatedList<OvertimePeriodDto>> GetPeriodsIsPaid(GetOvertimePeriodIspaidQuery request, CancellationToken cancellationToken)
        {                
            return await _unitOfWork.overtimePeriod.Get()
                                                   .ProjectTo<OvertimePeriodDto>(_mapper.ConfigurationProvider)
                                                   .Where(x => x.IsPaid == true)                                            
                                                   .OrderByDescending(x => x.CreatedAt)
                                                   .PaginatedListAsync(request.PageNumber, request.PageSize);
                                                          
        }

        public async Task<PaginatedList<OvertimePeriodDto>> GetPeriodsIsNotPaid(GetOvertimePeriodIsNotPaidQuery request, CancellationToken cancellationToken)
        {  
            return await _unitOfWork.overtimePeriod.Get().Where(x => x.IsPaid == false)
                                                   .ProjectTo<OvertimePeriodDto>(_mapper.ConfigurationProvider)
                                                   .OrderByDescending(x => x.CreatedAt)
                                                   .PaginatedListAsync(request.PageNumber, request.PageSize);
              
        }



        //public async Task<ApiResponse<OvertimePeriod>> PostPeriod(OvertimePeriod overtimePeriod ,CancellationToken cancellationToken)
        //{
        //    var response = new ApiResponse<OvertimePeriod>();

        //    try
        //    {
        //        response.Data =  await _unitOfWork.overtimePeriod.Add(overtimePeriod);
        //        response.Result = true;
        //        response.Message = "OK";

        //    }
        //    catch (Exception ex)
        //    {

        //        _logger.LogError($"Error al actualizar el egistro, OvertimeperiodService en el método PostPeriod, { ex.Message } ");
        //        response.Result = false;
        //        response.Message = $"Error al actualizar el registro, consulte con el administrador. { ex.Message } ";
        //    }

        //    return response;

        //}

        public async Task<ApiResponse<OvertimePeriodDto>> PostPeriod(CreateOvertimePeriodcommand request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<OvertimePeriodDto>();

            try
            {
                var source = _mapper.Map<OvertimePeriodDto>(await _unitOfWork.overtimePeriod.Add(_mapper.Map<OvertimePeriod>(request)));
                
                response.Data = source;                
                response.Result = true;
                response.Message = "OK";
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar el egistro, OvertimeperiodService en el método PostPeriod, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al actualizar el registro, consulte con el administrador. { ex.Message } ";
            }

            return response;
        }

        public async Task<ApiResponse<OvertimePeriodDto>> GetPeriodById(int Id)
        {
            var response = new ApiResponse<OvertimePeriodDto>();

            try
            {       
                response.Data = _mapper.Map < OvertimePeriodDto> (await _unitOfWork.overtimePeriod
                                            .Get()
                                            .FirstOrDefaultAsync(x => x.Id == Id));
              
                response.Result = true;
                response.Message = "OK";

            }
            catch (Exception ex)
            {
               _logger.LogError($"Error al consultar el registro, OvertimeperiodService en el método GetPeriodById, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al consultar el registro, consulte con el administrador. { ex.Message } ";
            }

            return response;

        }

        public async Task<OvertimePeriod> GetById(int Id)
        {


                return await _unitOfWork.overtimePeriod
                                            .Get()
                                            .FirstOrDefaultAsync(x => x.Id == Id);

        }

        
        public async Task<bool> checkById(int Id)
        {
            return await _unitOfWork.overtimePeriod
                .Get()
                .CountAsync(x => x.Id == Id) == 0 ? 
                false : true;

        }

        public async Task<ApiResponse<OvertimePeriodDto>> PutPeriod(UpdateOvertimePeriodCommand request)
        {
            var response = new ApiResponse<OvertimePeriodDto>();

            try
            {
                OvertimePeriod overtimePeriod = await GetById(request.Id) ?? throw new NotFoundException("The overtime is not found");
                overtimePeriod = _mapper.Map(request, overtimePeriod);
                overtimePeriod.UpdatedBy = (Guid)_currentUserService.GetUserInfo().Id;
         
                response.Data= _mapper.Map<OvertimePeriodDto>(await _unitOfWork.overtimePeriod.Put(overtimePeriod));
                response.Result = true;
                response.Message = "OK";
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar el egistro, OvertimeperiodService en el método PutPeriod, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al actualizar el registro, consulte con el administrador. { ex.Message } ";
            }

            return response;
        }

        /// <summary>
        /// Eliminar un periodo siempre y cuando este abieto y no este pagado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ApiResponse<bool>> DeletePeriod(int id)
        {
            var response = new ApiResponse<bool>();
           
            try
            {
                var exists = await checkById(id);

                if(exists)
                {
                    var period = await _unitOfWork.overtimePeriod.Get()
                                                       .Where(x => x.Id == id && x.IsPaid == false)
                                                       .CountAsync() > 0 ? true : throw new NotFoundException("El periodo a eliminar ya se encuentra pagado");
                    if (period)
                    {
                        //eliminar registros
                        await DeleteRangeByperiod(id);

                        response.Data = _mapper.Map<bool>(await _unitOfWork.overtimePeriod
                                               .Delete(await GetOvertimePeriodById(id)));

                        response.Message = "OK";
                        response.Result = true;
                        _logger.LogWarning($"Registro eliminado por: { _createdUpdateByName } con Id { _userId }");
                    }
                    else
                        throw new NotFoundException("El periodo a eliminar ya está cerrado");
                }
                else
                    throw new NotFoundException("El periodo a eliminar no existe");  
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar el registro, OvertimeService en el método DeleteDetail, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al eliminar el registro, consulte con el administrador  { ex.Message } ";
            }

            return response;
        }

        private async Task<OvertimePeriod> GetOvertimePeriodById(int id)
        {
            return await _unitOfWork.overtimePeriod.GetById(id) ?? throw new NotFoundException("La entidad a procesar no existe");
        }

        public async Task<bool> DeleteRangeByperiod(int id)
        {
            var details = _unitOfWork.overtimeDetail.Get()
                                                    .Where(x => x.OvertimePeriodId == id).ToList();

            if (details.Count > 0)
            {
                foreach (var item in details)
                {
                    await _unitOfWork.overtimeDetail.Delete(item);
                }              
            }

            return true;
        }
    }
}
