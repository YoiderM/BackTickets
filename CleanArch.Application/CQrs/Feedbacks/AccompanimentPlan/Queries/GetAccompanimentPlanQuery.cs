using Application.DTOs.Feedbacks;
using Application.Interfaces.Feedbacks;
using AutoMapper;
using Domain.CustomEntities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.Feedbacks.AccompanimentPlan.Queries
{
    public class GetResponseAccompanimentPlanQuery : IRequest<PaginatedList<AccompanimentPlanDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 30;
    }
    public class GetAccompanimentPlanQueryHandler : IRequestHandler<GetResponseAccompanimentPlanQuery, PaginatedList<AccompanimentPlanDto>>
    {
        private readonly IAccompanimentPlanService _accompanimentPlanService;
        private readonly IMapper _mapper;
        public GetAccompanimentPlanQueryHandler(IAccompanimentPlanService accompanimentPlanService, IMapper mapper)
        {
            _accompanimentPlanService = accompanimentPlanService;
            _mapper = mapper;
        }
        public async Task<PaginatedList<AccompanimentPlanDto>> Handle(GetResponseAccompanimentPlanQuery request, CancellationToken cancellationToken)
        {
            return await _accompanimentPlanService.GetAccompanimentPlans(request, cancellationToken);
        }
    }
}
