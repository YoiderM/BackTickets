using Domain.Models.Overtimes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Overtimes
{
    public interface IOvertimeTempRepository
    {
        Task DeleteRange(List<OvertimeTemp> overtimeTemps);
        Task<List<OvertimeTemp>> GetOvertimesTempByUserId(Guid userId);
        Task<List<OvertimeTempErrors>> GetOvertimesTempErrorsByUserId(Guid userId);
        Task AddOvertimeTemp(OvertimeTemp entity);
    }
}
