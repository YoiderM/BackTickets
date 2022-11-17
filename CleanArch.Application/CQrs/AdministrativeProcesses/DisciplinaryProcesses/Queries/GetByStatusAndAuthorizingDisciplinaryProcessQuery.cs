using Application.Common.Response;
using Application.DTOs.Administrativeprocesses;
using Application.Interfaces.AdministrativeProcesses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.AdministrativeProcesses.DisciplinaryProcesses.Queries
{
    public class GetByStatusAndAuthorizingDisciplinaryProcessQuery : IRequest<ApiResponse<List<DisciplinaryProcessDto>>>
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int ProcessStatusId { get; set; }
    }

    public class GetByStatusAndAuthorizingDisciplinaryProcessQueryHandler : IRequestHandler<GetByStatusAndAuthorizingDisciplinaryProcessQuery, ApiResponse<List<DisciplinaryProcessDto>>>
    {
        private readonly IDisciplinaryProcessService _disciplinaryProcessService;
        private readonly IMapper _mapper;

        public GetByStatusAndAuthorizingDisciplinaryProcessQueryHandler(IDisciplinaryProcessService disciplinaryProcessService, IMapper mapper)
        {
            _disciplinaryProcessService = disciplinaryProcessService;
            _mapper = mapper;
        }
        public async Task<ApiResponse<List<DisciplinaryProcessDto>>> Handle(GetByStatusAndAuthorizingDisciplinaryProcessQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<ApiResponse<List<DisciplinaryProcessDto>>>(await _disciplinaryProcessService.GetByStatusAndAuthorizing(request, cancellationToken));
        }
    }
}
