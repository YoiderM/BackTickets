using CleanArch.Infra.Data.Context;
using Domain.Interfaces.Overtimes;
using Domain.Models.Overtimes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Data.Repository.Overtimes
{
    public class OvertimeTempRepository : IOvertimeTempRepository
    {
        private U27ApplicationDBContext _ctx;

        public OvertimeTempRepository(U27ApplicationDBContext ctx) => _ctx = ctx;

        public async Task DeleteRange(List<OvertimeTemp> overtimeTemps)
        {
            _ctx.OvertimeTemps.RemoveRange(overtimeTemps);
            await _ctx.SaveChangesAsync();

        }

        public async Task<List<OvertimeTemp>> GetOvertimesTempByUserId(Guid userId)
        {
            return await _ctx.OvertimeTemps.Where(x => x.CreatedBy == userId).ToListAsync();
        }

        public async Task AddOvertimeTemp(OvertimeTemp entity)
        {
            _ctx.Add(entity);
            await _ctx.SaveChangesAsync();

        }

        public async Task<List<OvertimeTempErrors>> GetOvertimesTempErrorsByUserId(Guid userId)
        {  
            return await _ctx.OvertimeTempErrors.FromSqlRaw("EXECUTE dbo.P_validateOvertimesTemps {0}", userId).ToListAsync();            
        }

    }
}
