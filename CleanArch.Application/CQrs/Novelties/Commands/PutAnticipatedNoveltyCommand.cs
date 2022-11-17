using Application.Common.Response;
using Application.DTOs.Novelties;
using Application.Interfaces.Novelties;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.Novelties.Commands
{
    public class PutAnticipatedNoveltyCommand : IRequest<ApiResponse<NoveltyEntryDto>>
    {
        public Guid IdNovelty { get; set; }
        public int ProcessStatusId { get; set; }
        public string Observation { get; set; }
    }
    public class PutAnticipatedNoveltyCommandHandler : IRequestHandler<PutAnticipatedNoveltyCommand, ApiResponse<NoveltyEntryDto>>
    {
        private readonly INoveltiesService _noveltiesService;
        private readonly IMapper _mapper;
        public PutAnticipatedNoveltyCommandHandler(INoveltiesService noveltiesService, IMapper mapper)
        {
            _noveltiesService = noveltiesService;
            _mapper = mapper;
        }

        public async Task<ApiResponse<NoveltyEntryDto>> Handle(PutAnticipatedNoveltyCommand request, CancellationToken cancellationToken)
        {
            return await _noveltiesService.PutStatusAprobationNovelty(request, cancellationToken);
        }
    }
}
