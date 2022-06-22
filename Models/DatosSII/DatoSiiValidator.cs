using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DatosSII
{
    public class DatoSiiValidator:AbstractValidator<DatoSii>
    {
       public DatoSiiValidator()
        {
            RuleFor(DatoSii => DatoSii.rut).NotNull().NotEmpty().WithMessage("los datos sii no se puede registrar sin rut de empresa.");
        }
    }
}
