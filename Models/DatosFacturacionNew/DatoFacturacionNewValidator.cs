using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DatosFacturacionNew
{
     public class DatoFacturacionNewValidator:AbstractValidator<DatoFacturacionNew>
    {
        public DatoFacturacionNewValidator()
        {
            RuleFor(DatoFacturacion => DatoFacturacion.IdDatoFacturacion).NotNull();
            RuleFor(DatoFacturacion => DatoFacturacion.Rut).NotNull();
            RuleFor(DatoFacturacion => DatoFacturacion.RazonSocial).NotNull();
            RuleFor(DatoFacturacion => DatoFacturacion.Direccion).NotNull();
            RuleFor(DatoFacturacion => DatoFacturacion.ComunaEstado).NotNull();
            RuleFor(DatoFacturacion => DatoFacturacion.IdGiroFacturacion).NotNull();
            RuleFor(DatoFacturacion => DatoFacturacion.EmailIntercambio).NotNull();
            RuleFor(DatoFacturacion => DatoFacturacion.DocumentoPago).NotNull();
            RuleFor(DatoFacturacion => DatoFacturacion.FormaPagoEstado).NotNull();
            RuleFor(DatoFacturacion => DatoFacturacion.IdUsuario).NotNull().NotEmpty().WithMessage("Los datos de facturación no se pueden registrar sin identificador de Usuario.");
        }
    }
}
