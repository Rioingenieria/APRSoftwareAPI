using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Inventory.ProductosBodegasNew
{
    public class ProductoBodegaNew
    {
        private int _idProducto;
        private int _idBodega;
        private int _idProductoBodega;
        private bool _isEliminado;
        public int IdProducto
        {
            get { return _idProducto; }
            set { _idProducto = value; }
        }
        public int IdBodega
        {
            get { return _idBodega; }
            set { _idBodega = value; }
        }
        public int IdProductoBodega
        {
            get { return _idProductoBodega; }
            set { _idProductoBodega = value; }
        }
        public bool IsEliminado
        {
            get { return _isEliminado; }
            set { _isEliminado = value; }
        }
    }
}
