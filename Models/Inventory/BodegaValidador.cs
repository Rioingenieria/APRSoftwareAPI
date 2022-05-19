using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Inventory
{
    public class BodegaValidador : AbstractValidator<Bodega>
    {
        public BodegaValidador()
        {
            RuleFor(Bodega => Bodega.Nombre).NotNull().NotEmpty().WithMessage("Nombre de bodega no puede estar vacío.");
            RuleFor(Bodega => Bodega.IdUsuarioEncargado).NotNull().WithMessage("Bodega no se puede registrar sin encargado de bodega.");
            RuleFor(Bodega => Bodega.IdUsuario).NotNull();
            When(Bodega => Bodega.Correo != string.Empty, () =>
            {
                RuleFor(Bodega => Bodega.Correo).EmailAddress().WithMessage("Dirección de correo inválida.");
            });
        }
    }
}
