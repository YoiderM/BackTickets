namespace Application.DTOs.Feedbacks
{
    public class ResponseQuestionAndQuestionnaireDto
    {
        public string Response { get; set; }
        public int QuestionnaireTemplateId { get; set; }
        public QuestionnaireTemplateDto QuestionnaireTemplate { get; set; }
        public int QuestionnaireQuestionTemplateId { get; set; }
        public QuestionnaireQuestionTemplateDto QuestionnaireQuestionTemplate { get; set; }
        public int ResponseAccompanimentPlanId { get; set; }
        public ResponseAccompanimentPlanDto ResponseAccompanimentPlan { get; set; }
    }
}
