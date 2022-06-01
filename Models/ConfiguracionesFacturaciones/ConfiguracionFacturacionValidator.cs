using Common.Constantes;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ConfiguracionesFacturaciones
{
    public class ConfiguracionFacturacionValidator : AbstractValidator<ConfiguracionFacturacion>
    {
        public ConfiguracionFacturacionValidator()
        {
            RuleFor(ConfiguracionFacturacion => ConfiguracionFacturacion.IdUsuario).NotNull().WithMessage("El Id del Usuario no puede ser nulo");
            RuleFor(ConfiguracionFacturacion => ConfiguracionFacturacion.FechaCreacion).GreaterThan(Convert.ToDateTime(NumerosYFechas.DateMinValue)).WithMessage("La fecha de creación no puede ser menor que :" + NumerosYFechas.DateMinValue);
        }
    }
}
