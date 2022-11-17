using Application.DTOs.Configurations;
using Core.Models.Common;
using System;

namespace Application.DTOs.Feedbacks
{
    public class QuestionnaireQuestionTemplateDto : EntityWithIntId
    {
        public string Question { get; set; }
        public bool Active { get; set; }
        public int QuestionnaireTemplateId { get; set; }
        public QuestionnaireTemplateDto QuestionnaireTemplate { get; set; }
        public Guid QuestionTypeId { get; set; }
        public ConfigurationDto QuestionType { get; set; }
        public Guid OriginQuestionId { get; set; }
        public ConfigurationDto OriginQuestion { get; set; }
    }
}
