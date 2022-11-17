using Application.DTOs.Configurations;
using System;
using System.Collections.Generic;

namespace Application.Interfaces.Configurations
{
    public interface IConfigurationService
    {
        List<ConfigurationDto> GetAll();
        //test
        List<ConfigurationDto> GetByCategoryId(Guid? categoryId);
  
        List<ConfigurationDto> GetByIntId(int? intId);
        List<ConfigurationDto> GetByCategoryIdAndIntId(Guid? categoryId, int? intId);
    }
}
