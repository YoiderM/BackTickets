using Application.Core.Exceptions;
using Application.DTOs.Configurations;
using Application.Interfaces.Configurations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Configurations.Queries.GetAllConfigurations
{
    public class GetAllConfigurationQuery : IRequest<List<ConfigurationDto>> {
        public Guid? CategoryId { get; set; }
        public int? IntId { get; set; }

    }

	public class GetAllConfigurationQueryHandler : IRequestHandler<GetAllConfigurationQuery, List<ConfigurationDto>>
    {
        private readonly IConfigurationService _configurationService;
        public GetAllConfigurationQueryHandler(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        public async  Task<List<ConfigurationDto>> Handle(GetAllConfigurationQuery request, CancellationToken cancellationToken)
        {
            if (request.CategoryId == null && request.IntId == null)
            {
                return await Task.Run(() => _configurationService.GetAll());

            }
            else if (request.CategoryId != null && request.IntId != null)
            {
                return _configurationService.GetByCategoryIdAndIntId(request.CategoryId, request.IntId);

            }
            else if (request.CategoryId != null && request.IntId == null)
            {
                return _configurationService.GetByCategoryId(request.CategoryId);

            }
            else if(request.CategoryId == null && request.IntId != null)
            {
                return _configurationService.GetByIntId(request.IntId);

            }
            else
            {
                throw new NotFoundException("Configuration", request.CategoryId);
            }

        }
    }

}
