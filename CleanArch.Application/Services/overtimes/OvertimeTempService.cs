using Application.Interfaces.Overtimes;
using Domain.Interfaces;
using Domain.Interfaces.Overtimes;
using Domain.Models.Overtimes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services.overtimes
{
    public class OvertimeTempService : IOvertimeTempService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOvertimeTempRepository _overtimeTempRepository;
        public OvertimeTempService(IUnitOfWork unitOfWork, IOvertimeTempRepository overtimeTempRepository)
        {
            _unitOfWork = unitOfWork;
            _overtimeTempRepository = overtimeTempRepository;
        }
        public async Task AddOvertimeTemp(OvertimeTemp entity)
        {
           await _overtimeTempRepository.AddOvertimeTemp(entity);
        }

        public async Task DeleteRangeOvertimeTemp(List<OvertimeTemp> overtimeTemps)
        {
            await _overtimeTempRepository.DeleteRange(overtimeTemps);
        }

        public async Task<List<OvertimeTemp>> GetOvertimesTempByUserId(Guid id)
        {
            return await _overtimeTempRepository.GetOvertimesTempByUserId(id);
           
         
        }

        public async Task<List<OvertimeTempErrors>> GetOvertimesTempErrorsByUserId(Guid id)
        {
            return await _overtimeTempRepository.GetOvertimesTempErrorsByUserId(id);       
         
        }

        
    }
}
