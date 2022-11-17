using Application.DTOs.OvertimePeriods;
using Application.Interfaces.Overtimes;
using AutoMapper;
using Domain.CustomEntities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.OvertimePeriods.Queries.GetPeriods
{
    public class GetOvertimePeriodQuery : IRequest<PaginatedList<OvertimePeriodDto>>
    {

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 30;
    }

    public class GetOvertimePeriodQueryHandle : IRequestHandler<GetOvertimePeriodQuery, PaginatedList<OvertimePeriodDto>>
    {
        private readonly IMapper _mapper;
        private readonly IOvertimePeriodService _overtimePeriodService;

        public  GetOvertimePeriodQueryHandle(IOvertimePeriodService overtimePeriodService , IMapper mapper)
        {
            _overtimePeriodService = overtimePeriodService;
            _mapper = mapper;
        }


        public async Task<PaginatedList<OvertimePeriodDto>> Handle(GetOvertimePeriodQuery request, CancellationToken cancellationToken)
        {

            return  await _overtimePeriodService.GetPeriods(request,cancellationToken);
        
        }


    }
}
