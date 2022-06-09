using Common.Constantes;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Inventory.BodegasNew
{
    public class BodegasNewValidator : AbstractValidator<BodegaNew>
    {
        public BodegasNewValidator()
        {
            RuleFor(BodegaNew => BodegaNew.Nombre).NotNull().NotEmpty().WithMessage("Nombre de bodega no puede estar vacío.");
            RuleFor(BodegaNew => BodegaNew.IdUsuarioEncargado).NotNull().WithMessage("Bodega no se puede registrar sin encargado de bodega.");
            RuleFor(BodegaNew => BodegaNew.IdUsuario).NotNull();
            RuleFor(BodegaNew => BodegaNew.FechaCreacion).NotNull().GreaterThan(Convert.ToDateTime(NumerosYFechas.DateMinValue)).WithMessage("La fecha no puede ser inferior a "+ NumerosYFechas.DateMinValue);
            When(BodegaNew => BodegaNew.Correo != string.Empty, () =>
            {
                RuleFor(BodegaNew => BodegaNew.Correo).EmailAddress().WithMessage("Dirección de correo inválida.");
            });
        }
    }
}
