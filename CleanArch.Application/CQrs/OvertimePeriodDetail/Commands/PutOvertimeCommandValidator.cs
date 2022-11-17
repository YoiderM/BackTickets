using Application.Interfaces.Mekano;
using Application.Interfaces.Overtimes;
using FluentValidation;
using System;

namespace Application.Cqrs.OvertimePeriodDetail.Commands
{
    public class PutOvertimeCommandValidator : AbstractValidator<PutOvertimeCommand>
    {
        private readonly IOvertimePeriodService _overtimePeriodService;
        private readonly ICostCenterService _costCenterService;
        private readonly IOvertimeTypeService _overtimeTypeService;
        private readonly IMekanoUserService _mekanoUserService;

        public PutOvertimeCommandValidator(IOvertimePeriodService overtimePeriodService, 
                                           ICostCenterService costCenterService, 
                                           IOvertimeTypeService overtimeTypeService,
                                           IMekanoUserService mekanoUserService)
        {
            _overtimePeriodService = overtimePeriodService;
            _overtimeTypeService = overtimeTypeService;
            _costCenterService = costCenterService;
            _mekanoUserService = mekanoUserService;

            RuleFor(x => x.Aproved)
                .NotNull()
                .WithMessage("El campo para determinar si es aprobada la hora extra no puede ser nula");

            //Revisar si va a ser obligatorio
            //RuleFor(x => x.Login)
            //    .NotNull()
            //    .WithMessage("El campo login no puede estar nulo")
            //    .NotEmpty()
            //    .WithMessage("El campo login no puede estar vacío");

            //RuleFor(x => x.LoginTime)
            //    .NotNull()
            //    .WithMessage("El campo hora de logueo no puede ser nula");
            
            RuleFor(x => x.JobName)
                .NotNull()
                .WithMessage("El campo cargo no puede ser nulo")
                .NotEmpty()
                .WithMessage("El campo cargo no puede estar vacío");

            RuleFor(x => x.Document)
                .NotNull()
                .WithMessage("El campo número de documento no puede ser nulo")
                .NotEmpty()
                .WithMessage("El campo número de documento no puede estar vacío");

            RuleFor(x => x.Names)
                .NotNull()
                .WithMessage("El campo nombre no puede ser nulo")
                .NotEmpty()
                .WithMessage("El campo nombre no puede estar vacío");

            RuleFor(x => x.TotalHours)
                .NotNull()
                .WithMessage("El campo total horas no puede ser nulo")
                .GreaterThan(0)
                .WithMessage("El campo total horas debe ser mayor a cero");

            RuleFor(x => x.CompensatoryApplies)
                .NotNull()
                .WithMessage("El campo aplica compensatorio no puede ser nula");

            RuleFor(x => x.OvertimeDay)
                .NotNull()
                .WithMessage("El campo hora extra no puede ser nula")
                .LessThan(DateTime.Now)
                .WithMessage("El campo hora extra no puede ser mayor a la fecha actual");

            RuleFor(x => x.InitialHour)
                .NotNull()
                .WithMessage("El campo hora inicial no puede ser nula");

            RuleFor(x => x.EndHour)
                .NotNull()
                .WithMessage("El campo hora final no puede ser nula");

            RuleFor(x => x.Salary)
                .NotNull()
                .WithMessage("El campo salario no puede ser nulo")
                .GreaterThan(0)
                .WithMessage("El campo salario debe ser mayor a cero");

            RuleFor(x => x.CostCenterId)
                .NotNull()
                .WithMessage("El campo centro de costos no puede ser nula")
                .GreaterThan(0)
                .WithMessage("El campo centro de costos debe ser mayor a cero");

            RuleFor(x => x.OvertimeTypeId)
                .NotNull()
                .WithMessage("El campo tipo de hora extra no puede ser nula");

        }
    }
}








