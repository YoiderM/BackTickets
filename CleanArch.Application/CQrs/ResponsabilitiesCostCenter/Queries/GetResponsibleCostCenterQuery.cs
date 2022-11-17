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
   public class GetResponsibleCostCenterQuery : IRequest<ApiResponse<List<ResponsabilityCostCenterDto>>>
    {

    }
    public class GetResponsibleCostCenterQueryHandler : IRequestHandler<GetResponsibleCostCenterQuery, ApiResponse<List<ResponsabilityCostCenterDto>>>
    {
        private readonly IResponsabilityCostCenterService _responsabilityCostCenterService;
        public GetResponsibleCostCenterQueryHandler(IResponsabilityCostCenterService responsabilityCostCenterService) => _responsabilityCostCenterService = responsabilityCostCenterService;

        public async Task<ApiResponse<List<ResponsabilityCostCenterDto>>> Handle(GetResponsibleCostCenterQuery request, CancellationToken cancellationToken)
        {
            return await _responsabilityCostCenterService.GetAll();
        }
    }
}
