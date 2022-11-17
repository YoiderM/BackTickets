using Application.DTOs.Configurations;
using Application.DTOs.User;
using Core.Models.Common;
using System;

namespace Application.DTOs.Feedbacks
{
    public class ResponseAccompanimentPlanDto : EntityWithIntId
    {
        public string ScheduledDate { get; set; }
        public string StartDate { get; set; }
        public string FinalDate { get; set; }
        public string ConclusionsAndCommitments { get; set; }
        public int TypeAccompanimentPlanId { get; set; }
        public TypeAccompanimentPlanDto TypeAccompanimentPlan { get; set; }
        public int AccompanimentPlanId { get; set; }
        public AccompanimentPlanDto AccompanimentPlan { get; set; }
        public Guid? UserMadeAccompanimentPlanId { get; set; }
        public UserDto UserMadeAccompanimentPlan { get; set; }
        public Guid StatusId { get; set; }
        public ConfigurationDto Status { get; set; }

    }
}
