using Domain.Models.Overtimes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.Overtimes
{
    public interface IOvertimeTempService
    {
        Task<List<OvertimeTemp>> GetOvertimesTempByUserId(Guid id);
        Task<List<OvertimeTempErrors>> GetOvertimesTempErrorsByUserId(Guid id);
        Task AddOvertimeTemp(OvertimeTemp entity);
        Task DeleteRangeOvertimeTemp(List<OvertimeTemp> overtimeTemps);
    }
}
