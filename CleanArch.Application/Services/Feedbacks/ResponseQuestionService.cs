using Application.Common.Response;
using Application.Cqrs.Feedbacks.ResponseQuestion.Queries;
using Application.DTOs.Feedbacks;
using Application.Interfaces.Feedbacks;
using Application.Interfaces.Rol;
using Application.Interfaces.User;
using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using Domain.Interfaces;
using Domain.Models.Feedbacks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Feedbacks
{
    public class ResponseQuestionService : IResponseQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private ICurrentUserService _currentUserService;
        private Guid _userId;
        private string _createdByName;
        public ResponseQuestionService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ILogger<ResponseQuestionService> logger,
            ICurrentUserService currentUserService
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _currentUserService = currentUserService;
        }
        public async Task<ApiResponse<ResponseQuestionAndResponseAdditionalDto>> GetByResponseAccompanimentPlanIdResponseQuestion(GetByResponseAccompanimentPlanIdResponseQuestionQuery request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<ResponseQuestionAndResponseAdditionalDto>();
            try
            {
                var responseQuestionDtos = _mapper.Map<List<ResponseQuestionAndQuestionnaireDto>>(await _unitOfWork.ResponseQuestionRepository
                                                                    .Get()
                                                                    .Include(x => x.QuestionnaireTemplate)
                                                                    .Include(x => x.QuestionnaireQuestionTemplate)
                                                                    .Include(x => x.QuestionnaireQuestionTemplate.QuestionType)
                                                                    .Include(x => x.QuestionnaireQuestionTemplate.OriginQuestion)
                                                                    .Include(x => x.ResponseAccompanimentPlan)
                                                                    .Where(x => x.ResponseAccompanimentPlanId == request.ResponseAccompanimentPlanId)
                                                                    .OrderBy(x => x.CreatedAt)
                                                                    .ToListAsync());
                var responseAdditionalQuestionDtos = _mapper.Map<List<ResponseAdditionalQuestionDto>>(await _unitOfWork.ResponseAdditionalQuestionRepository
                                                                    .Get()
                                                                    .Include(x => x.ResponseAccompanimentPlan)
                                                                    .Where(x => x.ResponseAccompanimentPlanId == request.ResponseAccompanimentPlanId)
                                                                    .OrderBy(x => x.CreatedAt)
                                                                    .ToListAsync());
                
                var responseQuestionAndResponseAdditionalDto = new ResponseQuestionAndResponseAdditionalDto
                {
                    ResponseQuestion = responseQuestionDtos,
                    ResponseAdditionalQuestion = responseAdditionalQuestionDtos,
                };
                response.Data = responseQuestionAndResponseAdditionalDto;
                response.Result = true;
                response.Message = "Ok";
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al consultar el registro, ResponseQuestionService en el método GetByResponseAccompanimentPlanIdResponseQuestion, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al consultar el registro, consulte con el administrador. { ex.Message } ";
            }
            return response;
        }

        public async Task PostResponseQuestion(List<ResponseQuestionDto> responseQuestionDto)
        {
            await _unitOfWork.ResponseQuestionRepository.AddRange(_mapper.Map<List<ResponseQuestion>>(responseQuestionDto));
        }
    }
}
