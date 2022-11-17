using Core.Models.Common;
using Core.Models.configuration;
using System;

namespace Domain.Models.Feedbacks
{
    public class ResponseAccompanimentPlan : EntityWithIntId
    {
        public int TypeAccompanimentPlanId { get; set; }
        public int AccompanimentPlanId { get; set; }
        public DateTime? ScheduledDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? FinalDate { get; set; }
        public string ConclusionsAndCommitments { get; set; }
        public Guid? UserMadeAccompanimentPlanId { get; set; }
        public Guid StatusId { get; set; }
        public TypeAccompanimentPlan TypeAccompanimentPlan { get; set; }
        public AccompanimentPlan AccompanimentPlan { get; set; }
        public Domain.Models.User.User UserMadeAccompanimentPlan { get; set; }
        public Configuration Status { get; set; }
    }
}
