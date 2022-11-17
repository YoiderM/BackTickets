using Application.Cqrs.ResponsabilitiesCostCenter.Queries;
using Application.Interfaces.Mekano;
using FluentValidation;

namespace Application.Cqrs.Mekano.Queries
{
    public class GetResponsabilityCostCenterByDocQueryValidator : AbstractValidator<GetResponsabilityCostCenterByDocQuery>
    {
        private readonly IResponsabilityCostCenterService _responsabilityCostCenterService;

        public GetResponsabilityCostCenterByDocQueryValidator(IResponsabilityCostCenterService responsabilityCostCenterService)
        {
            _responsabilityCostCenterService = responsabilityCostCenterService;

            RuleFor(x => x.Document)
                .NotNull()
                .WithMessage("El documento no puede estar vacío");

        }
    }
}
