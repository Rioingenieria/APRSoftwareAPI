using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ProveedoresNew
{
    public class ProveedorNewValidator:AbstractValidator<ProveedorNew>
    {
        public ProveedorNewValidator()
        {
            RuleFor(ProveedorNew => ProveedorNew.idDatoFacturacion).NotNull().NotEmpty().WithMessage("El proveedor no se puede registrar sin identificador de factura.");
            RuleFor(ProveedorNew => ProveedorNew.telefono).NotNull().NotEmpty().WithMessage("El proveedor no se puede registrar sin numero de telefono.");
            RuleFor(ProveedorNew => ProveedorNew.nombre).NotNull().NotEmpty().WithMessage("El proveedor no se puede registrar sin nombre.");
        }
    }
}
