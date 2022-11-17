using Application.Common.Response;
using Application.Cqrs.Feedbacks.ResponseAdditionalQuestion.Queries;
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
    public class ResponseAdditionalQuestionService : IResponseAdditionalQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private ICurrentUserService _currentUserService;
        private Guid _userId;
        private string _createdByName;
        public ResponseAdditionalQuestionService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ILogger<ResponseAdditionalQuestionService> logger,
            ICurrentUserService currentUserService
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _currentUserService = currentUserService;
        }
        public async Task<ApiResponse<List<ResponseAdditionalQuestionDto>>> GetByResponseAccompanimentPlanIdResponseAdditionalQuestion(GetByResponseAccompanimentPlanIdResponseAdditionalQuestionQuery request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<List<ResponseAdditionalQuestionDto>>();
            try
            {
                response.Data = _mapper.Map<List<ResponseAdditionalQuestionDto>>(await _unitOfWork.ResponseAdditionalQuestionRepository
                                                                    .Get()
                                                                    .Where(x => x.ResponseAccompanimentPlanId == request.ResponseAccompanimentPlanId)
                                                                    .OrderBy(x => x.CreatedAt)
                                                                    .ToListAsync());
                response.Result = true;
                response.Message = "Ok";
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al consultar el registro, ResponseAdditionalQuestionService en el método GetByResponseAccompanimentPlanIdResponseAdditionalQuestion, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al consultar el registro, consulte con el administrador. { ex.Message } ";
            }
            return response;
        }

        public async Task PostResponseAdditionalQuestion(List<ResponseAdditionalQuestionDto> responseAdditionalQuestionDtos)
        {
            await _unitOfWork.ResponseAdditionalQuestionRepository.AddRange(_mapper.Map<List<ResponseAdditionalQuestion>>(responseAdditionalQuestionDtos));
        }
    }
}
