using Application.DTOs.Configurations;
using System;

namespace Application.DTOs.Feedbacks
{
    public class AdditionalQuestionDto
    {
        public string Question { get; set; }
        public bool Active { get; set; }
        public Guid QuestionTypeId { get; set; }
        public ConfigurationDto QuestionType { get; set; }
        public Guid OriginQuestionId { get; set; }
        public ConfigurationDto OriginQuestion { get; set; }
    }
}
