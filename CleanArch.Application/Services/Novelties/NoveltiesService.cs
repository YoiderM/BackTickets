using Application.Common.Response;
using Application.Cqrs.Novelties.Commands;
using Application.Cqrs.Novelties.Queries;
using Application.DTOs.Mekano;
using Application.DTOs.Novelties;
using Application.DTOs.Resources;
using Application.Interfaces.Novelties;
using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using Domain.Interfaces;
using Domain.Models.AdministrativeProcesses;
using Domain.Models.Mekano;
using Domain.Models.Novelties;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Novelties
{
    public class NoveltiesService : INoveltiesService
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private ICurrentUserService _currentUserService;
        private readonly IUnitOfWork _unitOfWork;

        public NoveltiesService(IMapper mapper, ILogger<NoveltiesService> logger, IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
        {
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;
            _currentUserService = currentUserService;
        }

        public async Task<ApiResponse<List<TB_ASISTENCIA_MARCADORESDto>>> GetUsers(GetUsersNoveltiesQuery request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<List<TB_ASISTENCIA_MARCADORESDto>>();
            try
            {
                var GetUsersAsist = new List<TB_ASISTENCIA_MARCADORESDto>();
                var timeDefault = new DateTime().ToString("yyyy-MM-dd");
                if (request.DateFilter.ToString("yyyy-MM-dd") != timeDefault)
                {
                    foreach (var item in request.init)
                    {
                        GetUsersAsist.AddRange(_mapper.Map<List<TB_ASISTENCIA_MARCADORESDto>>(await _unitOfWork.TB_ASISTENCIA_MARCADORESRepository.Get()
                                                                                                                                        .Where(x => x.ID_CENTRO_COSTO == request.CostCenterId && x.ASISTIO == item && x.FECHA.ToString() == request.DateFilter.ToString("yyyy-MM-dd"))
                                                                                                                                        .OrderBy(x => x.CENTRO_COSTO)
                                                                                                                                        .ToListAsync()));
                    }
                }
                else
                {
                    var date = DateTime.Now.ToString("yyyy-MM-dd");
                    foreach (var item in request.init)
                    {

                        GetUsersAsist.AddRange(_mapper.Map<List<TB_ASISTENCIA_MARCADORESDto>>(await _unitOfWork.TB_ASISTENCIA_MARCADORESRepository.Get()
                                                                                                                                        .Where(x => x.ID_CENTRO_COSTO == request.CostCenterId && x.ASISTIO == item && x.FECHA.ToString() == date)
                                                                                                                                        .OrderBy(x => x.CENTRO_COSTO)
                                                                                                                                        .ToListAsync()));
                    }
                }

                response.Data = GetUsersAsist;
                response.Result = true;
                response.Message = "Ok";
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al consultar el registro, NoveltiesService en el método Get, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al consultar el registro, consulte con el administrador. { ex.Message } ";
            }
            return response;
        }

        public async Task<ApiResponse<List<ConfigurationNoveltiesDto>>> GetConfigurationNovelties(int Without, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<List<ConfigurationNoveltiesDto>>();
            try
            {
                var getConfigurationNovelties = new List<ConfigurationNoveltiesDto>();
                switch (Without)
                {
                    case 1:
                        getConfigurationNovelties = _mapper.Map<List<ConfigurationNoveltiesDto>>(await _unitOfWork.ConfigurationNoveltiesRepository.Get().Where(x => x.Status == true && x.AnticipatedNovelty == true).ToListAsync());
                        break;
                    case 2:
                        getConfigurationNovelties = _mapper.Map<List<ConfigurationNoveltiesDto>>(await _unitOfWork.ConfigurationNoveltiesRepository.Get().Where(x => x.Status == true && x.Assistance == true).ToListAsync());
                        break;
                    case 3:
                        getConfigurationNovelties = _mapper.Map<List<ConfigurationNoveltiesDto>>(await _unitOfWork.ConfigurationNoveltiesRepository.Get().Where(x => x.Status == true && x.Approbation == true).ToListAsync());
                        break;
                }

                response.Data = getConfigurationNovelties;
                response.Result = true;
                response.Message = "Ok";
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al consultar el registro, NoveltiesService en el método Get, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al consultar el registro, consulte con el administrador. { ex.Message } ";
            }
            return response;
        }

        public async Task<ApiResponse<List<NoveltiesOrderByTypeNoveltyDto>>> GetAnticipatedNovelties(getAnticipatedNoveltiesQuery request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<List<NoveltiesOrderByTypeNoveltyDto>>();
            try
            {
                List<ConfigurationNovelties> configurationNovelties = new List<ConfigurationNovelties>();
                if (request.NoveltyInit != null)
                {
                    configurationNovelties = await _unitOfWork.ConfigurationNoveltiesRepository.Get().Where(x => x.Approbation == true && x.Initial == request.NoveltyInit).ToListAsync();
                }
                else
                {
                    configurationNovelties = await _unitOfWork.ConfigurationNoveltiesRepository.Get().Where(x => x.Approbation == true).ToListAsync();
                }

                List<NoveltiesOrderByTypeNoveltyDto> noveltiesOrderByTypeNoveltyDtos = new List<NoveltiesOrderByTypeNoveltyDto>();

                List<NoveltyEntryQueryDto> noveltyEntryQuery = new List<NoveltyEntryQueryDto>();

                foreach (var item in configurationNovelties)
                {
                    noveltyEntryQuery = _mapper.Map<List<NoveltyEntryQueryDto>>(await _unitOfWork.NoveltyEntryRepository.Get()
                                                                                                            .Where(x => x.ConfigurationNoveltiesId == item.Id && x.ProcessStatusId == request.statusNovelty)
                                                                                                            .OrderBy(x => x.CreatedAt)
                                                                                                            .Include(x => x.ProcessStatus)
                                                                                                            .Include(x => x.MekanoUser)
                                                                                                            .Include(x => x.ConfigurationNovelties)
                                                                                                            .ToListAsync());
                    foreach (var novelty in noveltyEntryQuery)
                    {
                        novelty.ResourcesDtos = _mapper.Map<List<ResourcesDto>>(await _unitOfWork.ResourcesRepository.Get().Where(x => x.NoveltyEntryId == novelty.Id).OrderBy(x => x.CreatedAt).ToListAsync());
                        novelty.NoveltyHistoryQueryDtos = _mapper.Map<List<NoveltyHistoryQueryDto>>(await _unitOfWork.NoveltyHistoryRepository.Get().Where(x => x.NoveltyEntryId == novelty.Id).Include(x => x.User).ToListAsync());
                    }

                    if (noveltyEntryQuery.Count > 0)
                    {
                        noveltiesOrderByTypeNoveltyDtos.Add(new NoveltiesOrderByTypeNoveltyDto()
                        {
                            TypeNovelty = item.Name,
                            noveltyEntryQueryDtos = _mapper.Map<List<NoveltyEntryQueryDto>>(noveltyEntryQuery),

                        });
                    }

                    response.Data = noveltiesOrderByTypeNoveltyDtos;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al consultar el registro, NoveltiesService en el método Get, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al consultar el registro, consulte con el administrador. { ex.Message } ";
            }
            return response;
        }

        public async Task<ApiResponse<TB_ASISTENCIA_MARCADORESDto>> PutStatusNoveltyPerson(PutStatusNoveltyPersonCommand request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<TB_ASISTENCIA_MARCADORESDto>();
            try
            {
                var configurationNovelty = await _unitOfWork.ConfigurationNoveltiesRepository.GetById(request.ConfigurationNoveltyId);

                if (configurationNovelty.Assistance == true)
                {
                    TB_ASISTENCIA_MARCADORES user = await _unitOfWork.TB_ASISTENCIA_MARCADORESRepository.GetById(request.TB_ASISTENCIA_MARCADORESId);
                    user.ASISTIO = configurationNovelty.Initial;
                    if (request.Description != null)
                    {
                        user.DESCRIPCION = request.Description;
                    }
                    if (request.DateStartTime != null)
                    {
                        user.HORA_INICIO_TURNO = request.DateStartTime;
                    }
                    response.Data = _mapper.Map<TB_ASISTENCIA_MARCADORESDto>(await _unitOfWork.TB_ASISTENCIA_MARCADORESRepository.Put(user));
                }
                else
                {
                    throw new Exception("no se puede modificar el estado de la persona gracias a que no es un estado de asistencia");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al consultar el registro, NoveltiesService en el método Get, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al consultar el registro, consulte con el administrador. { ex.Message } ";
            }
            return response;
        }

        public async Task<ApiResponse<List<MekanoUserDto>>> GetMekanoUsers(int ConstCenterId, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<List<MekanoUserDto>>();
            try
            {
                response.Data = _mapper.Map<List<MekanoUserDto>>(await _unitOfWork.MekanoUserRepository.Get()
                                                                                                        .Where(x => x.Active == true && x.CostCenterId == ConstCenterId)
                                                                                                        .Include(x => x.CostCenter)
                                                                                                        .ToListAsync());

                response.Result = true;
                response.Message = "Ok";
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al consultar el registro, NoveltiesService en el método Get, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al consultar el registro, consulte con el administrador. { ex.Message } ";
            }
            return response;
        }

        public async Task<ApiResponse<List<NoveltyEntryQueryDto>>> getAnticipatedNoveltiesQuery(getNoveltiesQuery request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<List<NoveltyEntryQueryDto>>();
            try
            {
                response.Data = _mapper.Map<List<NoveltyEntryQueryDto>>(await _unitOfWork.NoveltyEntryRepository.Get()
                                                                                                                .Where(x => x.ConfigurationNovelties.Approbation == true && x.ConfigurationNoveltiesId == request.configurationNoveltyId)
                                                                                                                .Include(x => x.ConfigurationNovelties)
                                                                                                                .Include(x => x.ProcessStatus)
                                                                                                                .Include(x => x.MekanoUser)
                                                                                                                .OrderBy(x => x.CreatedAt)
                                                                                                                .ToListAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al consultar el registro, NoveltiesService en el método Get, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al consultar el registro, consulte con el administrador. { ex.Message } ";
            }
            return response;
        }

        public async Task<ApiResponse<NoveltyEntryDto>> PostAnticipatedNovelties(PostAnticipatedNoveltyCommand request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<NoveltyEntryDto>();
            try
            {
                //obtain mekano user data with the document for know the mekanoUserId
                MekanoUser mekanoUser = await _unitOfWork.MekanoUserRepository.GetById(request.novelty.MekanoUserId);

                //get the last record for a user in AsistenciaMarcadores(Table) with the document
                var date = DateTime.Now.ToString("yyyy-MM-dd");
                TB_ASISTENCIA_MARCADORES tB_ASISTENCIA_MARCADORES = await _unitOfWork.TB_ASISTENCIA_MARCADORESRepository.Get().Where(x => x.DOCUMENTO == mekanoUser.Document && x.FECHA.ToString() == date).FirstOrDefaultAsync();

                //fill in the data to request.novelty(is the DTO to NoveltyEntry)
                NoveltyEntryDto noveltyEntryDto = new NoveltyEntryDto();
                noveltyEntryDto = _mapper.Map<NoveltyEntryDto>(request.novelty);

                //it does the post in db when all the content necesary is obtained
                response.Data = _mapper.Map<NoveltyEntryDto>(await _unitOfWork.NoveltyEntryRepository.Add(_mapper.Map<NoveltyEntry>(noveltyEntryDto)));

                //fill the data to anticipatedNovelty for return a response
                AnticipatedNoveltyDto anticipateNovelty = new AnticipatedNoveltyDto();
                anticipateNovelty.NoveltyEntryId = response.Data.Id;

                var res = await _unitOfWork.ConfigurationNoveltiesRepository.GetById(response.Data.ConfigurationNoveltiesId);
                anticipateNovelty.NoveltyInit = res.Initial;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al consultar el registro, NoveltiesService en el método Get, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al consultar el registro, consulte con el administrador. { ex.Message } ";
            }
            return response;
        }

        public async Task<ApiResponse<NoveltyEntryDto>> PutStatusAprobationNovelty(PutAnticipatedNoveltyCommand request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<NoveltyEntryDto>();
            try
            {
                //get the novelty for change it 
                NoveltyEntry novelty = await _unitOfWork.NoveltyEntryRepository.GetById(request.IdNovelty);


                //============create a register to noveltyHistory======================//
                NoveltyHistoryDto noveltyHistoryDto = new NoveltyHistoryDto();
                //date
                noveltyHistoryDto.date = DateTime.Now;
                //InitialState
                ProcessStatus processStatus = new ProcessStatus();
                processStatus = await _unitOfWork.ProcessStatusRepository.GetById(novelty.ProcessStatusId);
                noveltyHistoryDto.InitialState = processStatus.NameStatus;
                //endState
                processStatus = await _unitOfWork.ProcessStatusRepository.GetById(request.ProcessStatusId);
                noveltyHistoryDto.EndState = processStatus.NameStatus;
                //observation
                noveltyHistoryDto.Observation = request.Observation;
                //MadeByUserId
                var userInfo = _currentUserService.GetUserInfo();
                var id = _mapper.Map<Guid>(userInfo.Id);
                noveltyHistoryDto.MadeByUserId = id;
                //noveltyEntryId
                noveltyHistoryDto.NoveltyEntryId = request.IdNovelty;
                await _unitOfWork.NoveltyHistoryRepository.Add(_mapper.Map<NoveltyHistory>(noveltyHistoryDto));
                //======================================================================//

                novelty.ProcessStatusId = request.ProcessStatusId;
                await _unitOfWork.NoveltyEntryRepository.Put(novelty);
                response.Data = _mapper.Map<NoveltyEntryDto>(await _unitOfWork.NoveltyEntryRepository.GetById(novelty.Id));

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al consultar el registro, NoveltiesService en el método Get, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al consultar el registro, consulte con el administrador. { ex.Message } ";
            }
            return response;
        }


    }
}