using Core.Models.Common;

namespace Domain.Models.Meetings
{
    public class QuestionnaireTemplateTypeAccompanimentPlan : EntityWithIntId
    {
        public int QuestionnaireTemplateId { get; set; }
        public int TypeAccompanimentPlanId { get; set; }
        public QuestionnaireTemplate QuestionnaireTemplate { get; set; }
        public TypeAccompanimentPlan TypeAccompanimentPlan { get; set; }
    }
}
