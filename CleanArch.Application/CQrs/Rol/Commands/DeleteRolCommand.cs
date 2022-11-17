using Application.Common.Response;
using Application.Interfaces.Rol;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.Rol.Commands
{
    public class DeleteRolCommand : IRequest<ApiResponse<bool>>
    {
        public Guid Id { get; set; }
    }

    public class DeleteUserCommandHandler : IRequestHandler<DeleteRolCommand, ApiResponse<bool>>
    {
        private readonly IRolService _rolService;
        public DeleteUserCommandHandler(IRolService rolService) => _rolService = rolService;

        public async Task<ApiResponse<bool>> Handle(DeleteRolCommand request, CancellationToken cancellationToken)
        {
           return await _rolService.DeleteRol(request.Id);
         
        }
    }
}
