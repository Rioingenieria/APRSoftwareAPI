using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Inventory
{
    public class Bodega
    {
        [Key]
        public int IdBodega { get; set; }
        [DisplayName("Nombre")]
        [Required (ErrorMessage ="El campo {0} es requerido.")]
        public String Nombre { get; set; }

        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        [Required(ErrorMessage = "El campo usuario enmcargado es requerido.")]
        public int IdUsuarioEncargado { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int IdUsuario { get; set; }
        public Boolean IsEliminado { get; set; }

        //Campos inner con join tabla usuario
        public string NombreUsuario { get; set; }
        public string ApellidoUsuario { get; set; }
        public string _nombreCompletoUsuario;
        public string NombreCompletoUsuario
        {
            get
            {
                _nombreCompletoUsuario = NombreUsuario + " " + ApellidoUsuario;
                return _nombreCompletoUsuario;
            }
            set
            {
                _nombreCompletoUsuario = value;
            }
        }


    }
}
