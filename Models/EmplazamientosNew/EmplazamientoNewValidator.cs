using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.EmplazamientosNew
{
    public class EmplazamientoNewValidator:AbstractValidator<EmplazamientoNew>
    {
        public EmplazamientoNewValidator() 
        {
            RuleFor(EmplazamientoNew => EmplazamientoNew.rol).NotNull().NotEmpty().WithMessage("Los datos de Emplazamiento no se pueden registrar sin rol.");
        }
    }
}
