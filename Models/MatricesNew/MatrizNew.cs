using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.MatricesNew
{
    public class MatrizNew
    {
        private int _idMatriz;
        private int _idPozo;
        private string _nombre;
        private string _descripcion;
        private Boolean _isEliminado;

        public Boolean isEliminado
        {
            get { return _isEliminado; }
            set { _isEliminado = value; }
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

        public int idMatriz
        {
            get { return _idMatriz; }
            set { _idMatriz = value; }
        }

    }
}
