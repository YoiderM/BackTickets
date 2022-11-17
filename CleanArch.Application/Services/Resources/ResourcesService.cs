using Application.Common.Response;
using Application.Cqrs.Resources.Commands;
using Application.DTOs.Resources;
using Application.Interfaces.Resources;
using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Resources
{
    public class ResourcesService : IResourcesService
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private ICurrentUserService _currentUserService;
        private readonly IUnitOfWork _unitOfWork;

        public ResourcesService(IMapper mapper, ILogger<ResourcesService> logger, IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
        {
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;
            _currentUserService = currentUserService;
        }

        public async Task<ApiResponse<ResourcesDto>> PostByNovelty(PostByNoveltyResourcesCommand request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<ResourcesDto>();
            try
            {
                ResourcesDto resourcesDto = new ResourcesDto();

                resourcesDto.Extension = Path.GetExtension(request.File.FileName);

                resourcesDto.Type = "Novelty";

                resourcesDto.Name = Path.GetFileName(request.File.FileName);

                var guidGen = Guid.NewGuid().ToString();

                string nameFile = guidGen + resourcesDto.Extension;

                var ruteToSavePDF = Path.Combine(@"Resources/PublicFiles/Novelties/", nameFile);

                resourcesDto.URL = Path.Combine("http://172.16.5.155:51121/", ruteToSavePDF);

                var fileUrl = new FileStream(ruteToSavePDF, FileMode.CreateNew);
                await request.File.CopyToAsync(fileUrl);
                fileUrl.Close();
                fileUrl.Dispose();

                resourcesDto.NoveltyEntryId = request.NoveltyEntryId;

                response.Data = _mapper.Map<ResourcesDto>(await _unitOfWork.ResourcesRepository.Add(_mapper.Map<Domain.Models.Resources.Resources>(resourcesDto)));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al consultar el registro, NoveltiesService en el método Get, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al consultar el registro, consulte con el administrador. { ex.Message } ";
            }
            return response;
        }
    }
}
