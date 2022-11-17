using Application.Interfaces.AdministrativeProcesses;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Cqrs.AdministrativeProcesses.DisciplinaryProcesses.Commands
{
    public class PostDisciplinaryProcessCommandValidator : AbstractValidator<PostDisciplinaryProcessCommand>
    {
        private readonly IDisciplinaryProcessService _disciplinaryProcessService;
        public PostDisciplinaryProcessCommandValidator(IDisciplinaryProcessService disciplinaryProcessService)
        {
            _disciplinaryProcessService = disciplinaryProcessService;

            RuleFor(x => x.Document)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("El Documento no puede estar vacío");

            RuleFor(x => x.Names)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("El Nombre no puede estar vacío");

            RuleFor(x => x.UserId)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("El Id del Usuario no puede estar vacío");

            RuleFor(x => x.userProcessApplicantId)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("El Id del Usuario que procesa la solicitud no puede estar vacío");

            RuleFor(x => x.CampaignName)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("El Nombre de la campaña no  puede estar vacío");

            RuleFor(x => x.TypeOfFaultId)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("El Id del tipo de falta no  puede estar vacío");

            RuleFor(x => x.ProcessStatusId)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("El Id del estado del proceso no puede estar vacío");
      
        }
    }

    
    
       
    
}
