using FluentValidation;

namespace Application.Configurations.Categories.Command
{
    public class PostCategoryCommandValidator : AbstractValidator<PostCategoryCommand>
    {
        public PostCategoryCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("El nombre no puede estar vacío");

            RuleFor(x => x.Description)
               .NotEmpty()
               .WithMessage("El descripción no puede estar vacía");
        
        }
    }
}
