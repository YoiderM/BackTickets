using Domain.Models.Feedbacks;

namespace Application.DTOs.Feedbacks
{
    public class ResponseQuestionDto
    {
        public string Response { get; set; }
        public int QuestionnaireTemplateId { get; set; }
        public int QuestionnaireQuestionTemplateId { get; set; }
        public int ResponseAccompanimentPlanId { get; set; }
    }
}
