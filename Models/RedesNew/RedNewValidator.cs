using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.RedesNew
{
    public class RedNewValidator:AbstractValidator<RedNew>
    {
        public RedNewValidator() 
        {
        RuleFor(RedNew => RedNew.idMatriz).NotNull().NotEmpty().WithMessage("La Red no se puede registrar sin identificador de Matriz.");
        }
    }
}
