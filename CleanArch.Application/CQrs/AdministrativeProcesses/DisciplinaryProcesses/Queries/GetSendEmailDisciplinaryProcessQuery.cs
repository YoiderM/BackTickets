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
    public class GetSendEmailDisciplinaryProcessQuery : IRequest<bool>
    {

        public string Email { get; set; }
    }

    public class GetSendEmailDisciplinaryProcessQueryhandler : IRequestHandler<GetSendEmailDisciplinaryProcessQuery, bool>
    {
        private readonly IDisciplinaryProcessService _disciplinaryProcessService;
        private readonly IMapper _mapper;

        public GetSendEmailDisciplinaryProcessQueryhandler(IDisciplinaryProcessService disciplinaryProcessService, IMapper mapper)
        {
            _disciplinaryProcessService = disciplinaryProcessService;
            _mapper = mapper;
        }
        public async Task<bool> Handle(GetSendEmailDisciplinaryProcessQuery request, CancellationToken cancellationToken)
        {
            return await _disciplinaryProcessService.SendEmail(request, cancellationToken);
        }
    }
}
