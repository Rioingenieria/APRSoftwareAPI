using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ProductosKitsNew
{
    public class ProductoKitNew
    {
        private int _idProducto;
        private int _idKit;
        private decimal _cantidadProducto;
        private int _idProductoKit;
        private Boolean _isEliminado;

        public Boolean isEliminado
        {
            get { return _isEliminado; }
            set { _isEliminado = value; }
        }

        public int idProductoKit
        {
            get { return _idProductoKit; }
            set { _idProductoKit = value; }
        }

        public decimal cantidadProducto
        {
            get { return _cantidadProducto; }
            set { _cantidadProducto = value; }
        }

        public int idKit
        {
            get { return _idKit; }
            set { _idKit = value; }
        }

        public int idProducto
        {
            get { return _idProducto; }
            set { _idProducto = value; }
        }

    }
}
