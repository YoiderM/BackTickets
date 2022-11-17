using Application.Common.Response;
using Application.DTOs.Novelties;
using Application.Interfaces.Novelties;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.Novelties.Queries
{
    public class GetUsersNoveltiesQuery : IRequest<ApiResponse<List<TB_ASISTENCIA_MARCADORESDto>>>
    {
        public List<string> init { get; set; }
        public int CostCenterId { get; set; }

        public DateTime DateFilter { get; set; } 
    }

    public class GetUsersNoveltiesQueryHandler : IRequestHandler<GetUsersNoveltiesQuery, ApiResponse<List<TB_ASISTENCIA_MARCADORESDto>>>
    {
        private readonly INoveltiesService _noveltiesService;
        private readonly IMapper _mapper;
        public GetUsersNoveltiesQueryHandler(INoveltiesService noveltiesService, IMapper mapper)
        {
            _noveltiesService = noveltiesService;
            _mapper = mapper;
        }
        public async Task<ApiResponse<List<TB_ASISTENCIA_MARCADORESDto>>> Handle(GetUsersNoveltiesQuery request, CancellationToken cancellationToken)
        {
            return await _noveltiesService.GetUsers(request, cancellationToken);
        }
    }
}
