using Core.Models.Common;
using Core.Models.configuration;
using System;

namespace Domain.Models.Feedbacks
{
    public class AccompanimentPlan : EntityWithIntId
    {
        public int UserId { get; set; }
        public string Document { get; set; }
        public string Names { get; set; }
        public string Job { get; set; }
        public string CampaignName { get; set; }
        public int CostCenterId { get; set; }
        public Guid StatusId { get; set; }
        public bool Active { get; set; }
        public int TypeAccompanimentPlanId { get; set; }
        public TypeAccompanimentPlan TypeAccompanimentPlan { get; set; }
        public Configuration Status { get; set; }
    }
}

