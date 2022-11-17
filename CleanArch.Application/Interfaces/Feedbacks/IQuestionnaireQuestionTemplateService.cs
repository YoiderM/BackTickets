using Application.Common.Response;
using Application.Cqrs.Feedbacks.QuestionnaireQuestionTemplate.Queries;
using Application.DTOs.Feedbacks;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Feedbacks
{
    public interface IQuestionnaireQuestionTemplateService
    {
        Task<ApiResponse<List<QuestionnaireQuestionTemplateDto>>> GetByTypeAccompanimentPlanIdQuestionnaireQuestionTemplatePlan(GetByTypeAccompanimentPlanIdQuestionnaireQuestionPlanQuery request, CancellationToken cancellationToken);
    }
}
