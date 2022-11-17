using Application.Common.Response;
using Application.DTOs.OvertimePeriods;
using Application.Interfaces.Overtimes;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.OvertimePeriods.Queries.GetOvertimePeriodById
{
    public class GetOvertimePeriodByIdQuery : IRequest<ApiResponse<OvertimePeriodDto>>
    {

        public int Id { get; set; }
        
    }

    public class GetOvertimePeriodQueryHandle : IRequestHandler<GetOvertimePeriodByIdQuery, ApiResponse<OvertimePeriodDto>>
    {
        private readonly IMapper _mapper;
        private readonly IOvertimePeriodService _overtimePeriodService;

        public GetOvertimePeriodQueryHandle(IOvertimePeriodService overtimePeriodService, IMapper mapper)
        {
            _overtimePeriodService = overtimePeriodService;
            _mapper = mapper;
        }


        public async Task<ApiResponse<OvertimePeriodDto>> Handle(GetOvertimePeriodByIdQuery request, CancellationToken cancellationToken)
        {

            return _mapper.Map<ApiResponse<OvertimePeriodDto>>(await _overtimePeriodService.GetPeriodById(request.Id));      

        }
    }
}
