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
    public class GetByDocumentResponseAccompanimentPlanQuery : IRequest<ApiResponse<List<ResponseAccompanimentPlanDto>>>
    {
        public string Document { get; set; }
    }
    public class GetByDocumentResponseAccompanimentPlanQueryHandler : IRequestHandler<GetByDocumentResponseAccompanimentPlanQuery, ApiResponse<List<ResponseAccompanimentPlanDto>>>
    {
        private readonly IResponseAccompanimentPlanService _responseAccompanimentPlanService;
        private readonly IMapper _mapper;
        public GetByDocumentResponseAccompanimentPlanQueryHandler(IResponseAccompanimentPlanService responseAccompanimentPlanService, IMapper mapper)
        {
            _responseAccompanimentPlanService = responseAccompanimentPlanService;
            _mapper = mapper;
        }
        public async Task<ApiResponse<List<ResponseAccompanimentPlanDto>>> Handle(GetByDocumentResponseAccompanimentPlanQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<ApiResponse<List<ResponseAccompanimentPlanDto>>>(await _responseAccompanimentPlanService.GetByDocumentResponseAccompanimentPlan(request, cancellationToken));
        }
    }
}
