using Application.Common.Response;
using Application.DTOs.Administrativeprocesses;
using Application.Interfaces.AdministrativeProcesses;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.AdministrativeProcesses.DisciplinaryProcesses.Commands
{
    public class PutResponseDisciplinaryProcessCommand :IRequest<ApiResponse<DisciplinaryProcessDto>>
    {

        public int Id { get; set; }
        //public Guid UserProcessApplicantId { get; set; }
        //public Guid userProcessAuthorizingId { get; set; }
        public Guid userProcessApprovingId { get; set; }
        public Guid? TypeOfFailureId { get; set; }
        public DateTime? StatusDate { get; set; }
        public int ProcessStatusId { get; set; }
        public string DescriptionResponseLegal { get; set; }
        public int DayOfHealing { get; set; }
        public List<IFormFile> filePdf { get; set; }
        public string LegalSupportDocument { get; set; }
        public string Email { get; set; }
        public string EmailCopy { get; set; }
    }

    public class PutResponseDisciplinaryProcessCommandCommandHandler : IRequestHandler<PutResponseDisciplinaryProcessCommand, ApiResponse<DisciplinaryProcessDto>>
    {

        private readonly IDisciplinaryProcessService _disciplinaryProcessService;
        private readonly IMapper _mapper;

        public PutResponseDisciplinaryProcessCommandCommandHandler(IDisciplinaryProcessService disciplinaryProcessService, IMapper mapper)
        {
            _disciplinaryProcessService = disciplinaryProcessService;
            _mapper = mapper;

        }
        public async Task<ApiResponse<DisciplinaryProcessDto>> Handle(PutResponseDisciplinaryProcessCommand request, CancellationToken cancellationToken)
        {
               
            return await _disciplinaryProcessService.PutProcessResponse(request, cancellationToken);
        }




    }
}
