using Application.DTOs.Feedbacks;
using Application.Interfaces.Feedbacks;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.Feedbacks.ResponseAccompanimentPlan.Queries
{
    public class GetResponseAccompanimentPlanQuery : IRequest<List<ResponseAccompanimentPlanQuestionDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 30;
    }
    public class GetResponseAccompanimentPlanQueryHandler : IRequestHandler<GetResponseAccompanimentPlanQuery, List<ResponseAccompanimentPlanQuestionDto>>
    {
        private readonly IResponseAccompanimentPlanService _responseAccompanimentPlanService;
        private readonly IMapper _mapper;
        public GetResponseAccompanimentPlanQueryHandler(IResponseAccompanimentPlanService responseAccompanimentPlanService, IMapper mapper)
        {
            _responseAccompanimentPlanService = responseAccompanimentPlanService;
            _mapper = mapper;
        }
        public async Task<List<ResponseAccompanimentPlanQuestionDto>> Handle(GetResponseAccompanimentPlanQuery request, CancellationToken cancellationToken)
        {
            return await _responseAccompanimentPlanService.GetResponseAccompanimentPlans(request, cancellationToken);
        }
    }
}
