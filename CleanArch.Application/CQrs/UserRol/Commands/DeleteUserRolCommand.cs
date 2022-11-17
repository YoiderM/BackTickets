using Application.Interfaces.User;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.UserRol.Commands
{
    public class DeleteUserRolCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }


    public class DeleteConfigurationCommandHandler : IRequestHandler<DeleteUserRolCommand, bool>
    {

        private readonly IUserRolService _userRolService;

        public DeleteConfigurationCommandHandler(IUserRolService userRolService) => _userRolService = userRolService;

        public async Task<bool> Handle(DeleteUserRolCommand request, CancellationToken cancellationToken)
        {
            return await _userRolService.Delete(request.Id);

        }
    }
}
