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
    public class GetByAccompanimentPlanIdResponseAccompanimentPlanQuery : IRequest<List<ResponseAccompanimentPlanReportDto>>
    {
        public int AccompanimentPlanId { get; set; }
    }

    public class GetByAccompanimentPlanIdResponseAccompanimentPlanQueryHandler : IRequestHandler<GetByAccompanimentPlanIdResponseAccompanimentPlanQuery, List<ResponseAccompanimentPlanReportDto>>
    {
        private readonly IResponseAccompanimentPlanService _responseAccompanimentPlanService;
        private readonly IMapper _mapper;
        public GetByAccompanimentPlanIdResponseAccompanimentPlanQueryHandler(IResponseAccompanimentPlanService responseAccompanimentPlanService, IMapper mapper)
        {
            _responseAccompanimentPlanService = responseAccompanimentPlanService;
            _mapper = mapper;
        }
        public async Task<List<ResponseAccompanimentPlanReportDto>> Handle(GetByAccompanimentPlanIdResponseAccompanimentPlanQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<ResponseAccompanimentPlanReportDto>>(await _responseAccompanimentPlanService.GetByAccompanimentPlanIdResponseAccompanimentPlan(request, cancellationToken));
        }
    }
}
