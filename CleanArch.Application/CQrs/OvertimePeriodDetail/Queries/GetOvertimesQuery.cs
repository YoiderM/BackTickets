using Application.DTOs.OvertimePeriods;
using Application.Interfaces.Overtimes;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.OvertimePeriodDetail.Queries
{
    public class GetOvertimesQuery : IRequest<IList<OvertimeDetailDto>>
    {    
       public int? PeriodId { get; set; }   
     
    }

    public class GetOvertimesQueryHandler : IRequestHandler<GetOvertimesQuery, IList<OvertimeDetailDto>>
    {
        private readonly IMapper _mapper;
        private readonly IOvertimeService _overtimeService;

        public GetOvertimesQueryHandler(IOvertimeService overtimeService, IMapper mapper)
        {
            _overtimeService = overtimeService;
            _mapper = mapper;
        }


        public async Task<IList<OvertimeDetailDto>> Handle(GetOvertimesQuery request, CancellationToken cancellationToken)
        {

            return  _mapper.Map<IList<OvertimeDetailDto>>(
                await _overtimeService.Get(request, cancellationToken)
                );
        }

    }
}
