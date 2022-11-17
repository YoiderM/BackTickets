using Application.Common.Response;
using Application.DTOs.Feedbacks;
using Application.Interfaces.Feedbacks;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.Feedbacks.AccompanimentPlan.Queries
{
    public class GetByDocumentResponseAccompanimentPlanQuery : IRequest<ApiResponse<List<AccompanimentPlanDto>>>
    {
        public string Document { get; set; }
    }
    public class GetByDocumentAccompanimentPlanQueryHandler : IRequestHandler<GetByDocumentResponseAccompanimentPlanQuery, ApiResponse<List<AccompanimentPlanDto>>>
    {
        private readonly IAccompanimentPlanService _accompanimentPlanService;
        private readonly IMapper _mapper;
        public GetByDocumentAccompanimentPlanQueryHandler(IAccompanimentPlanService accompanimentPlanService, IMapper mapper)
        {
            _accompanimentPlanService = accompanimentPlanService;
            _mapper = mapper;
        }
        public async Task<ApiResponse<List<AccompanimentPlanDto>>> Handle(GetByDocumentResponseAccompanimentPlanQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<ApiResponse<List<AccompanimentPlanDto>>>(await _accompanimentPlanService.GetByDocumentAccompanimentPlan(request, cancellationToken));
        }
    }
}
