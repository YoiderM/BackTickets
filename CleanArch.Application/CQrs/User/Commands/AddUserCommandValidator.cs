using Application.Cqrs.User.Commands;
using Application.Interfaces.User;
using FluentValidation;

namespace Application.CQRS.User.Commands
{
    public class AddUserCommandValidator : AbstractValidator<PostUserCommand>
    {
        private readonly IUserService _userService;

        public AddUserCommandValidator(IUserService userService)
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

            RuleFor(x => x.PassWord)
                .NotEmpty()
                 .WithMessage("El password no puede estar vacío");

            RuleFor(x => x.CampaignName)
                .NotEmpty()
                 .WithMessage("El Nombre de la campaña no puede estar vacío");

            //RuleFor(x => x.Document).MustAsync(async (document, cancellation) => 
            //{                  
            //    bool exists = await _userService.CheckUserExistsByDocumentInMekano(document);
            //    return !exists;

            //})
            //   .WithMessage("El usuario no se encuentra registrado en Mekano");

            RuleFor(u => u)
                .MustAsync((x, cancellation) => _userService.CheckUserExistsByDocumentInMekano(x.Document))
                .WithMessage("El usuario no se encuentra registrado en Mekano");

            RuleFor(u => u)
                .MustAsync((x, cancellation) => _userService.CheckUserExistsByDocument(x.Document))
                .WithMessage("El usuario ya se encuentra registrado en el Sistema");

        }
    }
}
