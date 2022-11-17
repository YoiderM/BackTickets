using Application.DTOs.OvertimePeriods;
using Application.Interfaces.Overtimes;
using AutoMapper;
using Domain.CustomEntities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.OvertimePeriods.Queries
{
    public class GetOvertimePeriodIspaidQuery :IRequest<PaginatedList<OvertimePeriodDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 30;
    }

    public class GetOvertimePeriodIspaidQueryHandler : IRequestHandler<GetOvertimePeriodIspaidQuery, PaginatedList<OvertimePeriodDto>>
    {
        private readonly IMapper _mapper;
        private readonly IOvertimePeriodService _overtimePeriodService;

        public GetOvertimePeriodIspaidQueryHandler(IMapper mapper, IOvertimePeriodService overtimePeriodService)
        {
            _mapper = mapper;
            _overtimePeriodService = overtimePeriodService;
        }
        public async Task<PaginatedList<OvertimePeriodDto>> Handle(GetOvertimePeriodIspaidQuery request, CancellationToken cancellationToken)
        {
            return await _overtimePeriodService.GetPeriodsIsPaid(request, cancellationToken);

        }
    }


}
