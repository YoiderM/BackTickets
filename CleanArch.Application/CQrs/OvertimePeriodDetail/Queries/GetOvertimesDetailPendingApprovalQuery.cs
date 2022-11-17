using Application.Common.Response;
using Application.DTOs.OvertimePeriods;
using Application.Interfaces.Overtimes;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.OvertimePeriodDetail.Queries
{
    public class GetOvertimesDetailPendingApprovalQuery : IRequest<ApiResponse<List<OvertimeDetailDto>>>
    {
        public int PeriodId { get; set; }

    }

    public class GetOvertimesDetailPendingApprovalQueryHandler : IRequestHandler<GetOvertimesDetailPendingApprovalQuery, ApiResponse<List<OvertimeDetailDto>>>
    {
        
        private readonly IOvertimeService _overtimeService;    

        public GetOvertimesDetailPendingApprovalQueryHandler(IOvertimeService overtimeService) => _overtimeService = overtimeService;      

        public async Task<ApiResponse<List<OvertimeDetailDto>>> Handle(GetOvertimesDetailPendingApprovalQuery request, CancellationToken cancellationToken)
        {
            return await _overtimeService.GetOvertimesDetailPendingApproval(request.PeriodId, cancellationToken);           

        }
    }
}
