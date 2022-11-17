using Application.DTOs.Configurations;
using Core.Models.Common;
using System;

namespace Application.DTOs.Feedbacks
{
    public class MeetingDto : EntityWithIntId
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ScheduledDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? FinalDate { get; set; }
        public Guid StatusId { get; set; }
        public ConfigurationDto Status { get; set; }
        public string SummarizeMeeting { get; set; }
        public Guid TypeMeetingId { get; set; }
        public ConfigurationDto TypeMeeting { get; set; }
    }
}
