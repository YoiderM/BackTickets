using Application.Interfaces.Feedbacks;
using FluentValidation;

namespace Application.Cqrs.Feedbacks.ResponseQuestion.Commands
{
    public class PostResponseAdditionalQuestionCommandValidator : AbstractValidator<PostResponseQuestionCommand>
    {
        private readonly IResponseQuestionService _responseQuestionService;
        public PostResponseAdditionalQuestionCommandValidator(IResponseQuestionService responseQuestionService)
        {
            _responseQuestionService = responseQuestionService;
            RuleFor(x => x.Response)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("La respuesta no puede estar vacia");
            RuleFor(x => x.QuestionnaireTemplateId)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("El Id del QuestionnaireTemplateId no puede estar vacío");
            RuleFor(x => x.QuestionnaireQuestionTemplateId)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("El Id del QuestionnaireQuestionTemplateId no puede estar vacío");
            RuleFor(x => x.ResponseAccompanimentPlanId)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("El Id del ResponseAccompanimentPlanId no puede estar vacío");
        }
    }
}
