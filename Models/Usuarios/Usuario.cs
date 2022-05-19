using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Usuarios
{
   public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Rut { get; set; }
        public string Cargo { get; set; }
        public string Contraseña { get; set; }
        public int IdTipoUsuario { get; set; }
        public string TipoUsuario { get; set; }

        public DateTime FechaNacimiento { get; set; }
        public string Email { get; set; }
        public string FotoPath { get; set; }
    }
}
