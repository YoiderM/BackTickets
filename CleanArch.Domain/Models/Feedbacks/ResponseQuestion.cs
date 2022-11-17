using Core.Models.Common;

namespace Domain.Models.Feedbacks
{
    public class ResponseQuestion : EntityWithIntId
    {
        public string Response { get; set; }
        public int QuestionnaireTemplateId { get; set; }
        public int QuestionnaireQuestionTemplateId { get; set; }
        public int ResponseAccompanimentPlanId { get; set; }
        public QuestionnaireTemplate QuestionnaireTemplate { get; set; }
        public ResponseAccompanimentPlan ResponseAccompanimentPlan { get; set; }
        public QuestionnaireQuestionTemplate QuestionnaireQuestionTemplate { get; set; }
    }
}
