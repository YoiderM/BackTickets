using Application.Common.Response;
using Application.DTOs.Mekano;
using Application.Interfaces.Mekano;
using Domain.Models.Mekano;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.ResponsabilitiesCostCenter.Queries
{
    public class GetResponsabilityCostCenterByDocQuery : IRequest<ApiResponse<List<ResponsabilityCostCenterDto>>>
    { 
        public string Document { get; set; } 
    }

    public class GetResponsabilityCostCenterQueryHandler : IRequestHandler<GetResponsabilityCostCenterByDocQuery, ApiResponse<List<ResponsabilityCostCenterDto>>>
    {
        private readonly IResponsabilityCostCenterService _responsabilityCostCenterService;
        public GetResponsabilityCostCenterQueryHandler(IResponsabilityCostCenterService responsabilityCostCenterService) => _responsabilityCostCenterService = responsabilityCostCenterService;

        public async Task<ApiResponse<List<ResponsabilityCostCenterDto>>> Handle(GetResponsabilityCostCenterByDocQuery request, CancellationToken cancellationToken)
        {
            return await _responsabilityCostCenterService.Get(request.Document);
        }
    }


}
