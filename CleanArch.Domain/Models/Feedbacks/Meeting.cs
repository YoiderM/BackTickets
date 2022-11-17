using Core.Models.Common;
using Core.Models.configuration;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Meetings
{
    public class Meeting : EntityWithIntId
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? FinalDate { get; set; }
        public Guid StatusId { get; set; }
        public string SummarizeMeeting { get; set; }
        public Guid TypeMeetingId { get; set; }
        [ForeignKey("TypeMeetingId")]
        public Configuration TypeMeeting { get; set; }
        [ForeignKey("StatusId")]
        public Configuration Status { get; set; }
    }
}
