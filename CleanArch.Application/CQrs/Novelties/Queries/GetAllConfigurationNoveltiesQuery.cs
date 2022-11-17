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
    public class GetAllConfigurationNoveltiesQuery : IRequest<ApiResponse<List<ConfigurationNoveltiesDto>>>  
    {
        public int Without { get; set; }
    }
    public class GetAllConfigurationNoveltiesQueryHandler : IRequestHandler<GetAllConfigurationNoveltiesQuery, ApiResponse<List<ConfigurationNoveltiesDto>>>
    {
        private readonly INoveltiesService _noveltiesService;
        private readonly IMapper _mapper;

        public GetAllConfigurationNoveltiesQueryHandler(INoveltiesService noveltiesService, IMapper mapper)
        {
            _noveltiesService = noveltiesService;
            _mapper = mapper;
        }

        public async Task<ApiResponse<List<ConfigurationNoveltiesDto>>> Handle(GetAllConfigurationNoveltiesQuery request, CancellationToken cancellationToken)
        {
            return await _noveltiesService.GetConfigurationNovelties(request.Without, cancellationToken);
        }
    }
}
