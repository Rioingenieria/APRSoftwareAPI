using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ClientesNew
{
    public class ClienteNew
    {
        private int _idCliente;
        private string _nombre;
        private string _apellido;
        private string _rut;
        private string _domicilio;
        private string _email;
        private DateTime _ingreso;
        private int _tipoClienteEstado;
        private int _numSocio;
        private string _telefono;
        private int _numVivi;
        private string _genero;
        private DateTime _fechaNacimiento;
        private Boolean _firmarLibro;
        private string _envioWhatsapp;
        private DateTime _fechaCreacion;
        private int _idUsuario;
        private Boolean _isEliminado;

        public Boolean isEliminado
        {
            get { return _isEliminado; }
            set { _isEliminado = value; }
        }

        public int idUsuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
        }

        public DateTime fechaCreacion
        {
            get { return _fechaCreacion; }
            set { _fechaCreacion = value; }
        }

        public string envioWhatsapp
        {
            get { return _envioWhatsapp; }
            set { _envioWhatsapp = value; }
        }

        public Boolean firmarLibro
        {
            get { return _firmarLibro; }
            set { _firmarLibro = value; }
        }

        public DateTime fechaNacimiento
        {
            get { return _fechaNacimiento; }
            set { _fechaNacimiento = value; }
        }

        public string genero
        {
            get { return _genero; }
            set { _genero = value; }
        }

        public int numVivi
        {
            get { return _numVivi; }
            set { _numVivi = value; }
        }

        public string telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        public int numSocio
        {
            get { return _numSocio; }
            set { _numSocio = value; }
        }

        public int tipoClienteEstado
        {
            get { return _tipoClienteEstado; }
            set { _tipoClienteEstado = value; }
        }

        public DateTime ingreso
        {
            get { return _ingreso; }
            set { _ingreso = value; }
        }

        public string email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string domicilio
        {
            get { return _domicilio; }
            set { _domicilio = value; }
        }

        public string rut
        {
            get { return _rut; }
            set { _rut = value; }
        }
        public string apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }
        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public int idCliente
        {
            get { return _idCliente; }
            set { _idCliente = value; }
        }

    }
}
