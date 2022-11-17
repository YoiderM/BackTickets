using Application.Common.Response;
using Application.DTOs.OvertimePeriods;
using Application.Interfaces.Overtimes;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.OvertimePeriodDetail.Queries
{
    public class GetOvertimeDetailByIdQuery : IRequest<ApiResponse<OvertimeDetailDto>>
    {
        public Guid Id { get; set; }
    }

    public class GetOvertimesByIdQueryHandler : IRequestHandler<GetOvertimeDetailByIdQuery, ApiResponse<OvertimeDetailDto>>
    {
        
        private readonly IOvertimeService _overtimeService;
        private readonly IMapper _mapper;

        public GetOvertimesByIdQueryHandler(IOvertimeService overtimeService, IMapper mapper)
        {
            _overtimeService = overtimeService;
            _mapper = mapper;

        } 

        public async Task<ApiResponse<OvertimeDetailDto>> Handle(GetOvertimeDetailByIdQuery request, CancellationToken cancellationToken)
        {

            //return await _overtimeService.GetOvertimeDetailById(request.Id, cancellationToken);

            return _mapper.Map<ApiResponse<OvertimeDetailDto>>(await _overtimeService.GetOvertimeDetailById(request.Id, cancellationToken));

        }
    }

}
