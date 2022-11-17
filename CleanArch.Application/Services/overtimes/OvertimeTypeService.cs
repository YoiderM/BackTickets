using Application.Interfaces.Overtimes;
using Domain.Interfaces;
using Domain.Models.Overtimes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Application.Cqrs.OvertimeTypes.Queries;
using Application.DTOs.OvertimePeriods;
using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace Application.Services.Overtimes
{
    public class OvertimeTypeService : IOvertimeTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public OvertimeTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;


    }

      

        public async Task<IList<OvertimeTypeDto>> GetTypes(GetOvertimeTypesQuery request, CancellationToken cancellationToken)
        {
            //var source = await _unitOfWork.overtimeType.Get().ToListAsync();


            
            return await _unitOfWork.overtimeType
                    .Get()
                    .ProjectTo<OvertimeTypeDto>(_mapper.ConfigurationProvider).ToListAsync();

        }

        public async Task<bool> checkById(Guid id)
        {
            return await _unitOfWork.overtimeType
               .Get().CountAsync(x => x.Id == id) > 0 ? true : false;
        }

        public async Task<string> GetOvertimeTypeNameById(Guid id)
        {
            return await _unitOfWork.overtimeType.Get()
                                                 .Where(x => x.Id == id)
                                                 .Select(x => x.Name)
                                                 .FirstOrDefaultAsync();                                            
              
        }
    }
}
