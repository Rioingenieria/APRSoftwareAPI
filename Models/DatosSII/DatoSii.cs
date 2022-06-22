using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DatosSII
{
    public class DatoSii
    {
        private int _idEmpresa;
        private string _rut;
        private string _razonSocial;
        private string _rutCertificado;
        private string _nombreCertificado;
        private string _giro;
        private string _direccion;
        private string _comuna;
        private string _codigoActividades;
        private DateTime _fechaResolucion;
        private string _numeroResolucion;
        private string _ciudad;
        private string _razonSocialBoleta;
        private string _giroBoleta;
        private string _unidadSii;
        private string _telefono;
        private string _correo;
        private int _idAprGlobal;
        private Boolean _datosSiiServidor;
        private string _telefonoEmergencia;
        private string _tipoEmpresa;
        private string _facebook;
        private string _paginaWeb;
        private DateTime _fechaAutorizacion;
        private int _codigoLicenciatura;
        private string _nombreLicenciatura;
        private string _codigoRegion;
        private string _nombreRegion;
        private string _codigoComuna;
        private string _nombreComuna;
        private Boolean _isEliminado;

        public Boolean isEliminado
        {
            get { return _isEliminado; }
            set { _isEliminado = value; }
        }


        public string nombreComuna
        {
            get { return _nombreComuna; }
            set { _nombreComuna = value; }
        }

        public string codigoComuna
        {
            get { return _codigoComuna; }
            set { _codigoComuna = value; }
        }

        public string nombreRegion
        {
            get { return _nombreRegion; }
            set { _nombreRegion = value; }
        }

        public string codigoRegion
        {
            get { return _codigoRegion; }
            set { _codigoRegion = value; }
        }

        public string nombreLicenciatura
        {
            get { return _nombreLicenciatura; }
            set { _nombreLicenciatura = value; }
        }

        public int codigoLicenciatura
        {
            get { return _codigoLicenciatura; }
            set { _codigoLicenciatura = value; }
        }


        public DateTime fechaAutorizacion
        {
            get { return _fechaAutorizacion; }
            set { _fechaAutorizacion = value; }
        }

        public string paginaWeb
        {
            get { return _paginaWeb; }
            set { _paginaWeb = value; }
        }

        public string facebook
        {
            get { return _facebook; }
            set { _facebook = value; }
        }

        public string tipoEmpresa
        {
            get { return _tipoEmpresa; }
            set { _tipoEmpresa = value; }
        }

        public string telefonoEmergencia
        {
            get { return _telefonoEmergencia; }
            set { _telefonoEmergencia = value; }
        }

        public Boolean datosSiiServidor
        {
            get { return _datosSiiServidor; }
            set { _datosSiiServidor = value; }
        }

        public int idAprGlobal
        {
            get { return _idAprGlobal; }
            set { _idAprGlobal = value; }
        }

        public string correo
        {
            get { return _correo; }
            set { _correo = value; }
        }

        public string telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        public string unidadSii
        {
            get { return _unidadSii; }
            set { _unidadSii = value; }
        }

        public string giroBoleta
        {
            get { return _giroBoleta; }
            set { _giroBoleta = value; }
        }

        public string razonSocialBoleta
        {
            get { return _razonSocialBoleta; }
            set { _razonSocialBoleta = value; }
        }

        public string ciudad
        {
            get { return _ciudad; }
            set { _ciudad = value; }
        }

        public string numeroResolucion
        {
            get { return _numeroResolucion; }
            set { _numeroResolucion = value; }
        }

        public DateTime fechaResolucion
        {
            get { return _fechaResolucion; }
            set { _fechaResolucion = value; }
        }

        public string codigoActividades
        {
            get { return _codigoActividades; }
            set { _codigoActividades = value; }
        }

        public string comuna
        {
            get { return _comuna; }
            set { _comuna = value; }
        }

        public string direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }

        public string giro
        {
            get { return _giro; }
            set { _giro = value; }
        }

        public string nombreCertificado
        {
            get { return _nombreCertificado; }
            set { _nombreCertificado = value; }
        }

        public string rutCertificado
        {
            get { return _rutCertificado; }
            set { _rutCertificado = value; }
        }

        public string razonSocial
        {
            get { return _razonSocial; }
            set { _razonSocial = value; }
        }

        public string rut
        {
            get { return _rut; }
            set { _rut = value; }
        }

        public int idEmpresa
        {
            get { return _idEmpresa; }
            set { _idEmpresa = value; }
        }


    }
}
