using Application.Interfaces.Mekano;
using FluentValidation;

namespace Application.Cqrs.Mekano.Queries
{
    public class GetCostCenterByIdQueryValidator : AbstractValidator<GetCostCenterByIdQuery>
    {
        private readonly ICostCenterService _costCenterService;

        public GetCostCenterByIdQueryValidator(ICostCenterService costCenterService)
        {
            _costCenterService = costCenterService;

            RuleFor(x => x.Id)
                .NotNull()
                .WithMessage("test");

            RuleFor(x => x.Id).MustAsync(async (h, cancellation) =>
            {
                return await _costCenterService.checkById(h);
            }).WithMessage("El id del periodo es obligatorio...");

        }
    }
}
