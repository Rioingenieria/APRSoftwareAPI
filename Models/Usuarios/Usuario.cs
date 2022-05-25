using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Usuarios
{
   public class Usuario
    {
        private int _idUsuario;
        private string _usuario;
        private string _cargo;
        private string _nombre;
        private string _apellido; 
        private string _rut;
        private string _contraseña;
        private int _idTipoUsuario;
        private string _tipoUsuario;
        private DateTime _fechaNacimiento;
        private string _email;
        private bool _contraseñaGenerada;
        private string _fotoUrl;
        private byte[]? _foto;
        private bool _isEliminado;
        public int IdUsuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
        }
        public string NombreUsuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }
        public string Cargo
        {
            get { return _cargo; }
            set { _cargo = value; }
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }
        public string Rut
        {
            get { return _rut; }
            set { _rut = value; }
        }
        public string Contraseña
        {
            get { return _contraseña; }
            set { _contraseña = value; }
        }
        public int IdTipoUsuario
        {
            get { return _idTipoUsuario; }
            set { _idTipoUsuario = value; }
        }
        public string TipoUsuario
        {
            get { return _tipoUsuario; }
            set { _tipoUsuario = value; }
        }
        public DateTime FechaNacimiento
        {
            get { return _fechaNacimiento; }
            set { _fechaNacimiento = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public bool ContraseñaGenerada
        {
            get { return _contraseñaGenerada; }
            set { _contraseñaGenerada = value; }
        }
        public string FotoUrl
        {
            get { return _fotoUrl; }
            set { _fotoUrl = value; }
        }
        public byte[] Foto
        {
            get { return _foto; }
            set { _foto = value; }
        }
        public bool IsEliminado
        {
            get { return _isEliminado; }
            set { _isEliminado = value; }
        }
    }
}
