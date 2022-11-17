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
    public class PutUserCommand : IRequest<ApiResponse<UserDto>>
    {
        public Guid Id { get; set; }
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

    public class PutUserCommandHandler : IRequestHandler<PutUserCommand, ApiResponse<UserDto>>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public PutUserCommandHandler(IUserService userService, IMapper mapper) =>
            (_userService, _mapper) = (userService, mapper);
     

        public async Task<ApiResponse<UserDto>> Handle(PutUserCommand request, CancellationToken cancellationToken)
        {  
            return await _userService.PutUser(request);         
        }
    }
}
