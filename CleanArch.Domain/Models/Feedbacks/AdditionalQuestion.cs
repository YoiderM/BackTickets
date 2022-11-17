using Core.Models.Common;
using Core.Models.configuration;
using System;

namespace Domain.Models.Feedbacks
{
    public class AdditionalQuestion : EntityWithIntId
    {
        public string Question { get; set; }
        public Guid OriginQuestionId { get; set; }
        public Guid QuestionTypeId { get; set; }
        public Configuration QuestionType { get; set; }
        public Configuration OriginQuestion { get; set; }
        public bool Active { get; set; }
    }
}
