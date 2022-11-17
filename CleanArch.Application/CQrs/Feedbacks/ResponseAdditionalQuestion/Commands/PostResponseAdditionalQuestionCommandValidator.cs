using Application.Interfaces.Feedbacks;
using FluentValidation;

namespace Application.Cqrs.Feedbacks.ResponseAdditionalQuestion.Commands
{
    public class PostResponseAdditionalQuestionCommandValidator : AbstractValidator<PostResponseAdditionalQuestionCommand>
    {
        private readonly IResponseAdditionalQuestionService _responseAdditionalQuestionService;
        public PostResponseAdditionalQuestionCommandValidator(IResponseAdditionalQuestionService responseAdditionalQuestionService)
        {
            _responseAdditionalQuestionService = responseAdditionalQuestionService;
            RuleFor(x => x.Response)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("La respuesta no puede estar vacia");
            RuleFor(x => x.Question)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("El pregunta no puede estar vacía");
            RuleFor(x => x.ResponseAccompanimentPlanId)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("El Id del ResponseAccompanimentPlanId no puede estar vacío");
        }
    }
}
