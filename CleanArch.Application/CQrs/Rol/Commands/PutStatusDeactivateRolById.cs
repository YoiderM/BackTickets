using Application.Common.Response;
using Application.DTOs.User;
using Application.Interfaces.Rol;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.Rol.Commands
{
    public class PutStatusDeactivateRolById : IRequest<ApiResponse<RolDto>>
    {
        public Guid Id { get; set; }
    }

    public class PutStatusDeactivateRolByIdCommandHandler : IRequestHandler<PutStatusDeactivateRolById, ApiResponse<RolDto>>
    {
        private readonly IRolService _rolService;
      

        public PutStatusDeactivateRolByIdCommandHandler(IRolService rolService) => _rolService = rolService;  

        public async Task<ApiResponse<RolDto>> Handle(PutStatusDeactivateRolById request, CancellationToken cancellationToken)
        {
            return await _rolService.PutStatusDeactivateRolById(request);
        }
    }
}
