using Application.DTOs.Configurations;
using Core.Models.Common;
using System;

namespace Application.DTOs.Feedbacks
{
    public class AccompanimentPlanDto : EntityWithIntId
    {
        public int UserId { get; set; }
        public string Document { get; set; }
        public string Names { get; set; }
        public string Job { get; set; }
        public string CampaignName { get; set; }
        public int CostCenterId { get; set; }
        public bool Active { get; set; }
        public int TypeAccompanimentPlanId { get; set; }
        public TypeAccompanimentPlanDto TypeAccompanimentPlan { get; set; }
        public Guid StatusId { get; set; }
        public ConfigurationDto Status { get; set; }

    }
}
