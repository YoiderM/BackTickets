using Application.Common.Response;
using Application.DTOs.User;
using Application.Interfaces.Rol;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.Rol.Commands
{
    public class PutRolCommand : IRequest<ApiResponse<RolDto>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public bool Status { get; set; }
    }

    public class PutRolCommandHandler : IRequestHandler<PutRolCommand, ApiResponse<RolDto>>
    {
        private readonly IRolService _rolService;
        public PutRolCommandHandler(IRolService rolService) => _rolService = rolService;
     
        public async Task<ApiResponse<RolDto>> Handle(PutRolCommand request, CancellationToken cancellationToken)
        {
            return await _rolService.PutRol(request);
          
        }
    }
}
