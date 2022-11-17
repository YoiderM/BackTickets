using Application.DTOs.Configurations;
using Application.Interfaces.Configurations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Configurations.Queries.GetByCategoryIdConfigurations
{
    public class GetByCategoryIdConfigurationQuery : IRequest<List<ConfigurationDto>> 
    {
        public Guid CategoryId { get; set; }
    }

    public class GetByCategoryIdConfigurationQueryHandler : IRequestHandler<GetByCategoryIdConfigurationQuery, List<ConfigurationDto>>
    {
        private readonly IConfigurationService _configurationService;
        public GetByCategoryIdConfigurationQueryHandler(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        public async Task<List<ConfigurationDto>> Handle(GetByCategoryIdConfigurationQuery request, CancellationToken cancellationToken)
        {            
            return _configurationService.GetByCategoryId(request.CategoryId);
        }
    }

}
