using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.MedidoresNew
{
    public class MedidorNew
    {
        private int _idMedidor;
        private string _numeroMedidor;
        private DateTime _instalacionFecha;
        private bool _instalacionFechaVerdad;
        private int _unidadMedidorEstado;
        private bool _alcantarillado;
        private int _idSubsidio;
        private int _idCliente;
        private int _idRed;
        private bool _nicho;
        private int _diametroEstado;
        private int _idEmplazamiento;
        private int _segundoHogar;
        private int _estadoClienteEstado;
        private int _idExencion;
        private int _idSector;
        private int _idTarifa;
        private int _idConfiguracionPeriodico;
        private int _idDatoFacturacion;
        private int _tipoMedidorEstado;
        private bool _sincronizacionWeb;
        private int _idClienteGlobal;
        private int _numeroVivienda;
        private string _direccion;
        private int _idConfiguracionFacturacion;
        private DateTime _fechaCreacion;
        private int _idUsuario;
        private bool _isEliminado;

        public int IdMedidor
        {
            get
            {
                return _idMedidor;
            }
            set
            {
                _idMedidor = value;
            }
        }
        public string NumeroMedidor
        {
            get
            {
                return _numeroMedidor;
            }
            set
            {
                _numeroMedidor = value;
            }
        }
        public DateTime InstalacionFecha
        {
            get
            {
                return _instalacionFecha;
            }
            set
            {
                _instalacionFecha = value;
            }
        }
        public bool InstalacionFechaVerdad
        {
            get
            {
                return _instalacionFechaVerdad;
            }
            set
            {
                _instalacionFechaVerdad = value;
            }
        }
        public int UnidadMedidorEstado
        {
            get
            {
                return _unidadMedidorEstado;
            }
            set
            {
                _unidadMedidorEstado = value;
            }
        }
        public bool Alcantarillado
        {
            get
            {
                return _alcantarillado;
            }
            set
            {
                _alcantarillado = value;
            }
        }
        public int IdSubsidio
        {
            get
            {
                return _idSubsidio;
            }
            set
            {
                _idSubsidio = value;
            }
        }
        public int IdCliente
        {
            get
            {
                return _idCliente;
            }
            set
            {
                _idCliente = value;
            }
        }
        public int IdRed
        {
            get
            {
                return _idRed;
            }
            set
            {
                _idRed = value;
            }
        }
        public bool Nicho
        {
            get
            {
                return _nicho;
            }
            set
            {
                _nicho = value;
            }
        }
        public int DiametroEstado
        {
            get { return _diametroEstado; }
            set { _diametroEstado = value; }
        }
        public int IdEmplazamiento
        {

            get
            {
                return _idEmplazamiento;
            }
            set
            {
                _idEmplazamiento = value;
            }
        }
        public int SegundoHogar
        {
            get => _segundoHogar;
            set => _segundoHogar = value;
        }
        public int EstadoClienteEstado
        {
            get
            {
                return _estadoClienteEstado;
            }
            set
            {
                _estadoClienteEstado = value;
            }
        }
        public int IdExencion
        {
            get
            {
                return _idExencion;
            }
            set
            {
                _idExencion = value;
            }
        }
        public int IdSector
        {
            get
            {
                return _idSector;
            }
            set
            {
                _idSector = value;
            }

        }
        public int IdTarifa
        {
            get
            {
                return _idTarifa;
            }
            set
            {
                _idTarifa = value;
            }
        }
        public int IdConfiguracionPeriodico
        {
            get
            {
                return _idConfiguracionPeriodico;
            }
            set
            {
                _idConfiguracionPeriodico = value;
            }
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
        public int TipoMedidorEstado
        {
            get
            {
                return _tipoMedidorEstado;
            }
            set
            {
                _tipoMedidorEstado = value;
            }
        }
        public bool SincronizacionWeb
        {
            get
            {
                return _sincronizacionWeb;
            }
            set
            {
                _sincronizacionWeb = value;
            }
        }
        public int IdClienteGlobal
        {
            get
            {
                return _idClienteGlobal;
            }
            set
            {
                _idClienteGlobal = value;
            }
        }
        public int NumeroVivienda
        {
            get
            {
                return _numeroVivienda;
            }
            set
            {
                _numeroVivienda = value;
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
        public int IdConfiguracionFacturacion
        {
            get { return _idConfiguracionFacturacion; }
            set { _idConfiguracionFacturacion = value; }
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
