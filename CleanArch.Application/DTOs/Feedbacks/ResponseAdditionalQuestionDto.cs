using Domain.Models.Feedbacks;

namespace Application.DTOs.Feedbacks
{
    public class ResponseAdditionalQuestionDto
    {
        public string Question { get; set; }
        public string Response { get; set; }
        public int ResponseAccompanimentPlanId { get; set; }
        //public ResponseAccompanimentPlan ResponseAccompanimentPlan { get; set; }
    }
}
