using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ProductosCategoriasNew
{
    public class ProductoCategoriaNew
    {
        private int _id_producto_categoria;
        private string _nombre;
        private string _descripcion;
        private Boolean _is_eliminado;
        private int _id_usuario;
        private DateTime _fecha_creacion;

        public DateTime fechaCreacion
        {
            get { return _fecha_creacion; }
            set { _fecha_creacion = value; }
        }

        public int idUsuario
        {
            get { return _id_usuario; }
            set { _id_usuario = value; }
        }

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

        public int idProductoCategoria
        {
            get { return _id_producto_categoria; }
            set { _id_producto_categoria = value; }
        }

    }
}
