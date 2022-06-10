using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.PozosNew
{
    public class PozoNewValidator: AbstractValidator<PozoNew>
    {
        public PozoNewValidator() 
        {
            RuleFor(PozoNew=>PozoNew.nombre).NotNull().NotEmpty().WithMessage("El Pozo no se puede registrar sin nombre.");
        }
    }
}
