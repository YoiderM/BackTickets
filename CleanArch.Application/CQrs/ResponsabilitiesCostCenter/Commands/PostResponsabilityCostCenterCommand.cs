using Application.Common.Response;
using Application.DTOs.Mekano;
using Application.Interfaces.Mekano;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.ResponsabilitiesCostCenter.Commands
{
    public class PostResponsabilityCostCenterCommand : IRequest<ApiResponse<ResponsabilityCostCenterDto>>
    {
        public Guid UserId { get; set; }
        public int CostCenterId { get; set; }
      
    }

  
    public class PostResponsabilityCostCenterCommandHandler : IRequestHandler<PostResponsabilityCostCenterCommand, ApiResponse<ResponsabilityCostCenterDto>>
    {

		private readonly IResponsabilityCostCenterService _responsabilityCostCenterService;	

        public PostResponsabilityCostCenterCommandHandler(IResponsabilityCostCenterService responsabilityCostCenterService)
        {
		
			_responsabilityCostCenterService = responsabilityCostCenterService;

		}

      
        public async Task<ApiResponse<ResponsabilityCostCenterDto>> Handle(PostResponsabilityCostCenterCommand request, CancellationToken cancellationToken)
        {  

            return await _responsabilityCostCenterService.PostResponsability(request, cancellationToken);

        }
    }
   
		

}
