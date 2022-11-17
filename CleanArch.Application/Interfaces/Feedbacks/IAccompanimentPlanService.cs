using Application.Common.Response;
using Application.Cqrs.Feedbacks.AccompanimentPlan.Queries;
using Application.DTOs.Feedbacks;
using Domain.CustomEntities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Feedbacks
{
    public interface IAccompanimentPlanService
    {
        Task<PaginatedList<AccompanimentPlanDto>> GetAccompanimentPlans(GetResponseAccompanimentPlanQuery request, CancellationToken cancellationToken);
        Task<ApiResponse<List<AccompanimentPlanDto>>> GetByTypeAccompanimentPlan(GetByTypeAccompanimentPlanResponseAccompanimentPlanQuery request, CancellationToken cancellationToken); 
        Task<ApiResponse<List<AccompanimentPlanDto>>> GetByDocumentAccompanimentPlan(GetByDocumentResponseAccompanimentPlanQuery request, CancellationToken cancellationToken);
        Task<ApiResponse<List<AccompanimentPlanDto>>> GetByStatusIdAccompanimentPlan(GetByStatusIdResponseAccompanimentPlanQuery request, CancellationToken cancellationToken);
    }
}
