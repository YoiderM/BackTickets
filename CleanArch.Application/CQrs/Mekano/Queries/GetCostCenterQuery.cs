using Application.Common.Response;
using Application.DTOs.Mekano;
using Application.Interfaces.Mekano;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.Mekano.Queries
{
    public class GetCostCenterQuery : IRequest<ApiResponse<List<CostCenterDto>>>  { }

    public class GetCostCenterQueryHandler : IRequestHandler<GetCostCenterQuery, ApiResponse<List<CostCenterDto>>>
    {
        private readonly ICostCenterService _costCenterService;
        public GetCostCenterQueryHandler(ICostCenterService costCenterService) => _costCenterService = costCenterService;
      
        public async Task<ApiResponse<List<CostCenterDto>>> Handle(GetCostCenterQuery request, CancellationToken cancellationToken)
        {
            return await _costCenterService.GetCostCenter();
        }
    }
}
