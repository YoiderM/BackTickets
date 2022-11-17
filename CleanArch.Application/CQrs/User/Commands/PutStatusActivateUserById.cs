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
    public class PutStatusActivateUserById : IRequest<ApiResponse<UserDto>>
    {
        public Guid Id { get; set; }
    }

    public class PutStatusActivateUserByIdCommandHandler : IRequestHandler<PutStatusActivateUserById, ApiResponse<UserDto>>
    {
        private readonly IUserService _userService;
        private readonly IMapper _autoMapper;

        public PutStatusActivateUserByIdCommandHandler(IUserService user, IMapper autoMapper)
        {
            _userService = user;
            _autoMapper = autoMapper;
        }

        public async Task<ApiResponse<UserDto>> Handle(PutStatusActivateUserById request, CancellationToken cancellationToken)
        {  
            return _autoMapper.Map<ApiResponse<UserDto>>(await _userService.PutStatusActivateUserById(request));
        }
    }

}
