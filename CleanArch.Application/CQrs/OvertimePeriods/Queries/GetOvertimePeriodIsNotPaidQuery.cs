using Application.Common.Response;
using Application.DTOs.OvertimePeriods;
using Application.Interfaces.Overtimes;
using AutoMapper;
using Domain.CustomEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.OvertimePeriods.Queries
{
    public class GetOvertimePeriodIsNotPaidQuery : IRequest<PaginatedList<OvertimePeriodDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 30;
    }

    public class GetOvertimePeriodIsNotPaidQueryHandler : IRequestHandler<GetOvertimePeriodIsNotPaidQuery, PaginatedList<OvertimePeriodDto>>
    {
        private readonly IMapper _mapper;
        private readonly IOvertimePeriodService _overtimePeriodService;

        public GetOvertimePeriodIsNotPaidQueryHandler(IMapper mapper, IOvertimePeriodService overtimePeriodService)
        {
            _mapper = mapper;
            _overtimePeriodService = overtimePeriodService;
        }
        public async Task<PaginatedList<OvertimePeriodDto>> Handle(GetOvertimePeriodIsNotPaidQuery request, CancellationToken cancellationToken)
        {
            return await _overtimePeriodService.GetPeriodsIsNotPaid(request, cancellationToken);

        }
    }


}