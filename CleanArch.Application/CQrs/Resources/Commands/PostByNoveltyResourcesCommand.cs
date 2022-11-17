using Application.Common.Response;
using Application.DTOs.Resources;
using Application.Interfaces.Resources;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.Resources.Commands
{
    public class PostByNoveltyResourcesCommand : IRequest<ApiResponse<ResourcesDto>>
    {
        public IFormFile File { get; set; }
        public Guid NoveltyEntryId { get; set; }
    }
    public class PostByNoveltyResourcesCommandHandler : IRequestHandler<PostByNoveltyResourcesCommand, ApiResponse<ResourcesDto>>
    {
        private readonly IResourcesService _resourcesService;
        private readonly IMapper _mapper;

        public PostByNoveltyResourcesCommandHandler(IResourcesService resourcesService, IMapper mapper)
        {
            _resourcesService = resourcesService;
            _mapper = mapper;
        }
        public async Task<ApiResponse<ResourcesDto>> Handle(PostByNoveltyResourcesCommand request, CancellationToken cancellationToken)
        {
            return await _resourcesService.PostByNovelty(request, cancellationToken);
        }
    }
}
