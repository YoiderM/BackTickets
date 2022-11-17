using Application.Common.Response;
using Application.DTOs.Feedbacks;
using Application.Interfaces.Feedbacks;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.Feedbacks.ResponseAccompanimentPlan.Queries
{
    public class GetByTypeAccompanimentPlanResponseAccompanimentPlanQuery : IRequest<ApiResponse<List<ResponseAccompanimentPlanDto>>>
    {
        public int TypeAccompanimentPlanId { get; set; }
    }

    public class GetByTypeAccompanimentPlanResponseAccompanimentPlanQueryHandler : IRequestHandler<GetByTypeAccompanimentPlanResponseAccompanimentPlanQuery, ApiResponse<List<ResponseAccompanimentPlanDto>>>
    {
        private readonly IResponseAccompanimentPlanService _responseAccompanimentPlanService;
        private readonly IMapper _mapper;
        public GetByTypeAccompanimentPlanResponseAccompanimentPlanQueryHandler(IResponseAccompanimentPlanService responseAccompanimentPlanService, IMapper mapper)
        {
            _responseAccompanimentPlanService = responseAccompanimentPlanService;
            _mapper = mapper;
        }
        public async Task<ApiResponse<List<ResponseAccompanimentPlanDto>>> Handle(GetByTypeAccompanimentPlanResponseAccompanimentPlanQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<ApiResponse<List<ResponseAccompanimentPlanDto>>>(await _responseAccompanimentPlanService.GetByTypeAccompanimentPlanResponseAccompanimentPlan(request, cancellationToken));
        }
    }
}
