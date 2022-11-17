using Application.Common.Response;
using Application.DTOs.Mekano;
using Application.Interfaces.Mekano;
using Application.Interfaces.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.ResponsabilitiesCostCenter.Queries
{
    public class GetUserResponsabilityCostCenterQuery : IRequest<ApiResponse<List<UserResponsabilityCostCenterDto>>>
    {
    }
    public class GetUserResponsabilityCostCenterQueryHandler : IRequestHandler<GetUserResponsabilityCostCenterQuery, ApiResponse<List<UserResponsabilityCostCenterDto>>>
    {
        private readonly IUserService _userService;
        public GetUserResponsabilityCostCenterQueryHandler(IUserService userService) => _userService = userService;

        public async Task<ApiResponse<List<UserResponsabilityCostCenterDto>>> Handle(GetUserResponsabilityCostCenterQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetUserByCostCenter();
        }
    }
}
