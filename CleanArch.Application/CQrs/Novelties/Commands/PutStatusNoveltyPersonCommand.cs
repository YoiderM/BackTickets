using Application.Common.Response;
using Application.DTOs.Novelties;
using Application.Interfaces.Novelties;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.Novelties.Commands
{
    public class PutStatusNoveltyPersonCommand : IRequest<ApiResponse<TB_ASISTENCIA_MARCADORESDto>>
    {
        public int TB_ASISTENCIA_MARCADORESId { get; set; }
        public int ConfigurationNoveltyId { get; set; }
        public string Description { get; set; }
        public DateTime? DateStartTime { get; set; }
    }
    public class PutStatusNoveltyPersonCommandHandler : IRequestHandler<PutStatusNoveltyPersonCommand, ApiResponse<TB_ASISTENCIA_MARCADORESDto>>
    {
        private readonly INoveltiesService _noveltiesService;
        private readonly IMapper _mapper;

        public PutStatusNoveltyPersonCommandHandler(INoveltiesService noveltiesService, IMapper mapper)
        {
            _mapper = mapper;
            _noveltiesService = noveltiesService;
        }

        public async Task<ApiResponse<TB_ASISTENCIA_MARCADORESDto>> Handle(PutStatusNoveltyPersonCommand request, CancellationToken cancellationToken)
        {
            return await _noveltiesService.PutStatusNoveltyPerson(request, cancellationToken);
        }
    }
}
