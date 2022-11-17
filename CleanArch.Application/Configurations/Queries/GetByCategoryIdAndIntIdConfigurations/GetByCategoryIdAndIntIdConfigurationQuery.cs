using Application.DTOs.Configurations;
using Application.Interfaces.Configurations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Configurations.Queries.GetByCategoryIdAndIntIdConfigurations
{
    public class GetByCategoryIdAndIntIdConfigurationQuery : IRequest<List<ConfigurationDto>>
    {
        public Guid CategoryId { get; set; }
        public int IntId { get; set; }
    }

    public class GetByCategoryIdAndIntIdConfigurationQueryHandler : IRequestHandler<GetByCategoryIdAndIntIdConfigurationQuery, List<ConfigurationDto>>
    {
        private readonly IConfigurationService _configurationService;
        public GetByCategoryIdAndIntIdConfigurationQueryHandler(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        public async Task<List<ConfigurationDto>> Handle(GetByCategoryIdAndIntIdConfigurationQuery request, CancellationToken cancellationToken)
        {
            return _configurationService.GetByCategoryIdAndIntId(request.CategoryId, request.IntId);

        }
    }
}
