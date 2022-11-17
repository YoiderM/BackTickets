using Application.Common.Response;
using Application.DTOs.User;
using Application.Interfaces.User;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.User.Commands
{
    public class PostUserCommand : IRequest<ApiResponse<UserDto>>
    {
        public string Document { get; set; }
        public string Names { get; set; }
        public string CampaignName { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public bool Active { get; set; }
        public string PassWord { get; set; }
        public string login { get; set; }
        public List<Guid> Roles { get; set; }


    }

    public class PostUserCommandHandler : IRequestHandler<PostUserCommand, ApiResponse<UserDto>>
    {
        private readonly IUserService _userService;
        private readonly IMapper _autoMapper;

        public PostUserCommandHandler(IUserService userService, IMapper autoMapper) =>
            (_userService, _autoMapper) = (userService, autoMapper);
      

        public async Task<ApiResponse<UserDto>> Handle(PostUserCommand request, CancellationToken cancellationToken )
        {          

            var ListUserRol = new List<Domain.Models.User.UserRol>() { };

            foreach (var rol in request.Roles)
            {
                ListUserRol.Add(new Domain.Models.User.UserRol()
                {
                    RolId = rol
                });
            }

            

            var userObj = _autoMapper.Map<Domain.Models.User.User>(request);
            userObj.UserRol = ListUserRol;

            return await _userService.PostUser(userObj);

        }
    }
}
