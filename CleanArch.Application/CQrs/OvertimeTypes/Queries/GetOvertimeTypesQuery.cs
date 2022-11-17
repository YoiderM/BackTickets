using Application.DTOs.OvertimePeriods;
using Application.Interfaces.Overtimes;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.OvertimeTypes.Queries
{
    public class GetOvertimeTypesQuery : IRequest<IList<OvertimeTypeDto>>
    {

    }

    public class GetOvertimeTypesQueryHandle : IRequestHandler<GetOvertimeTypesQuery, IList<OvertimeTypeDto>>
    {
        private readonly IOvertimeTypeService _overtimeTypeService;
        private readonly IMapper _mapper;
        public GetOvertimeTypesQueryHandle(IOvertimeTypeService overtimeTypeService, IMapper mapper)
        {
            _overtimeTypeService = overtimeTypeService;
            _mapper = mapper;

        }

        public async Task<IList<OvertimeTypeDto>> Handle(GetOvertimeTypesQuery request, CancellationToken cancellationToken)
        {            
            return _mapper.Map<IList<OvertimeTypeDto>>(
                await _overtimeTypeService.GetTypes(request, cancellationToken)
                );
        

        }
    }
}
