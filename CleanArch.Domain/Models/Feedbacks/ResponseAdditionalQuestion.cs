using Core.Models.Common;

namespace Domain.Models.Feedbacks
{
    public class ResponseAdditionalQuestion : EntityWithIntId
    {
        public string Question { get; set; }
        public string Response { get; set; }
        public int ResponseAccompanimentPlanId { get; set; }
        public ResponseAccompanimentPlan ResponseAccompanimentPlan { get; set; }
    }
}
