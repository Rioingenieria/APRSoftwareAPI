using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.RedesNew
{
    public class RedNew
    {
        private int _idRed;
        private int _idMatriz;
        private Decimal _presionRed;
        private Decimal _profundidadRed;
        private string  _nombre;
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

        public string  nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public Decimal profundidadRed
        {
            get { return _profundidadRed; }
            set { _profundidadRed = value; }
        }

        public Decimal presionRed
        {
            get { return _presionRed; }
            set { _presionRed = value; }
        }

        public int idMatriz
        {
            get { return _idMatriz; }
            set { _idMatriz = value; }
        }

        public int idRed
        {
            get { return _idRed; }
            set { _idRed = value; }
        }

    }
}
