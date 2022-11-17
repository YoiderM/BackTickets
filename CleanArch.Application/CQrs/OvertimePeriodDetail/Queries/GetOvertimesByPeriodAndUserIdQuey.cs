using Application.DTOs.OvertimePeriods;
using Application.Interfaces.Overtimes;
using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.OvertimePeriodDetail.Queries
{

    public class GetOvertimesByPeriodAndUserIdQuey : IRequest<List<OvertimeDetailDto>>
    {
        public int PeriodId { get; set; }
    }

    public class GetOvertimesByPeriodAndUserIdQueyHandle : IRequestHandler<GetOvertimesByPeriodAndUserIdQuey, List<OvertimeDetailDto>>
    {
        private readonly IMapper _mapper;
        private readonly IOvertimeService _overtimeService;
        private readonly ICurrentUserService _currentUserService;

        public GetOvertimesByPeriodAndUserIdQueyHandle(IOvertimeService overtimeService, IMapper mapper, ICurrentUserService currentUserService)
        {
            _overtimeService = overtimeService;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }


        public async Task<List<OvertimeDetailDto>> Handle(GetOvertimesByPeriodAndUserIdQuey request, CancellationToken cancellationToken)
        {
           
            return _mapper.Map<List<OvertimeDetailDto>>(
                await _overtimeService.GetByPeriodAndUserId(request.PeriodId, (Guid)_currentUserService.GetUserInfo().Id, cancellationToken)
                );
        }
    }


}
