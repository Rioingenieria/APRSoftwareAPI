using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ProductosNew
{
    public class ProductoNew
    {
        private int _id_Producto;
        private string _nombre;
        private string _descripcion;
        private decimal _existencia;
        private decimal _precio;
        private decimal _costo;
        private int _unidad_medida_estado;
        private string _codigo;
        private int _id_usuario;
        private DateTime _fecha_creacion;
        private Boolean _is_eliminado;
        private string _sku;
        private int _id_proveedor;
        private int _id_bodega;
        private int _id_categoria_producto;
        private int _id_estado_estado;

        public int id_estado_estado
        {
            get { return _id_estado_estado; }
            set { _id_estado_estado = value; }
        }

        public int id_categoria_producto
        {
            get { return _id_categoria_producto; }
            set { _id_categoria_producto = value; }
        }

        public int id_bodega
        {
            get { return _id_bodega; }
            set { _id_bodega = value; }
        }

        public int id_proveedor
        {
            get { return _id_proveedor; }
            set { _id_proveedor = value; }
        }

        public string sku
        {
            get { return _sku; }
            set { _sku = value; }
        }

        public Boolean is_eliminado
        {
            get { return _is_eliminado; }
            set { _is_eliminado = value; }
        }

        public DateTime fecha_creacion
        {
            get { return _fecha_creacion; }
            set { _fecha_creacion = value; }
        }

        public int id_usuario
        {
            get { return _id_usuario; }
            set { _id_usuario = value; }
        }

        public string codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        public int unidad_medida_estado
        {
            get { return _unidad_medida_estado; }
            set { _unidad_medida_estado = value; }
        }

        public decimal costo
        {
            get { return _costo; }
            set { _costo = value; }
        }

        public decimal precio
        {
            get { return _precio; }
            set { _precio = value; }
        }

        public decimal existencia
        {
            get { return _existencia; }
            set { _existencia = value; }
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


        public int id_producto
        {
            get { return _id_Producto; }
            set { _id_Producto = value; }
        }

    }
}
