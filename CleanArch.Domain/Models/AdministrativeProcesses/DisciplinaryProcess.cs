using Core.Models.Common;
using Core.Models.configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models.AdministrativeProcesses
{
    public class DisciplinaryProcess : EntityWithIntId 
    {
        public int UserId { get; set; }
        public Guid  userProcessApplicantId { get; set; }
        public Guid? userProcessAuthorizingId { get; set; }
        public Guid? userProcessApprovingId { get; set; }
        public Guid? TypeOfFailureId { get; set; }
        public string Document { get; set; }
        public string Names { get; set; }
        public DateTime StatusDate { get; set; }
        public string CampaignName { get; set; }
        public string Job { get; set; }
        public string DescriptionOfTheFault { get; set; }
        public string SupportDocument { get; set; }
        public string LegalSupportDocument { get; set; }
        public string DescriptionResponseLegal { get; set; }
        public string DescriptionOfTheHealing { get; set; }
        public int DayOfHealing { get; set; }
        public DateTime? DateStartOfHealing { get; set; }
        public DateTime? DateEndOfHealing { get; set; }
        public int TypeOfFaultId { get; set; }
        public int ProcessStatusId { get; set; }
        [NotMapped]
        public int DisciplinaryProcessId { get; set; }
        public TypeOfFault TypeOfFault { get; set; }
        public ProcessStatus ProcessStatus { get; set; }   
        public Configuration TypeOfFailure { get; set; }
        public List<ProcessSupport> ProcessSupport { get; set; }
        public Domain.Models.User.User UserProcessApplicant { get; set; }
        public Domain.Models.User.User UserProcessAuthorizing { get; set; }
        public Domain.Models.User.User UserProcessApproving { get; set; }

    }
}
