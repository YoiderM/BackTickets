using Application.Common.Response;
using Application.Cqrs.Feedbacks.ResponseAccompanimentPlan.Commands;
using Application.Cqrs.Feedbacks.ResponseAccompanimentPlan.Queries;
using Application.DTOs.Feedbacks;
using Domain.CustomEntities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Feedbacks
{
    public interface IResponseAccompanimentPlanService
    {
        Task<List<ResponseAccompanimentPlanQuestionDto>> GetResponseAccompanimentPlans(GetResponseAccompanimentPlanQuery request, CancellationToken cancellationToken);
        Task<ApiResponse<List<ResponseAccompanimentPlanDto>>> GetByTypeAccompanimentPlanResponseAccompanimentPlan(GetByTypeAccompanimentPlanResponseAccompanimentPlanQuery request, CancellationToken cancellationToken);
        Task<List<ResponseAccompanimentPlanReportDto>> GetByAccompanimentPlanIdResponseAccompanimentPlan(GetByAccompanimentPlanIdResponseAccompanimentPlanQuery request, CancellationToken cancellationToken);
        Task<ApiResponse<List<ResponseAccompanimentPlanDto>>> GetByDocumentResponseAccompanimentPlan(GetByDocumentResponseAccompanimentPlanQuery request, CancellationToken cancellationToken);
        Task<ApiResponse<ResponseAccompanimentPlanDto>> PostResponseAccompanimentPlan(PostResponseAccompanimentPlanCommand request, CancellationToken cancellationToken);
        Task PostResponseAdditionalQuestion(List<ResponseAdditionalQuestionDto> responseAdditionalQuestions);
        Task PostResponseQuestion(List<ResponseQuestionDto> responseQuestions);
        //Task<ApiResponse<List<ResponseAccompanimentPlanDto>>> GetByStatusIdResponseAccompanimentPlan(GetByStatusIdResponseAccompanimentPlanQuery request, CancellationToken cancellationToken);
    }
}
