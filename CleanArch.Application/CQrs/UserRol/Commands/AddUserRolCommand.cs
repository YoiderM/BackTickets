using Application.DTOs.User;
using Application.Interfaces.User;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.UserRol.Commands
{
    public class AddUserRolCommand : IRequest<UserRolDto>
    {    
        public Guid RolId { get; set; }
        public Guid UserId { get; set; }
        public RolDto Rol { get; set; }
        public UserDto User { get; set; }
    }

    public class AddUserRolCommandHandler : IRequestHandler<AddUserRolCommand, UserRolDto>
    {
        private readonly IUserRolService _userRolService;
        public AddUserRolCommandHandler(IUserRolService userService) => _userRolService = userService;
        public async Task<UserRolDto> Handle(AddUserRolCommand request, CancellationToken cancellationToken)
        {
            return await _userRolService.Post(request);

        }
    }
}
