using Application.DTOs.Configurations;
using Domain.Models.AdministrativeProcesses;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Administrativeprocesses
{
    public class DisciplinaryProcessDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Document { get; set; }
        public string Names { get; set; }
        public IFormFile filePdf { get; set; }
        public Guid userProcessApplicantId { get; set; }
        public Guid? userProcessAuthorizingId { get; set; }
        public Guid? userProcessApprovingId { get; set; }
        public Guid? TypeOfFailureId { get; set; }
        public DateTime StatusDate { get; set; }
        public string StatusDateFormat { get; set; }
        public string CampaignName { get; set; }
        public string Email { get; set; }
        public string EmailCopy { get; set; }
        public string Job { get; set; }
        public string DescriptionOfTheFault { get; set; } = "none";
        public string SupportDocument { get; set; }
        public string LegalSupportDocument { get; set; }
        public int TypeOfFaultId { get; set; }
        public int ProcessStatusId { get; set; }
        public string DescriptionResponseLegal { get; set; }
        public int DayOfHealing { get; set; }
        public DateTime? DateStartOfHealing { get; set; }
        public DateTime? DateEndOfHealing { get; set; }
        public string DescriptionOfTheHealing { get; set; }
        public string Ruta { get; set; } = "/Resources/PublicFiles/SoportesProcesoDisciplinario/";

        public int DisciplinaryProcessId { get; set; }
        public TypeOfFault TypeOfFault { get; set; }
        public ProcessStatus ProcessStatus { get; set; }
        public ConfigurationDto TypeOfFailure { get; set; }
        public List<ProcessSupport> ProcessSupport { get; set; }
        public Domain.Models.User.User UserProcessApplicant { get; set; }
        public Domain.Models.User.User UserProcessAuthorizing { get; set; }
        public Domain.Models.User.User UserProcessApproving { get; set; }

    }
}
