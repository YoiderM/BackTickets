using Application.Common.Response;
using Application.DTOs.Administrativeprocesses;
using Application.Interfaces.AdministrativeProcesses;
using Domain.Models.AdministrativeProcesses;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.AdministrativeProcesses.DisciplinaryProcesses.Commands
{
    public class PostDisciplinaryProcessCommand :IRequest<ApiResponse<DisciplinaryProcessDto>>
    {
        public int UserId { get; set; }
        public Guid userProcessApplicantId { get; set; }
        public string Document { get; set; }
        public string Names { get; set; }
        public DateTime StatusDate { get; set; }
        public string CampaignName { get; set; }
        public string Email { get; set; }
        public string EmailCopy { get; set; }      
        public string Job { get; set; }
        public List<IFormFile> filePdf { get; set; }
        public string DescriptionOfTheFault { get; set; }
        public string SupportDocument { get; set; }
        public string LegalSupportDocument { get; set; }
        public int TypeOfFaultId { get; set; }
        public int ProcessStatusId { get; set; }
        
    }

   
    public class PostDisciplinaryProcessCommandhandler : IRequestHandler<PostDisciplinaryProcessCommand, ApiResponse<DisciplinaryProcessDto>>
    {
        private readonly IDisciplinaryProcessService _disciplinaryProcessService;


        public PostDisciplinaryProcessCommandhandler(IDisciplinaryProcessService disciplinaryProcessService)
        {
            _disciplinaryProcessService = disciplinaryProcessService;

        }
        public async Task<ApiResponse<DisciplinaryProcessDto>> Handle(PostDisciplinaryProcessCommand request, CancellationToken cancellationToken)
        {
            return await _disciplinaryProcessService.PostDisciplinary(request, cancellationToken);
        }
    }
}
