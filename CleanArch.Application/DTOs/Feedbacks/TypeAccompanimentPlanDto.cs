using Core.Models.Common;

namespace Application.DTOs.Feedbacks
{
    public class TypeAccompanimentPlanDto : EntityWithIntId
    {
        public string Name { get; set; }
        public int Order { get; set; }
        public int NextMeetingDays { get; set; }
    }
}
