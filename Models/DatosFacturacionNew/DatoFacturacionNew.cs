using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DatosFacturacionNew
{
    public class DatoFacturacionNew
    {
        private int _idDatoFacturacion;
        private string _rut;
        private string _razonSocial;
        private string _direccion;
        private int _comunaEstado;
        private int _idGiroFacturacion;
        private string _emailIntercambio;
        private int _documentoPago;
        private int _formaPagoEstado;
        private int _idUsuario;
        private DateTime _fechaCreacion;
        private Boolean _isEliminado;

        public Boolean isEliminado
        {
            get { return _isEliminado; }
            set { _isEliminado = value; }
        }

        public int IdDatoFacturacion
        {
            get
            {
                return _idDatoFacturacion;
            }
            set
            {
                _idDatoFacturacion = value;
            }
        }
        public string Rut
        {
            get
            {
                return _rut;
            }
            set
            {
                _rut = value;
            }
        }
        public string RazonSocial
        {
            get
            {
                return _razonSocial;
            }
            set
            {
                _razonSocial = value;
            }
        }
        public string Direccion
        {
            get
            {
                return _direccion;
            }
            set
            {
                _direccion = value;
            }
        }
        public int ComunaEstado
        {
            get
            {
                return _comunaEstado;
            }
            set
            {
                _comunaEstado = value;
            }
        }
        public int IdGiroFacturacion
        {
            get
            {
                return _idGiroFacturacion;
            }
            set
            {
                _idGiroFacturacion = value;
            }
        }
        public string EmailIntercambio
        {
            get
            {
                return _emailIntercambio;
            }
            set
            {
                _emailIntercambio = value;
            }
        }
        public int DocumentoPago
        {
            get
            {
                return _documentoPago;
            }
            set
            {
                _documentoPago = value;
            }
        }
        public int FormaPagoEstado
        {
            get
            {
                return _formaPagoEstado;
            }
            set
            {
                _formaPagoEstado = value;
            }
        }
        public int IdUsuario
        {
            get
            {
                return _idUsuario;
            }
            set
            {
                _idUsuario = value;
            }
        }
        public DateTime FechaCreacion
        {
            get
            {
                return _fechaCreacion;
            }
            set
            {
                _fechaCreacion = value;
            }
        }
    }
}
