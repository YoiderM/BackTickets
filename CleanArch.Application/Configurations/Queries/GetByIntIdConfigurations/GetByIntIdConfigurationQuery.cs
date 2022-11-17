using Application.DTOs.Configurations;
using Application.Interfaces.Configurations;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Configurations.Queries.GetByIntIdConfigurations
{
    public class GetByIntIdConfigurationQuery : IRequest<List<ConfigurationDto>> 
    {
        public int IntId { get; set; }

    }

    public class GetByIntIdConfigurationQueryHandler : IRequestHandler<GetByIntIdConfigurationQuery, List<ConfigurationDto>>
    {
        private readonly IConfigurationService _configurationService;
        public GetByIntIdConfigurationQueryHandler(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }
       
        public async Task<List<ConfigurationDto>> Handle(GetByIntIdConfigurationQuery request, CancellationToken cancellationToken)
        {
            return _configurationService.GetByIntId(request.IntId);

        }
    }
}
