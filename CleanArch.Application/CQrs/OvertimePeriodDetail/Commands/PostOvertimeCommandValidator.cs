using Application.Interfaces.Overtimes;
using FluentValidation;

namespace Application.Cqrs.OvertimePeriodDetail.Commands
{
    public class PostOvertimeCommandValidator : AbstractValidator<PostOvertimeCommand>
    {
        private readonly IOvertimeService _overtimeService;
       
        public PostOvertimeCommandValidator(IOvertimeService overtimeService)
        {
            _overtimeService = overtimeService;
            
            RuleFor(x => x.OvertimePeriodId)
                .NotNull()
                .NotEmpty()
                .WithMessage("OvertimePeriodId No debe estar vacío.");

            RuleFor(x => x.Document)
                .NotNull()
                .NotEmpty()
                .WithMessage("Document No debe estar vacío.");

            RuleFor(x => x.OvertimeDay)
                .NotNull()
                .NotEmpty()
                .WithMessage("OvertimeDay No debe estar vacío.");
        }              

    }
}








