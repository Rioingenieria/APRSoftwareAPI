using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Models.Usuarios
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(Usuario => Usuario.NombreUsuario).NotNull().NotEmpty().WithMessage("Debe completar el nombre del usuario.");
        }
    }
}