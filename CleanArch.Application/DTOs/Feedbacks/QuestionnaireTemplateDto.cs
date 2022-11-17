namespace Application.DTOs.Feedbacks
{
    public class QuestionnaireTemplateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Footer { get; set; }
        public bool Active { get; set; }
        public int TypeAccompanimentPlanId { get; set; }
    }
}
