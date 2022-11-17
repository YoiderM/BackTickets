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

namespace Application.Cqrs.AdministrativeProcesses.DisciplinaryProcesses.Commands
{
    public class PutDisciplinaryProcessCommand :IRequest<ApiResponse<DisciplinaryProcessDto>>
    {
        public int Id { get; set; }
        //public Guid UserProcessApplicantId { get; set; }
        public Guid userProcessAuthorizingId { get; set; }
        public Guid userProcessApprovingId { get; set; }
        public DateTime StatusDate { get; set; }
        public int ProcessStatusId { get; set; }
        public DateTime? DateStartOfHealing { get; set; }
        public DateTime? DateEndOfHealing { get; set; }
        public string DescriptionOfTheHealing { get; set; }
        public string Email { get; set; }
        public string EmailCopy { get; set; }

    }

    public class PutDisciplinaryProcessCommandhandler : IRequestHandler<PutDisciplinaryProcessCommand, ApiResponse<DisciplinaryProcessDto>>
    {

        private readonly IDisciplinaryProcessService _disciplinaryProcessService;
        private readonly IMapper _mapper;

        public PutDisciplinaryProcessCommandhandler(IDisciplinaryProcessService disciplinaryProcessService, IMapper mapper)
        {
            _disciplinaryProcessService = disciplinaryProcessService;
            _mapper = mapper;

        }
        public async Task<ApiResponse<DisciplinaryProcessDto>> Handle(PutDisciplinaryProcessCommand request, CancellationToken cancellationToken)
        {

            return await _disciplinaryProcessService.PutProcess(request, cancellationToken);
   
        }
    }
}
