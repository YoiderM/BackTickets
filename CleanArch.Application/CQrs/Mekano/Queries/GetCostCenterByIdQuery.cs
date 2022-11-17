using Application.Common.Response;
using Application.DTOs.Mekano;
using Application.Interfaces.Mekano;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.Mekano.Queries
{
    public class GetCostCenterByIdQuery : IRequest<ApiResponse<CostCenterDto>>
    {   
        public int Id { get; set; }
       
    }

    public class GetCostcenterByIdHandle : IRequestHandler<GetCostCenterByIdQuery, ApiResponse<CostCenterDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICostCenterService  _costCenterService;

        public GetCostcenterByIdHandle(ICostCenterService costCenterService, IMapper mapper)
        {
            _costCenterService = costCenterService;
            _mapper = mapper;
        }

        public async Task<ApiResponse<CostCenterDto>> Handle(GetCostCenterByIdQuery request, CancellationToken cancellationToken)
        {
            //return _mapper.Map<ApiResponse<CostCenterDto>>(await _costCenterService.GetById(request.Id));
            return await _costCenterService.GetById(request.Id);
        }
    }
}
