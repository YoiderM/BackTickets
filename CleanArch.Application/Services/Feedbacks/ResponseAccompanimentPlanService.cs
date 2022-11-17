using Application.Common.Response;
using Application.Core.Exceptions;
using Application.Cqrs.Feedbacks.ResponseAccompanimentPlan.Commands;
using Application.Cqrs.Feedbacks.ResponseAccompanimentPlan.Queries;
using Application.DTOs.Feedbacks;
using Application.Interfaces.Feedbacks;
using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using Domain.Interfaces;
using Domain.Models.Feedbacks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Feedbacks
{
    public class ResponseAccompanimentPlanService : IResponseAccompanimentPlanService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private ICurrentUserService _currentUserService;
        private string _createUpdateByName;
        public ResponseAccompanimentPlanService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ILogger<ResponseAccompanimentPlanService> logger,
            ICurrentUserService currentUserService
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _currentUserService = currentUserService;
            _createUpdateByName = _currentUserService.GetUserInfo().Name;
        }
        public async Task<List<ResponseAccompanimentPlanQuestionDto>> GetResponseAccompanimentPlans(GetResponseAccompanimentPlanQuery request, CancellationToken cancellationToken)
        {
            var userInfo = _currentUserService.GetUserInfo();
            List<int> costCentersUser = await _unitOfWork.responsabilityCostCenter.Get().Where(x => x.UserId == userInfo.Id).Select(x => x.CostCenterId).ToListAsync();
            var responseAccompanimentPlanOkDtos = _mapper.Map<List<ResponseAccompanimentPlanDto>>(await _unitOfWork.ResponseAccompanimentPlanRepository
                                                                    .Get()
                                                                    .Where(x => x.StatusId == new Guid("2E1B43C2-A43B-4ACA-9E0F-C4288F2C983C") && x.TypeAccompanimentPlanId == 7 && costCentersUser.Contains(x.AccompanimentPlan.CostCenterId))
                                                                    .Include(x => x.AccompanimentPlan)
                                                                    .Include(x => x.TypeAccompanimentPlan)
                                                                    .Include(x => x.AccompanimentPlan.Status)
                                                                    .OrderBy(x => x.CreatedAt)
                                                                    .ToListAsync());
            var responseAccompanimentPlanDtos = _mapper.Map<List<ResponseAccompanimentPlanDto>>(await _unitOfWork.ResponseAccompanimentPlanRepository
                                                                    .Get()
                                                                    .Where(x => x.FinalDate == null && costCentersUser.Contains(x.AccompanimentPlan.CostCenterId))
                                                                    .Include(x => x.AccompanimentPlan)
                                                                    .Include(x => x.TypeAccompanimentPlan)
                                                                    .Include(x => x.AccompanimentPlan.Status)
                                                                    .OrderBy(x => x.CreatedAt)
                                                                    .ToListAsync()).Union(responseAccompanimentPlanOkDtos);
            List<ResponseAccompanimentPlanQuestionDto> responseAccompanimentPlanQuestionDtos = new List<ResponseAccompanimentPlanQuestionDto>();
            foreach (var responseAccompanimentPlanDto in responseAccompanimentPlanDtos)
            {
                responseAccompanimentPlanQuestionDtos.Add(new ResponseAccompanimentPlanQuestionDto()
                {
                    responseAccompanimentPlan = responseAccompanimentPlanDto

                });
            }
            return responseAccompanimentPlanQuestionDtos;

        }
        public async Task<ApiResponse<List<ResponseAccompanimentPlanDto>>> GetByTypeAccompanimentPlanResponseAccompanimentPlan(GetByTypeAccompanimentPlanResponseAccompanimentPlanQuery request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<List<ResponseAccompanimentPlanDto>>();
            try
            {
                var userInfo = _currentUserService.GetUserInfo();
                List<int> costCentersUser = await _unitOfWork.responsabilityCostCenter.Get().Where(x => x.UserId == userInfo.Id).Select(x => x.CostCenterId).ToListAsync();

                response.Data = _mapper.Map<List<ResponseAccompanimentPlanDto>>(await _unitOfWork.ResponseAccompanimentPlanRepository
                                                                    .Get()
                                                                    .Include(x => x.AccompanimentPlan)
                                                                    .Include(x => x.Status)
                                                                    .Include(x => x.TypeAccompanimentPlan)
                                                                    .Where(x => x.TypeAccompanimentPlanId == request.TypeAccompanimentPlanId && costCentersUser.Contains(x.AccompanimentPlan.CostCenterId))
                                                                    .OrderBy(x => x.CreatedAt)
                                                                    .ToListAsync());
                response.Result = true;
                response.Message = "Ok";
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al consultar el registro, ResponseAccompanimentPlan en el método GetByTypeAccompanimentPlanResponseAccompanimentPlan, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al consultar el registro, consulte con el administrador. { ex.Message } ";
            }
            return response;
        }
        public async Task<List<ResponseAccompanimentPlanReportDto>> GetByAccompanimentPlanIdResponseAccompanimentPlan(GetByAccompanimentPlanIdResponseAccompanimentPlanQuery request, CancellationToken cancellationToken)
        {
            var userInfo = _currentUserService.GetUserInfo();
            List<int> costCentersUser = await _unitOfWork.responsabilityCostCenter.Get().Where(x => x.UserId == userInfo.Id).Select(x => x.CostCenterId).ToListAsync();

            var responseAccompanimentPlanDtos = _mapper.Map<List<ResponseAccompanimentPlanDto>>(await _unitOfWork.ResponseAccompanimentPlanRepository
                                                                    .Get()
                                                                    .Where(x => x.AccompanimentPlanId == request.AccompanimentPlanId && costCentersUser.Contains(x.AccompanimentPlan.CostCenterId))
                                                                    .Include(x => x.AccompanimentPlan)
                                                                    .Include(x => x.TypeAccompanimentPlan)
                                                                    .Include(x => x.Status)
                                                                    .Include(x => x.UserMadeAccompanimentPlan)
                                                                    .OrderBy(x => x.TypeAccompanimentPlan.Order)
                                                                    .ToListAsync());
            List<ResponseAccompanimentPlanReportDto> responseAccompanimentPlanQuestionDtos = new List<ResponseAccompanimentPlanReportDto>();
            foreach (var responseAccompanimentPlanDto in responseAccompanimentPlanDtos)
            {
                responseAccompanimentPlanQuestionDtos.Add(new ResponseAccompanimentPlanReportDto()
                {
                    responseAccompanimentPlan = responseAccompanimentPlanDto

                });
            }
            return responseAccompanimentPlanQuestionDtos;
        }
        public async Task<ApiResponse<List<ResponseAccompanimentPlanDto>>> GetByDocumentResponseAccompanimentPlan(GetByDocumentResponseAccompanimentPlanQuery request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<List<ResponseAccompanimentPlanDto>>();
            try
            {
                var userInfo = _currentUserService.GetUserInfo();
                List<int> costCentersUser = await _unitOfWork.responsabilityCostCenter.Get().Where(x => x.UserId == userInfo.Id).Select(x => x.CostCenterId).ToListAsync();

                response.Data = _mapper.Map<List<ResponseAccompanimentPlanDto>>(await _unitOfWork.ResponseAccompanimentPlanRepository
                                                                    .Get()
                                                                    .Include(x => x.AccompanimentPlan)
                                                                    .Include(x => x.Status)
                                                                    .Include(x => x.TypeAccompanimentPlan)
                                                                    .Where(x => x.AccompanimentPlan.Document == request.Document && costCentersUser.Contains(x.AccompanimentPlan.CostCenterId))
                                                                    .OrderBy(x => x.CreatedAt)
                                                                    .ToListAsync());

                response.Result = true;
                response.Message = "Ok";
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al consultar el registro, ResponseAccompanimentPlan en el método GetByDocumentResponseAccompanimentPlan, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al consultar el registro, consulte con el administrador. { ex.Message } ";
            }
            return response;
        }
        public async Task<ApiResponse<ResponseAccompanimentPlanDto>> PostResponseAccompanimentPlan(PostResponseAccompanimentPlanCommand request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<ResponseAccompanimentPlanDto>();

            try
            {
                var accompanimentPlan = await GetAccompanimentPlanById(request);
                
                var accompanimentPlanExist = _mapper.Map<ResponseAccompanimentPlanDto>(await _unitOfWork.ResponseAccompanimentPlanRepository
                                                                    .Get()
                                                                    .Where(x => x.AccompanimentPlanId == accompanimentPlan.Id && x.TypeAccompanimentPlanId == request.TypeAccompanimentPlanId + 1)
                                                                    .FirstOrDefaultAsync());
                
                if (accompanimentPlanExist == null)
                {
                    var getNextTypeAccompanimentPlan = await GetNextTypeAccompanimentPlan(accompanimentPlan.TypeAccompanimentPlanId);
                    var responseAccompanimentPlan = await GetResponseAccompanimentPlanById(request.ResponseAccompanimentPlanId);
                    var putResponseAccompanimentPlan = await PutResponseAccompanimentPlan(responseAccompanimentPlan, request);

                    if (getNextTypeAccompanimentPlan != null)
                    {
                        await PostResponseAccompanimentPlan(getNextTypeAccompanimentPlan, request);
                        accompanimentPlan.TypeAccompanimentPlanId = getNextTypeAccompanimentPlan.Id;
                        accompanimentPlan.StatusId = new Guid("88363FA0-54B9-4426-AE75-49D1CE35B314");
                    }
                    else
                    {
                        accompanimentPlan.StatusId = new Guid("2E1B43C2-A43B-4ACA-9E0F-C4288F2C983C");
                    }
                    await PutAccompanimentPlan(accompanimentPlan);

                    await PostResponseQuestion(request.responseQuestions);

                    if (request.responseAdditionalQuestions != null)
                    {
                        await PostResponseAdditionalQuestion(request.responseAdditionalQuestions);
                    }


                    response.Data = _mapper.Map<ResponseAccompanimentPlanDto>(await _unitOfWork.ResponseAccompanimentPlanRepository
                                                                        .Get()
                                                                        .Where(x => x.AccompanimentPlanId == request.AccompanimentPlanId && x.TypeAccompanimentPlanId == (getNextTypeAccompanimentPlan != null ? getNextTypeAccompanimentPlan.Id : putResponseAccompanimentPlan.TypeAccompanimentPlanId))
                                                                        .FirstOrDefaultAsync());
                }
                else
                {
                    response.Data = null;
                }
                response.Result = true;
                response.Message = "OK";
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar el registro, ResponseAdditionalQuestionService en el método PostResponseAdditionalQuestion, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al actualizar el registro, consulte con el administrador. { ex.Message } ";
            }

            return response;
        }

        public async Task PostResponseAdditionalQuestion(List<ResponseAdditionalQuestionDto> responseAdditionalQuestions)
        {
            await _unitOfWork.ResponseAdditionalQuestionRepository.AddRange(_mapper.Map<List<ResponseAdditionalQuestion>>(responseAdditionalQuestions));
        }

        public async Task PostResponseQuestion(List<ResponseQuestionDto> responseQuestions)
        {
            await _unitOfWork.ResponseQuestionRepository.AddRange(_mapper.Map<List<ResponseQuestion>>(responseQuestions));
        }

        public async Task PutAccompanimentPlan(AccompanimentPlan accompanimentPlan)
        {
            accompanimentPlan.UpdatedBy = (Guid)_currentUserService.GetUserInfo().Id;
            accompanimentPlan.UpdatedAt = DateTime.Now;
            accompanimentPlan.LastUpdatedByName = _createUpdateByName;

            _mapper.Map<AccompanimentPlanDto>(await _unitOfWork.AccompanimentPlanRepository.Put(accompanimentPlan));
        }

        public async Task PostResponseAccompanimentPlan(TypeAccompanimentPlan getNextTypeAccompanimentPlan, PostResponseAccompanimentPlanCommand request)
        {
            ResponseAccompanimentPlan responseAccompanimentPlanPost = new ResponseAccompanimentPlan
            {
                TypeAccompanimentPlanId = getNextTypeAccompanimentPlan.Id,
                AccompanimentPlanId = request.AccompanimentPlanId,
                ScheduledDate = request.ScheduledDate,
                CreatedAt = DateTime.Now,
                CreatedBy = (Guid)_currentUserService.GetUserInfo().Id,
                LastCreatedByName = _createUpdateByName,
                StatusId = new Guid("88363FA0-54B9-4426-AE75-49D1CE35B314"),
            };
            _mapper.Map<ResponseAccompanimentPlanDto>(await _unitOfWork.ResponseAccompanimentPlanRepository.Add(_mapper.Map<ResponseAccompanimentPlan>(responseAccompanimentPlanPost)));
        }

        public async Task<TypeAccompanimentPlan> GetNextTypeAccompanimentPlan(int typeAccompanimentPlanId)
        {
            var getTypeAccompanimentPlan = await _unitOfWork.TypeAccompanimentPlanRepository.Get()
                                                                    .Where(x => x.Id == typeAccompanimentPlanId)
                                                                    .FirstOrDefaultAsync();
            return await _unitOfWork.TypeAccompanimentPlanRepository.Get()
                                                                .Where(x => x.Order == (getTypeAccompanimentPlan.Order + 1))
                                                                .FirstOrDefaultAsync();
        }

        public async Task<AccompanimentPlan> GetAccompanimentPlanById(PostResponseAccompanimentPlanCommand request)
        {
            return await _unitOfWork.AccompanimentPlanRepository.Get()
                                                                .Where(x => x.Id == request.AccompanimentPlanId)
                                                                .FirstOrDefaultAsync() ?? throw new NotFoundException("The AccompanimentPlan is not found");
        }

        public async Task<ResponseAccompanimentPlanDto> PutResponseAccompanimentPlan(ResponseAccompanimentPlan responseAccompanimentPlan, PostResponseAccompanimentPlanCommand request)
        {
            responseAccompanimentPlan.UpdatedBy = (Guid)_currentUserService.GetUserInfo().Id;
            responseAccompanimentPlan.UpdatedAt = DateTime.Now;
            responseAccompanimentPlan.ConclusionsAndCommitments = request.ConclusionsAndCommitments;
            responseAccompanimentPlan.StartDate = request.StartDate;
            responseAccompanimentPlan.FinalDate = DateTime.Now;
            responseAccompanimentPlan.StatusId = new Guid("2E1B43C2-A43B-4ACA-9E0F-C4288F2C983C");
            responseAccompanimentPlan.UserMadeAccompanimentPlanId = (Guid)_currentUserService.GetUserInfo().Id;

            return _mapper.Map<ResponseAccompanimentPlanDto>(await _unitOfWork.ResponseAccompanimentPlanRepository.Put(responseAccompanimentPlan));
        }

        public async Task<ResponseAccompanimentPlan> GetResponseAccompanimentPlanById(int responseAccompanimentPlanId)
        {
            return await _unitOfWork.ResponseAccompanimentPlanRepository.Get()
                                                                    .Where(x => x.Id == responseAccompanimentPlanId)
                                                                    .FirstOrDefaultAsync() ?? throw new NotFoundException("The ResponseAccompanimentPlan is not found");
        }
        /*public async Task<ApiResponse<List<ResponseAccompanimentPlanDto>>> GetByStatusIdResponseAccompanimentPlan(GetByStatusIdResponseAccompanimentPlanQuery request, CancellationToken cancellationToken)
        {
           var response = new ApiResponse<List<ResponseAccompanimentPlanDto>>();
           try
           {
               response.Data = _mapper.Map<List<ResponseAccompanimentPlanDto>>(await _unitOfWork.ResponseAccompanimentPlanRepository.Get()
                                                                   .Where(x => x.StatusId == request.StatusId)
                                                                   .Include(x => x.TypeAccompanimentPlan)
                                                                   .OrderBy(x => x.CreatedAt)
                                                                   .ToListAsync());
               response.Result = true;
               response.Message = "Ok";
           }
           catch (Exception ex)
           {
               _logger.LogError($"Error al consultar el registro, ResponseAccompanimentPlan en el método GetByStatusIdResponseAccompanimentPlan, { ex.Message } ");
               response.Result = false;
               response.Message = $"Error al consultar el registro, consulte con el administrador. { ex.Message } ";
           }
           return response;
        }*/
    }
}
