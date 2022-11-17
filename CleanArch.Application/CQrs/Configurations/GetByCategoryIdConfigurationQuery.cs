using Application.DTOs.Configurations;
using Application.Interfaces.Configurations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.Configurations
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
