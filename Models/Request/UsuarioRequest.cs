using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Request
{
    public class UsuarioRequest
    {
        [Required]
        public string UsuarioNombre { get; set; }
        [Required]
        public string Contrasena { get; set; }

    }
}
