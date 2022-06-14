using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ClientesNew
{
    public class ClienteNewValidator: AbstractValidator<ClienteNew>
    {
        public ClienteNewValidator()
        {
            RuleFor(ClienteNew=>ClienteNew.idUsuario).NotNull().NotEmpty().WithMessage("El Cliente no se puede registrar sin identificador del Usuario.");
            RuleFor(ClienteNew=>ClienteNew.fechaCreacion).NotNull().NotEmpty().WithMessage("El Cliente no se puede registrar sin fecha de creación.");
            RuleFor(ClienteNew => ClienteNew.rut).NotNull().NotEmpty().WithMessage("El Cliente no se puede registrar sin rut.");
        }
    }
}
