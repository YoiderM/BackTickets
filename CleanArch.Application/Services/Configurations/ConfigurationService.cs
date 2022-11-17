using Application.DTOs.Configurations;
using Application.Interfaces.Configurations;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Interfaces.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services.Configurations
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly IConfigurationRepository _configurationRepository;
        private readonly IMapper _mapper;

        public ConfigurationService(IConfigurationRepository configurationRepository, IMapper mapper)
        {
            _configurationRepository = configurationRepository;
            _mapper = mapper;
        }

        public List<ConfigurationDto> GetAll()
        {
            return _configurationRepository.Get()
                                       .Where(x => x.Status)
                                       .ProjectTo<ConfigurationDto>(_mapper.ConfigurationProvider)
                                       .ToList();
        }

        public List<ConfigurationDto> GetByCategoryId(Guid? categoryId)
        {

            return _configurationRepository.Get()
                                           .Where(x => x.CategoryId == categoryId && x.Status == true)
                                           .OrderBy(x => x.OrderId)
                                           .ProjectTo<ConfigurationDto>(_mapper.ConfigurationProvider)
                                           .ToList(); 
        }

        public List<ConfigurationDto> GetByIntId(int? intId)
        {
            return _configurationRepository.Get()
                                          .Where(x => x.Status && (x.IntId == intId || x.IntId == null))
                                          .ProjectTo<ConfigurationDto>(_mapper.ConfigurationProvider)
                                          .ToList();
        }

        public List<ConfigurationDto> GetByCategoryIdAndIntId(Guid? categoryId, int? intId)
        {
            return _configurationRepository.Get()
                                        .Where(x => x.Status && x.CategoryId == categoryId && (x.IntId == intId || x.IntId == null))
                                        .ProjectTo<ConfigurationDto>(_mapper.ConfigurationProvider)
                                        .ToList();
        }

      

      
    }
}
