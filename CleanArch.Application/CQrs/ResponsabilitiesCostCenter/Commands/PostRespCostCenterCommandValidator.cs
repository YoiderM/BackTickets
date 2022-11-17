using Application.Interfaces.Mekano;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Cqrs.ResponsabilitiesCostCenter.Commands
{
    public class PostRespCostCenterCommandValidator : AbstractValidator<PostResponsabilityCostCenterCommand>
    {
        private readonly IResponsabilityCostCenterService _responsabilityCostCenterService;
        public PostRespCostCenterCommandValidator(IResponsabilityCostCenterService responsabilityCostCenterService)
        {
            _responsabilityCostCenterService = responsabilityCostCenterService;

            RuleFor(x => x.CostCenterId)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("El Centro de Costos Id no puede estar vacío");

            RuleFor(x => x.UserId)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("El users Id no puede estar vacío");

        }
    }
}
