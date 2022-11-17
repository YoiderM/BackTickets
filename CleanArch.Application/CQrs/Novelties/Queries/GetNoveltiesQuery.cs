using Application.Common.Response;
using Application.DTOs.Novelties;
using Application.Interfaces.Novelties;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.Novelties.Queries
{
    public class getNoveltiesQuery : IRequest<ApiResponse<List<NoveltyEntryQueryDto>>>
    {
        public int configurationNoveltyId { get; set; }
    }
    public class getNoveltiesQueryHandler : IRequestHandler<getNoveltiesQuery, ApiResponse<List<NoveltyEntryQueryDto>>>
    {
        private readonly INoveltiesService _noveltiesService;
        private readonly IMapper _mapper;
        public getNoveltiesQueryHandler(INoveltiesService noveltiesService, IMapper mapper)
        {
            _noveltiesService = noveltiesService;
            _mapper = mapper;
        }

        public async Task<ApiResponse<List<NoveltyEntryQueryDto>>> Handle(getNoveltiesQuery request, CancellationToken cancellationToken)
        {
            return await _noveltiesService.getAnticipatedNoveltiesQuery(request, cancellationToken);
        }
    }
}
