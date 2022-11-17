using Core.Models.Common;
using Core.Models.configuration;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Meetings
{
    public class TalkingPoint : EntityWithIntId
    {
        public string Description { get; set; }
        public Guid TypeTalkingPoint { get; set; }
        public Guid TalkingPointQuestionTypeId { get; set; }
        [ForeignKey("TalkingPointQuestionTypeId")]
        public Configuration TalkingPointQuestionType { get; set; }
        public int MeetingId { get; set; }
        public Meeting Meeting { get; set; }
    }
}
