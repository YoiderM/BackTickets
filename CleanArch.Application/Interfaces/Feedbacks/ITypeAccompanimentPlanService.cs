using Application.Common.Response;
using Application.Cqrs.Feedbacks.TypeAccompanimentPlan.Queries;
using Application.DTOs.Feedbacks;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Feedbacks
{
    public interface ITypeAccompanimentPlanService
    {
        Task<ApiResponse<List<TypeAccompanimentPlanDto>>> GetTypes(GetTypeAccompanimentPlanQuery request, CancellationToken cancellationToken);
        Task<ApiResponse<TypeAccompanimentPlanDto>> GetTypesById(int type);
        Task<ApiResponse<ReturnStartDateAndEndDateNextAccompanimentPlan>> GetNextDateAccompanimentPlan(GetNextDateByTypeAccompanimentPlanQuery request, CancellationToken cancellationToken);
    }
}
