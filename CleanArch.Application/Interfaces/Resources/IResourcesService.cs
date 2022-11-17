using Application.Common.Response;
using Application.Cqrs.Resources.Commands;
using Application.DTOs.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Resources
{
    public interface IResourcesService
    {
        Task<ApiResponse<ResourcesDto>> PostByNovelty(PostByNoveltyResourcesCommand request, CancellationToken cancellationtoken);
    }
}
