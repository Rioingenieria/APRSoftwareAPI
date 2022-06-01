using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ConfiguracionesFacturaciones
{
    public class ConfiguracionFacturacion
    {
        private int _idConfiguracionFacturacion;
        private bool _termicaFactura;
        private bool _termicaBoleta;
        private bool _termicaComprobante;
        private bool _cuentaBoleta;
        private bool _saldoAnteriorDTE;
        private bool _reciboTermico;
        private string _encabezadoCuentaBoleta;
        private decimal _colorPrincipalDTE;
        private decimal _colorSecundarioDTE;
        private int _interesEstado;
        private decimal _valorInteres;
        private DateTime _fechaCreacion;
        private int _idUsuario;
        private bool _isEliminado;
        public int IdConfiguracionFacturacion
        {
            get { return _idConfiguracionFacturacion; }
            set { _idConfiguracionFacturacion = value; }
        }
        public bool TermicaFactura
        {
            get { return _termicaFactura; }
            set { _termicaFactura = value; }
        }
        public bool TermicaBoleta
        {
            get { return _termicaBoleta; }
            set { _termicaBoleta = value; }
        }
        public bool TermicaComprobante
        {
            get { return _termicaComprobante; }
            set { _termicaComprobante = value; }
        }
        public bool CuentaBoleta
        {
            get { return _cuentaBoleta; }
            set { _cuentaBoleta = value; }
        }
        public bool SaldoAnteriorDTE
        {
            get { return _saldoAnteriorDTE; }
            set { _saldoAnteriorDTE = value; }
        }
        public bool ReciboTermico
        {
            get { return _reciboTermico; }
            set { _reciboTermico = value; }
        }
        public string EncabezadoCuentaBoleta
        {
            get { return _encabezadoCuentaBoleta; }
            set { _encabezadoCuentaBoleta = value; }
        }
        public decimal ColorPrincipalDTE
        {
            get { return _colorPrincipalDTE; }
            set { _colorPrincipalDTE = value; }
        }
        public decimal ColorSecundarioDTE
        {
            get { return _colorSecundarioDTE; }
            set { _colorSecundarioDTE = value; }
        }
        public int InteresEstado
        {
            get { return _interesEstado; }
            set { _interesEstado = value; }
        }
        public decimal ValorInteres
        {
            get { return _valorInteres; }
            set { _valorInteres = value; }
        }
        public DateTime FechaCreacion
        {
            get { return _fechaCreacion; }
            set { _fechaCreacion = value; }
        }
        public int IdUsuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
        }
        public bool IsEliminado
        {
            get { return _isEliminado; }
            set { _isEliminado = value; }
        }
    }
}
