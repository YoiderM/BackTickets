using Application.Common.Response;
using Application.DTOs.User;
using Application.Interfaces.Rol;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.Rol.Commands
{
    public class PutStatusActivateRolById : IRequest<ApiResponse<RolDto>>
    {
        public Guid Id { get; set; }
    }

    public class PutStatusActivateRolByIdCommandHandler : IRequestHandler<PutStatusActivateRolById, ApiResponse<RolDto>>
    {
        private readonly IRolService _rolService;   

        public PutStatusActivateRolByIdCommandHandler(IRolService rolService, IMapper mapper) => _rolService = rolService;       

        public async Task<ApiResponse<RolDto>> Handle(PutStatusActivateRolById request, CancellationToken cancellationToken)
        {
            return await _rolService.PutStatusActivateRolById(request);
            
        }
    }
}
