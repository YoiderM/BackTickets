using Application.Common.Response;
using Application.DTOs.Feedbacks;
using Application.Interfaces.Feedbacks;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.Feedbacks.ResponseAccompanimentPlan.Queries
{
    public class GetByStatusIdResponseAccompanimentPlanQuery : IRequest<ApiResponse<List<ResponseAccompanimentPlanDto>>>
    {
        public Guid StatusId { get; set; }
    }
    public class GetByStatusIdResponseAccompanimentPlanQueryHandler : IRequestHandler<GetByStatusIdResponseAccompanimentPlanQuery, ApiResponse<List<ResponseAccompanimentPlanDto>>>
    {
        private readonly IResponseAccompanimentPlanService _responseAccompanimentPlanService;
        private readonly IMapper _mapper;
        public GetByStatusIdResponseAccompanimentPlanQueryHandler(IResponseAccompanimentPlanService responseAccompanimentPlanService, IMapper mapper)
        {
            _responseAccompanimentPlanService = responseAccompanimentPlanService;
            _mapper = mapper;
        }
        public async Task<ApiResponse<List<ResponseAccompanimentPlanDto>>> Handle(GetByStatusIdResponseAccompanimentPlanQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<ApiResponse<List<ResponseAccompanimentPlanDto>>>(await _responseAccompanimentPlanService.GetByStatusIdResponseAccompanimentPlan(request, cancellationToken));
        }
    }
}
