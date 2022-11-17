using Application.Interfaces.Feedbacks;
using FluentValidation;

namespace Application.Cqrs.Feedbacks.ResponseAccompanimentPlan.Commands
{
    public class PostResponseAccompanimentPlanCommandValidator : AbstractValidator<PostResponseAccompanimentPlanCommand>
    {
        private readonly IResponseAccompanimentPlanService _responseAccompanimentPlanService;
        public PostResponseAccompanimentPlanCommandValidator(IResponseAccompanimentPlanService responseAccompanimentPlanService)
        {
            _responseAccompanimentPlanService = responseAccompanimentPlanService;
            RuleFor(x => x.ResponseAccompanimentPlanId)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("ResponseAccompanimentPlanId no puede ser vacío");
            RuleFor(x => x.AccompanimentPlanId)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("AccompanimentPlanId no puede ser vacío");
            RuleFor(x => x.ScheduledDate)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Fecha programación no puede ser vacío");
            RuleFor(x => x.StartDate)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Fecha inicio no puede ser vacío");
            RuleFor(x => x.ConclusionsAndCommitments)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("ConclusionsAndCommitments no puede ser vacío");
            RuleFor(x => x.responseQuestions)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("ConclusionsAndCommitments no puede ser vacío");
        }
    }
}
