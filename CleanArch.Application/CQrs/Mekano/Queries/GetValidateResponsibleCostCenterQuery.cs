using Application.Common.Response;
using Application.Interfaces.Mekano;
using Domain.Models.Mekano;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.Mekano.Queries
{
    public class GetValidateResponsibleCostCenterQuery :IRequest<ApiResponse<bool>>
    {
        public string Document { get; set; }
        public int CostCenterUserId { get; set; }

    }

    public class GetValidateResponsibleCostCenterQueryHandler : IRequestHandler<GetValidateResponsibleCostCenterQuery, ApiResponse<bool>>
    {
        private readonly IMekanoUserService _mekanoUserService;
        public GetValidateResponsibleCostCenterQueryHandler(IMekanoUserService mekanoUserService)
        {
            _mekanoUserService = mekanoUserService;

        }
       
        public async Task<ApiResponse<bool>> Handle(GetValidateResponsibleCostCenterQuery request, CancellationToken cancellationToken)
        {
            return await _mekanoUserService.GetValidateResponsibleCostCenter(request.CostCenterUserId);
        }
    }
}
