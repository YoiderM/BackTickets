using System.Collections.Generic;

namespace Application.DTOs.Feedbacks
{
    public class ResponseQuestionAndResponseAdditionalDto
    {
        public List<ResponseQuestionAndQuestionnaireDto> ResponseQuestion { get; set; }
        public List<ResponseAdditionalQuestionDto> ResponseAdditionalQuestion { get; set; }
    }
}
