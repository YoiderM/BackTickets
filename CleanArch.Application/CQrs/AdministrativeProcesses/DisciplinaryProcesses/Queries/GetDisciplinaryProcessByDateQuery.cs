using Application.Common.Response;
using Application.DTOs.Administrativeprocesses;
using Application.Interfaces.AdministrativeProcesses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.AdministrativeProcesses.DisciplinaryProcesses.Queries
{
    public class GetDisciplinaryProcessByDateQuery : IRequest<ApiResponse<List<DisciplinaryProcessDto>>>
    {

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Status { get; set; }
    }

    public class GetDisciplinaryProcessByDateQueryHandler : IRequestHandler<GetDisciplinaryProcessByDateQuery, ApiResponse<List<DisciplinaryProcessDto>>>
    {

        private readonly IDisciplinaryProcessService _disciplinaryProcessService;
        private readonly IMapper _mapper;

        public GetDisciplinaryProcessByDateQueryHandler(IDisciplinaryProcessService disciplinaryProcessService, IMapper mapper)
        {
            _disciplinaryProcessService = disciplinaryProcessService;
            _mapper = mapper;
        }
        public async Task<ApiResponse<List<DisciplinaryProcessDto>>> Handle(GetDisciplinaryProcessByDateQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<ApiResponse<List<DisciplinaryProcessDto>>>(await _disciplinaryProcessService.GetDisciplinaryProcessByDate(request, cancellationToken));
        }
    }

}
