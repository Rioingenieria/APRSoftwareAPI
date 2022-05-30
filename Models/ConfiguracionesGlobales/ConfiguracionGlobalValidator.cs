using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ConfiguracionesGlobales
{
    public class ConfiguracionGlobalValidator:AbstractValidator<ConfiguracionGlobal>
    {
        public ConfiguracionGlobalValidator()
        {
            RuleFor(ConfiguracionesGlobales => ConfiguracionesGlobales.id_usuario).NotNull().WithMessage("La configucaión no se puede registrar sin el id de usuario.");
        }
        
    }
}
