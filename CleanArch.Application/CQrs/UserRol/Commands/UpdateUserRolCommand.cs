using Application.DTOs.User;
using Application.Interfaces.User;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.UserRol.Commands
{
    public class UpdateUserRolCommand : IRequest<UserRolDto>
    {
        public Guid Id { get; set; }
        public Guid RolId { get; set; }
        public Guid UserId { get; set; }
        public RolDto Rol { get; set; }
        public UserDto User { get; set; }
    }

    public class UpdateUserRolCommandHandler : IRequestHandler<UpdateUserRolCommand, UserRolDto>
    {
        private readonly IUserRolService _userRolService;
        public UpdateUserRolCommandHandler(IUserRolService userService) => _userRolService = userService;
        public async Task<UserRolDto> Handle(UpdateUserRolCommand request, CancellationToken cancellationToken)
        {
            return await _userRolService.Put(request);

        }
    }
}
