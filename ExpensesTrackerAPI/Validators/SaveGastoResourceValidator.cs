using ExpensesTrackerAPI.Resources;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesTrackerAPI.Validators
{
    public class SaveGastoResourceValidator : AbstractValidator<SaveGastoResource>
    {
        public SaveGastoResourceValidator()
        {
            RuleFor(a => a.Nombre)
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage("'Nombre' cannot have more than 50 characters and can't be empty");

            RuleFor(a => a.Valor)
                .GreaterThan(0)
                .WithMessage("'Valor' value should be greater than 0");

            RuleFor(a => a.EsGastoFijo)
                .NotNull()
                .WithMessage("'EsGastoFijo' Cannot be null");

            RuleFor(a => a.CantidadCuotas)
                .GreaterThan(0)
                .WithMessage("'CantidadCuotas' value should be greater than 0");

            RuleFor(a => a.EsReactivable)
                .NotNull()
                .WithMessage("'EsReactivable' Cannot be null");

            RuleFor(a => a.FechaInicioPago)
                .NotNull()
                .WithMessage("'FechaInicioPago' Cannot be null");
        }
    }
}
