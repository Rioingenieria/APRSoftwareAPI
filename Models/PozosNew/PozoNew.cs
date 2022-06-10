using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.PozosNew
{
    public class PozoNew
    {
        private int _idPozo;
        private string _nombre;
        private string _descripcion;
        private Boolean _is_eliminado;

        public Boolean isEliminado
        {
            get { return _is_eliminado; }
            set { _is_eliminado = value; }
        }

        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public int idPozo
        {
            get { return _idPozo; }
            set { _idPozo = value; }
        }

    }
}
