using Application.Common.Response;
using Application.DTOs.Feedbacks;
using Application.Interfaces.Feedbacks;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.Feedbacks.TypeAccompanimentPlan.Queries
{
    public class GetNextDateByTypeAccompanimentPlanQuery : IRequest<ApiResponse<ReturnStartDateAndEndDateNextAccompanimentPlan>>
    {
        public int TypeAccompanimentPlanId { get; set; }
    }
    public class GetNextDateByTypeAccompanimentPlanQueryHandler : IRequestHandler<GetNextDateByTypeAccompanimentPlanQuery, ApiResponse<ReturnStartDateAndEndDateNextAccompanimentPlan>>
    {
        private readonly ITypeAccompanimentPlanService _typeAccompanimentPlanService;
        public GetNextDateByTypeAccompanimentPlanQueryHandler(ITypeAccompanimentPlanService typeAccompanimentPlanService)
        {
            _typeAccompanimentPlanService = typeAccompanimentPlanService;
        }
        public async Task<ApiResponse<ReturnStartDateAndEndDateNextAccompanimentPlan>> Handle(GetNextDateByTypeAccompanimentPlanQuery request, CancellationToken cancellationToken)
        {
            return await _typeAccompanimentPlanService.GetNextDateAccompanimentPlan(request, cancellationToken);
        }
    }
}
