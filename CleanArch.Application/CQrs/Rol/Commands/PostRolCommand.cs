using Application.Common.Response;
using Application.DTOs.User;
using Application.Interfaces.Rol;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.Rol.Commands
{
    public class PostRolCommand : IRequest<ApiResponse<RolDto>>
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public bool Status { get; set; }
    }

    public class PostRolCommandHandler : IRequestHandler<PostRolCommand, ApiResponse<RolDto>>
    {
        private readonly IRolService _rolService;  
        public PostRolCommandHandler(IRolService rolService) => _rolService = rolService;


        public async Task<ApiResponse<RolDto>> Handle(PostRolCommand request, CancellationToken cancellationToken)
        {
            return await _rolService.PostRol(request);

        }
    }

}
