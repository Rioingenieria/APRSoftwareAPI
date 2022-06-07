using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ProveedoresNew
{
    public class ProveedorNew
    {
        private int _id_proveedor;
        private string _nombre;
        private string _ciudad;
        private string _telefono;
        private string _email;
        private string _descripcion;
        private int _id_dato_facturacion;
        private Boolean _is_eliminado;

        public Boolean is_eliminado
        {
            get { return _is_eliminado; }
            set { _is_eliminado = value; }
        }

        public int id_dato_facturacion
        {
            get { return _id_dato_facturacion; }
            set { _id_dato_facturacion = value; }
        }

        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public string email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        public string ciudad
        {
            get { return _ciudad; }
            set { _ciudad = value; }
        }

        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public int id_proveedor
        {
            get { return _id_proveedor; }
            set { _id_proveedor = value; }
        }

    }
}
