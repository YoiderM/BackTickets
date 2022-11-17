using Application.Common.Response;
using Application.Cqrs.OvertimePeriodDetail.Commands;
using Application.Cqrs.OvertimePeriodDetail.Queries;
using Application.DTOs.OvertimePeriods;
using Domain.Models.Overtimes;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Overtimes
{
    public interface IOvertimeService
    {
        Task<List<OvertimeDetail>> Get(GetOvertimesQuery request, CancellationToken cancellationToken);
        Task<ApiResponse<OvertimeDetailDto>> PostDetail(PostOvertimeCommand request);
        Task<ApiResponse<Object>> PutOvertimeDetail(PutOvertimeCommand request, CancellationToken cancellationToken);
        Task<List<OvertimeDetail>> GetByPeriodId(int id, CancellationToken cancellationToken);
        Task<ApiResponse<OvertimeDetailDto>> GetOvertimeDetailById(Guid id, CancellationToken cancellationToken);
        Task<List<OvertimeDetail>> GetByPeriodAndUserId(int PeriodId, Guid UserId, CancellationToken cancellationToken);
        Task<ApiResponse<List<OvertimeDetailDto>>> GetOvertimesDetailPendingApproval(int periodId, CancellationToken cancellationToken);
        Task<Tuple<bool, string>> CheckValideRangeDayCurrent(DateTime dateCurrent, int periodId);
        Task<Tuple<bool, string>> CheckValideRangeDay(DateTime overtimeDay, int periodId);
        Task<ApiResponse<bool>> DeleteDetail(Guid id);
        Task<List<OvertimeTempErrors>> ValidateOvertimeDetail(PutOvertimeCommand request);
        Task<ApiResponse<bool>> PutRangeOvertimeDetailCommand(PutRangeOvertimeDetailCommand request, CancellationToken cancellationToken);

        Task<bool> checkByPeriodExists(int Id);


    }
}
