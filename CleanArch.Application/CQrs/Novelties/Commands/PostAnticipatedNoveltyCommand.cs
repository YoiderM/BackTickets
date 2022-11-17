using Application.Common.Response;
using Application.DTOs.Novelties;
using Application.Interfaces.Novelties;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.Novelties.Commands
{
    public class PostAnticipatedNoveltyCommand : IRequest<ApiResponse<NoveltyEntryDto>>
    {
        public AnticipatedNoveltyEntryCommandDto novelty { get; set; }
    }
    public class PostAnticipatedNoveltyCommandHandler : IRequestHandler<PostAnticipatedNoveltyCommand, ApiResponse<NoveltyEntryDto>>
    {
        private readonly INoveltiesService _noveltiesService;
        private readonly IMapper _mapper;
        public PostAnticipatedNoveltyCommandHandler(INoveltiesService noveltiesService, IMapper mapper)
        {
            _noveltiesService = noveltiesService;
            _mapper = mapper;
        }

        public async Task<ApiResponse<NoveltyEntryDto>> Handle(PostAnticipatedNoveltyCommand request, CancellationToken cancellationToken)
        {
            return await _noveltiesService.PostAnticipatedNovelties(request, cancellationToken);
        }
    }
}
