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
    public class getAnticipatedNoveltiesQuery : IRequest<ApiResponse<List<NoveltiesOrderByTypeNoveltyDto>>>
    {
        public string NoveltyInit { get; set; }
        public int statusNovelty { get; set; }
    }
    public class getAnticipatedNoveltiesQueryHandler : IRequestHandler<getAnticipatedNoveltiesQuery, ApiResponse<List<NoveltiesOrderByTypeNoveltyDto>>>
    {
        private readonly INoveltiesService _noveltiesService;
        private readonly IMapper _mapper;
        public getAnticipatedNoveltiesQueryHandler(INoveltiesService noveltiesService, IMapper mapper)
        {
            _noveltiesService = noveltiesService;
            _mapper = mapper;
        }

        public async Task<ApiResponse<List<NoveltiesOrderByTypeNoveltyDto>>> Handle(getAnticipatedNoveltiesQuery request, CancellationToken cancellationToken)
        {
            return await _noveltiesService.GetAnticipatedNovelties(request, cancellationToken);
        }
    }
}
