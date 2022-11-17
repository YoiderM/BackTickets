using Application.Common.Response;
using Application.DTOs.Feedbacks;
using Application.Interfaces.Feedbacks;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.Feedbacks.TypeAccompanimentPlan.Queries
{
    public class GetTypeAccompanimentPlanQuery : IRequest<ApiResponse<List<TypeAccompanimentPlanDto>>>
    {
    }
    public class GetTypeAccompanimentPlanQueryHandler : IRequestHandler<GetTypeAccompanimentPlanQuery, ApiResponse<List<TypeAccompanimentPlanDto>>>
    {
        private readonly ITypeAccompanimentPlanService _typeAccompanimentPlanService;
        public GetTypeAccompanimentPlanQueryHandler(ITypeAccompanimentPlanService typeAccompanimentPlanService)
        {
            _typeAccompanimentPlanService = typeAccompanimentPlanService;
        }
        public async Task<ApiResponse<List<TypeAccompanimentPlanDto>>> Handle(GetTypeAccompanimentPlanQuery request, CancellationToken cancellationToken)
        {
            return await _typeAccompanimentPlanService.GetTypes(request, cancellationToken);
        }
    }
}
