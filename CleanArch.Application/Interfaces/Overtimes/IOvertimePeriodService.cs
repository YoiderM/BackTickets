using Application.Common.Response;
using Application.Cqrs.OvertimePeriods.Commands;
using Application.Cqrs.OvertimePeriods.Queries;
using Application.Cqrs.OvertimePeriods.Queries.GetPeriods;
using Application.DTOs.OvertimePeriods;
using Domain.CustomEntities;
using Domain.Models.Overtimes;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Overtimes
{
    public interface IOvertimePeriodService
    {
        Task<PaginatedList<OvertimePeriodDto>> GetPeriods(GetOvertimePeriodQuery request, CancellationToken cancellationToken);
        Task<ApiResponse<OvertimePeriodDto>> PostPeriod(CreateOvertimePeriodcommand request, CancellationToken cancellationToken);
        Task<ApiResponse<OvertimePeriodDto>>GetPeriodById(int Id);
        Task<ApiResponse<OvertimePeriodDto>> PutPeriod(UpdateOvertimePeriodCommand request);
        Task<bool> checkById(int Id);

        Task<ApiResponse<bool>> DeletePeriod(int id);

        Task<PaginatedList<OvertimePeriodDto>> GetPeriodsIsPaid(GetOvertimePeriodIspaidQuery request, CancellationToken cancellationToken);
        Task<PaginatedList<OvertimePeriodDto>> GetPeriodsIsNotPaid(GetOvertimePeriodIsNotPaidQuery request, CancellationToken cancellationToken);

    }
}
