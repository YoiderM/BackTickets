using Application.Common.Response;
using Application.DTOs.Mekano;
using Application.Interfaces.Mekano;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.ResponsabilitiesCostCenter.Queries
{
    public class GetResponsibleCostCenterByUserQuery : IRequest<ApiResponse<List<ResponsabilityCostCenterDto>>>
    {
        
    }

    public class GetResponsibleCostCenterByUserQueryHandler : IRequestHandler<GetResponsibleCostCenterByUserQuery, ApiResponse<List<ResponsabilityCostCenterDto>>>
    {
        private readonly IResponsabilityCostCenterService _responsabilityCostCenterService;
        public GetResponsibleCostCenterByUserQueryHandler(IResponsabilityCostCenterService responsabilityCostCenterService) 
            => _responsabilityCostCenterService = responsabilityCostCenterService;

        public async Task<ApiResponse<List<ResponsabilityCostCenterDto>>> Handle(GetResponsibleCostCenterByUserQuery request, CancellationToken cancellationToken)
        {
            return await _responsabilityCostCenterService.GetAll();
        }
    }
}
