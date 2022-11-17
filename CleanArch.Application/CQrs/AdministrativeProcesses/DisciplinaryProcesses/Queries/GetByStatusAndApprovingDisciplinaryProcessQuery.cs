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
    public class GetByStatusAndApprovingDisciplinaryProcessQuery : IRequest<ApiResponse<List<DisciplinaryProcessDto>>>
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int ProcessStatusId { get; set; }
    }

    public class GetByStatusAndApprovingDisciplinaryProcessQueryhandler : IRequestHandler<GetByStatusAndApprovingDisciplinaryProcessQuery, ApiResponse<List<DisciplinaryProcessDto>>>
    {
        private readonly IDisciplinaryProcessService _disciplinaryProcessService;
        private readonly IMapper _mapper;

        public GetByStatusAndApprovingDisciplinaryProcessQueryhandler(IDisciplinaryProcessService disciplinaryProcessService, IMapper mapper)
        {
            _disciplinaryProcessService = disciplinaryProcessService;
            _mapper = mapper;
        }
        public async Task<ApiResponse<List<DisciplinaryProcessDto>>> Handle(GetByStatusAndApprovingDisciplinaryProcessQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<ApiResponse<List<DisciplinaryProcessDto>>>(await _disciplinaryProcessService.GetByStatusAndApproving(request, cancellationToken));
        }
    }
}
