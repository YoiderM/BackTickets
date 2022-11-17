using Application.Interfaces.User;
using FluentValidation;

namespace Application.Cqrs.User.Commands
{
    public class PutUserCommandValidator : AbstractValidator<PutUserCommand>
    {
        private readonly IUserService _userService;

        public PutUserCommandValidator(IUserService userService)
        {
            _userService = userService;

            RuleFor(x => x.Document)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("El documento no puede estar vacío");

            RuleFor(x => x.Names)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("El nombre no puede estar vacío"); 

            RuleFor(x => x.CampaignName)
                   .NotEmpty()
                   .WithMessage("El nombre de la campaña no puede estar vacío");

            RuleFor(x => x.PassWord)
                   .NotEmpty()
                   .WithMessage("El password no puede estar vacío");

            RuleFor(u => u)
                .MustAsync((x, cancellation) => _userService.CheckUserExistsByDocumentInMekano(x.Document))
                .WithMessage("El documento ingresado no se encuentra registrado en Mekano");

        }

    }
}
