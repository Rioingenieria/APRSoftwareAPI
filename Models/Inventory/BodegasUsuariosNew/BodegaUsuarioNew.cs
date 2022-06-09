using Models.Inventory.BodegasNew;
using Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Inventory.BodegasUsuariosNew
{
    public class BodegaUsuarioNew
    {
        private BodegaNew _bodegaNew;
        private Usuario _usuario;
        public BodegaNew BodegaNew
        {
            get { return _bodegaNew; }
            set { _bodegaNew = value; }
        }
        public Usuario Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }
    }
}
