using Core.Models.Common;

namespace Domain.Models.Feedbacks
{
    public class QuestionnaireTemplate : EntityWithIntId
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Footer { get; set; }
        public bool Active { get; set; }
        public int TypeAccompanimentPlanId { get; set; }
        public TypeAccompanimentPlan TypeAccompanimentPlan { get; set; }
    }
}
