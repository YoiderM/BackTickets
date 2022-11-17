using Application.Cqrs.OvertimeTypes.Queries;
using Application.DTOs.OvertimePeriods;
using Domain.Models.Overtimes;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Overtimes
{
    public interface IOvertimeTypeService
    {
        Task<IList<OvertimeTypeDto>> GetTypes(GetOvertimeTypesQuery request, CancellationToken cancellationToken);
        Task<bool> checkById(Guid id);
        Task<string> GetOvertimeTypeNameById(Guid id);

    }
}
