using Application.Common.Response;
using Application.DTOs.Mekano;
using Application.DTOs.Novelties;
using Application.Interfaces.Novelties;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.Novelties.Queries
{
    public class GetMekanoUsersQuery : IRequest<ApiResponse<List<MekanoUserDto>>>
    {
        public int ConstCenterId { get; set; }
    }
    public class GetMekanoUsersQueryHandler : IRequestHandler<GetMekanoUsersQuery, ApiResponse<List<MekanoUserDto>>>
    {
        private readonly INoveltiesService _noveltiesService;
        private readonly IMapper _mapper;

        public GetMekanoUsersQueryHandler(INoveltiesService noveltiesService, IMapper mapper)
        {
            _noveltiesService = noveltiesService;
            _mapper = mapper;
        }

        public async Task<ApiResponse<List<MekanoUserDto>>> Handle(GetMekanoUsersQuery request, CancellationToken cancellationToken)
        {
            return await _noveltiesService.GetMekanoUsers(request.ConstCenterId, cancellationToken);
        }
    }
}
