using Application.Common.Response;
using Application.DTOs.User;
using Application.Interfaces.User;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.User.Commands
{
    public class PutStatusDeactivateUserById : IRequest<ApiResponse<UserDto>>
    {
        public Guid Id { get; set; }
    }

    public class PutStatusDeactivateUserByIdCommandHandler : IRequestHandler<PutStatusDeactivateUserById, ApiResponse<UserDto>>
    {
        private readonly IUserService _userService;
        private readonly IMapper _autoMapper;

        public PutStatusDeactivateUserByIdCommandHandler(IUserService userService, IMapper autoMapper) =>
            (_userService, _autoMapper) = (userService, autoMapper);
      

        public async Task<ApiResponse<UserDto>> Handle(PutStatusDeactivateUserById request, CancellationToken cancellationToken)
        {          
            return _autoMapper.Map<ApiResponse<UserDto>>(await _userService.PutStatusDeactivateUserById(request));

        }
    }

}
