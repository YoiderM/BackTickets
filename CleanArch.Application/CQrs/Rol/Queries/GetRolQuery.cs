using Application.Common.Response;
using Application.DTOs.User;
using Application.Interfaces.Rol;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.Rol.Queries
{
    public class GetRolQuery : IRequest<ApiResponse<List<RolDto>>> { }
    
        public class GetRolQueryHandler : IRequestHandler<GetRolQuery, ApiResponse<List<RolDto>>>
        {
            private readonly IRolService _rolService;

            public GetRolQueryHandler(IRolService rolService) => _rolService = rolService;
            

            public async Task<ApiResponse<List<RolDto>>> Handle(GetRolQuery request, CancellationToken cancellationToken)
            {
                return await _rolService.Get();
            }
              
        }
}
