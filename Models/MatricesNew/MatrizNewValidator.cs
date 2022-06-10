using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.MatricesNew
{
    public class MatrizNewValidator:AbstractValidator<MatrizNew>
    {
        public MatrizNewValidator()
        {
            RuleFor(MatrizNew => MatrizNew.idPozo).NotEmpty().NotNull().WithMessage("La Matriz no se puede registrar sin identificador de pozo.");
        }
    }
}
