using Core.Models.Common;
using Core.Models.configuration;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Feedbacks
{
    public class QuestionnaireQuestionTemplate : EntityWithIntId
    {
        public string Question { get; set; }
        public Guid OriginQuestionId { get; set; }
        public Guid QuestionTypeId { get; set; }
        public bool Active { get; set; }
        public int QuestionnaireTemplateId { get; set; }
        public QuestionnaireTemplate QuestionnaireTemplate { get; set; }
        public Configuration QuestionType { get; set; }
        public Configuration OriginQuestion { get; set; }
    }
}
