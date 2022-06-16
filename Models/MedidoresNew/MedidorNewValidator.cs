using Common.Constantes;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.MedidoresNew
{
    public class MedidorNewValidator : AbstractValidator<MedidorNew>
    {
        public MedidorNewValidator()
        {
            RuleFor(Medidor => Medidor.NumeroMedidor).NotNull().NotEmpty();
            RuleFor(Medidor => Medidor.InstalacionFechaVerdad).NotNull();
            RuleFor(Medidor => Medidor.UnidadMedidorEstado).NotNull();
            RuleFor(Medidor => Medidor.Alcantarillado).NotNull();
            RuleFor(Medidor => Medidor.IdSubsidio).NotNull().NotEqual(0);
            RuleFor(Medidor => Medidor.IdCliente).NotNull().NotEqual(0);
            RuleFor(Medidor => Medidor.IdRed).NotNull().NotEqual(0);
            RuleFor(Medidor => Medidor.Nicho).NotNull();
            RuleFor(Medidor => Medidor.DiametroEstado).NotNull();
            RuleFor(Medidor => Medidor.IdEmplazamiento).NotNull().NotEqual(0);
            RuleFor(Medidor => Medidor.SegundoHogar).NotNull();
            RuleFor(Medidor => Medidor.EstadoClienteEstado).NotNull().NotEqual(0);
            RuleFor(Medidor => Medidor.IdExencion).NotNull().NotEqual(0);
            RuleFor(Medidor => Medidor.IdSector).NotNull().NotEqual(0);
            RuleFor(Medidor => Medidor.IdTarifa).NotNull().NotEqual(0);
            RuleFor(Medidor => Medidor.IdConfiguracionPeriodico).NotNull().NotEqual(0);
            RuleFor(Medidor => Medidor.IdDatoFacturacion).NotNull().NotEqual(0);
            RuleFor(Medidor => Medidor.TipoMedidorEstado).NotNull();
            RuleFor(Medidor => Medidor.SincronizacionWeb).NotNull();
            RuleFor(Medidor => Medidor.IdClienteGlobal).NotNull();
            RuleFor(Medidor => Medidor.NumeroVivienda).NotNull();
            RuleFor(Medidor => Medidor.Direccion).NotNull().NotEmpty();
            RuleFor(Medidor => Medidor.IdConfiguracionFacturacion).NotNull().NotEqual(0);
            RuleFor(Medidor => Medidor.FechaCreacion).GreaterThan(Convert.ToDateTime(NumerosYFechas.DateMinValue));
            RuleFor(Medidor => Medidor.IdUsuario).NotNull().NotEqual(0);
            RuleFor(Medidor => Medidor.IsEliminado).NotNull();
        }
    }
}
