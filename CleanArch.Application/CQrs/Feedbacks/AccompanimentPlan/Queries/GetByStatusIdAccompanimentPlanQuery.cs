using Application.Common.Response;
using Application.DTOs.Feedbacks;
using Application.Interfaces.Feedbacks;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.Feedbacks.AccompanimentPlan.Queries
{
    public class GetByStatusIdResponseAccompanimentPlanQuery : IRequest<ApiResponse<List<AccompanimentPlanDto>>>
    {
        public Guid StatusId { get; set; }
    }
    public class GetByStatusIdAccompanimentPlanQueryHandler : IRequestHandler<GetByStatusIdResponseAccompanimentPlanQuery, ApiResponse<List<AccompanimentPlanDto>>>
    {
        private readonly IAccompanimentPlanService _accompanimentPlanService;
        private readonly IMapper _mapper;
        public GetByStatusIdAccompanimentPlanQueryHandler(IAccompanimentPlanService accompanimentPlanService, IMapper mapper)
        {
            _accompanimentPlanService = accompanimentPlanService;
            _mapper = mapper;
        }
        public async Task<ApiResponse<List<AccompanimentPlanDto>>> Handle(GetByStatusIdResponseAccompanimentPlanQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<ApiResponse<List<AccompanimentPlanDto>>>(await _accompanimentPlanService.GetByStatusIdAccompanimentPlan(request, cancellationToken));
        }
    }
}
