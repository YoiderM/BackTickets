using Application.DTOs.OvertimePeriods;
using Application.Interfaces.Overtimes;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.OvertimePeriodDetail.Queries
{
    public class GetOvertimesByPeriodQuey : IRequest<IList<OvertimeDetailDto>>
    {
        public int id { get; set; }
    }

    public class GetOvertimesQueryHandle : IRequestHandler<GetOvertimesByPeriodQuey, IList<OvertimeDetailDto>>
    {
        private readonly IMapper _mapper;
        private readonly IOvertimeService _overtimeService;

        public GetOvertimesQueryHandle(IOvertimeService overtimeService, IMapper mapper)
        {
            _overtimeService = overtimeService;
            _mapper = mapper;
        }


        public async Task<IList<OvertimeDetailDto>> Handle(GetOvertimesByPeriodQuey request, CancellationToken cancellationToken)
        {

            return _mapper.Map<IList<OvertimeDetailDto>>(
                await _overtimeService.GetByPeriodId(request.id, cancellationToken)
                );

        }


    }
}
