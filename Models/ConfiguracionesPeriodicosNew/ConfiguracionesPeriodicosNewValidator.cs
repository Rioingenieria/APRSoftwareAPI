using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ConfiguracionesPeriodicosNew
{
    public class ConfiguracionesPeriodicosNewValidator: AbstractValidator<ConfiguracionPeriodicoNew>
    {
        public ConfiguracionesPeriodicosNewValidator()
        {
            RuleFor(Configuraciones => Configuraciones.idUsuario).NotNull().WithMessage("La configucaión no se puede registrar sin el id de usuario.");
        }
    }
}
