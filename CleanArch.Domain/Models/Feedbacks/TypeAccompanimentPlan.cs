using Core.Models.Common;

namespace Domain.Models.Feedbacks
{
    public class TypeAccompanimentPlan : EntityWithIntId
    {
        public string Name { get; set; }
        public int Order { get; set; }
        public int NextMeetingDays { get; set; }
    }
}
