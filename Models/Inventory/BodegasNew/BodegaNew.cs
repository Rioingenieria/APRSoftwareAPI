using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Inventory.BodegasNew
{
    public class BodegaNew
    {
        private int _idBodega;
        private string _nombre;
        private string _descripcion;
        private string _direccion;
        private string _telefono;
        private string _correo;
        private int _idUsuario;
        private int _idUsuarioEncargado;
        private DateTime _fechaCreacion;
        private bool _isEliminado;
        [Key]
        public int IdBodega
        {
            get { return _idBodega; }
            set { _idBodega = value; }
        }
        [DisplayName("Nombre")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }
        public string  Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }
        public string  Correo
        {
            get { return _correo; }
            set { _correo = value; }
        }
        public int IdUsuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
        }
        [Required(ErrorMessage = "El campo usuario enmcargado es requerido.")]
        public int IdUsuarioEncargado
        {
            get { return _idUsuarioEncargado; }
            set { _idUsuarioEncargado = value; }
        }
        public DateTime FechaCreacion
        {
            get { return _fechaCreacion; }
            set { _fechaCreacion = value; }
        }
        public bool IsEliminado
        {
            get { return _isEliminado; }
            set { _isEliminado = value; }
        }
    }
}
