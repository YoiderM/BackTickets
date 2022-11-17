using Application.Common.Response;
using Application.DTOs.Feedbacks;
using Application.Interfaces.Feedbacks;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.Feedbacks.QuestionnaireQuestionTemplate.Queries
{
    public class GetByTypeAccompanimentPlanIdQuestionnaireQuestionPlanQuery : IRequest<ApiResponse<List<QuestionnaireQuestionTemplateDto>>>
    {
        public int TypeAccompanimentPlanId { get; set; }
    }
    public class GetByTypeAccompanimentPlanIdQuestionnaireQuestionPlanQueryHandler : IRequestHandler<GetByTypeAccompanimentPlanIdQuestionnaireQuestionPlanQuery, ApiResponse<List<QuestionnaireQuestionTemplateDto>>>
    {
        private readonly IQuestionnaireQuestionTemplateService _questionnaireQuestionTemplateService;
        private readonly IMapper _mapper;
        public GetByTypeAccompanimentPlanIdQuestionnaireQuestionPlanQueryHandler(IQuestionnaireQuestionTemplateService questionnaireQuestionTemplateService, IMapper mapper)
        {
            _questionnaireQuestionTemplateService = questionnaireQuestionTemplateService;
            _mapper = mapper;
        }
        public async Task<ApiResponse<List<QuestionnaireQuestionTemplateDto>>> Handle(GetByTypeAccompanimentPlanIdQuestionnaireQuestionPlanQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<ApiResponse<List<QuestionnaireQuestionTemplateDto>>>(await _questionnaireQuestionTemplateService.GetByTypeAccompanimentPlanIdQuestionnaireQuestionTemplatePlan(request, cancellationToken));
        }
    }
}
