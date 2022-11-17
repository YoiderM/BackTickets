using Application.Auth.Commands;
using Domain.Interfaces;
using FluentValidation;

namespace Application.Courses.Commands
{
    public class PostLoginCommandValidator : AbstractValidator<PostLoginCommand>
    {
        private readonly IAuthRepository _authRepository;
        public PostLoginCommandValidator(
            IAuthRepository authRepository

            )
        {
            _authRepository = authRepository;
            
            RuleFor(c => c.Document).NotNull();
            RuleFor(c => c.Password).NotNull();
            //RuleFor(c => c.SubCampaignId)
            //    .NotNull();


        }


        
    }
}
