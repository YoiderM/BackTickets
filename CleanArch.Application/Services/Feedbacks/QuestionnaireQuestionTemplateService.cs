using Application.Common.Response;
using Application.Cqrs.Feedbacks.QuestionnaireQuestionTemplate.Queries;
using Application.DTOs.Feedbacks;
using Application.Interfaces.Feedbacks;
using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Feedbacks
{
    public class QuestionnaireQuestionTemplateService : IQuestionnaireQuestionTemplateService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private ICurrentUserService _currentUserService;
        //private string _createdUpdateByName;
        //private Guid _userId;
        public QuestionnaireQuestionTemplateService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<QuestionnaireQuestionTemplateService> logger, ICurrentUserService currentUserService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _currentUserService = currentUserService;
            //_userId = (Guid)_currentUserService.GetUserInfo().Id;
            //_createdUpdateByName = _currentUserService.GetUserInfo().Name;
        }
        public async Task<ApiResponse<List<QuestionnaireQuestionTemplateDto>>> GetByTypeAccompanimentPlanIdQuestionnaireQuestionTemplatePlan(GetByTypeAccompanimentPlanIdQuestionnaireQuestionPlanQuery request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<List<QuestionnaireQuestionTemplateDto>>();
            try
            {
                response.Data = _mapper.Map<List<QuestionnaireQuestionTemplateDto>>(await _unitOfWork.QuestionnaireQuestionTemplateRepository
                                                                                            .Get()
                                                                                            .Include(x => x.QuestionnaireTemplate)
                                                                                            .Include(x => x.QuestionType)
                                                                                            .Include(x => x.OriginQuestion)
                                                                                            .Where(x => x.QuestionnaireTemplate.TypeAccompanimentPlanId == request.TypeAccompanimentPlanId)
                                                                                            .ToListAsync());
                response.Result = true;
                response.Message = "OK";
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al consultar los registros, QuestionnaireQuestionTemplateService en el método GetByTypeAccompanimentPlanIdQuestionnaireQuestionTemplatePlan, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al consultar los registros, consulte con el administrador. { ex.Message } ";
            }
            return response;
        }
    }
}
