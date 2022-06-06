using Models.ProductosNew;
using RepositoryInterface.ProductosNew;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorySqlServer.ProductosNew
{
    public class ProductoNewRepository : Repository, IProductoNewRepository
    {
        public ProductoNewRepository(SqlConnection context, SqlTransaction transaction)
        {
            _context = context;
            _transaction = transaction;
        }
        public int Create(ProductoNew t)
        {
            var cmd = CreateCommand("INSERT INTO productos_new (nombre,descripcion,existencia,precio,costo,unidad_medida_estado," +
                "codigo,id_usuario,fecha_creacion,is_eliminado,sku,id_proveedor,id_bodega,id_categoria_producto,id_estado_estado)" +
                "VALUES(@nombre,@descripcion,@existencia,@precio,@costo,@unidad_medida_estado,@codigo,@id_usuario,@fecha_creacion," +
                "@is_eliminado,@sku,@id_proveedor,@id_bodega,@id_categoria_producto,@id_estado_estado)");
            cmd.Parameters.AddWithValue("@nombre",t.nombre);
            cmd.Parameters.AddWithValue("@descripcion",t.descripcion);
            cmd.Parameters.AddWithValue("@existencia",t.existencia);
            cmd.Parameters.AddWithValue("@precio",t.precio);
            cmd.Parameters.AddWithValue("@costo",t.costo);
            cmd.Parameters.AddWithValue("@unidad_medida_estado",t.unidad_medida_estado);
            cmd.Parameters.AddWithValue("@codigo",t.codigo);
            cmd.Parameters.AddWithValue("@id_usuario",t.id_usuario);
            cmd.Parameters.AddWithValue("@fecha_creacion",t.fecha_creacion);
            cmd.Parameters.AddWithValue("@is_eliminado",t.is_eliminado);
            cmd.Parameters.AddWithValue("@sku",t.sku);
            cmd.Parameters.AddWithValue("@id_proveedor",t.id_proveedor);
            cmd.Parameters.AddWithValue("@id_bodega",t.id_bodega);
            cmd.Parameters.AddWithValue("@id_categoria_producto",t.id_categoria_producto);
            cmd.Parameters.AddWithValue("@id_estado_estado",t.id_estado_estado);
            return cmd.ExecuteNonQuery();

        }

        public ProductoNew CreateEntity(SqlDataReader dr)
        {
            var producto=new ProductoNew() 
            {
                id_producto=Convert.ToInt16(dr["id_producto"]),
                nombre=Convert.ToString(dr["nombre"]),
                descripcion=Convert.ToString(dr["descripcion"]),
                existencia=Convert.ToDecimal(dr["existencia"]),
                precio=Convert.ToDecimal(dr["precio"]),
                costo=Convert.ToDecimal(dr["costo"]),
                unidad_medida_estado=Convert.ToInt16(dr["unidad_medida_estado"]),
                codigo=Convert.ToString(dr["codigo"]),
                id_usuario=Convert.ToInt16(dr["id_usuario"]),
                fecha_creacion=Convert.ToDateTime(dr["fecha_creacion"]),
                is_eliminado=Convert.ToBoolean(dr["is_eliminado"]),
                sku=Convert.ToString(dr["sku"]),
                id_proveedor=Convert.ToInt16(dr["id_proveedor"]),
                id_bodega=Convert.ToInt16(dr["id_bodega"]),
                id_categoria_producto=Convert.ToInt16(dr["id_categoria_producto"]),
                id_estado_estado=Convert.ToInt16(dr["id_estado_estado"])

            };
            return producto;
        }

        public List<ProductoNew> GetAll()
        {
            var cmd = CreateCommand("SELECT*FROM productos_new");
            List<ProductoNew> listProducts = new List<ProductoNew>();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read()) { listProducts.Add(CreateEntity(reader)); }
            }
            return listProducts;
        }

        public List<ProductoNew> GetByCodigo(string codigo)
        {
            var cmd = CreateCommand("SELECT*FROM productos_new WHERE codigo=@codigo");
            cmd.Parameters.AddWithValue("@codigo", codigo);
            List<ProductoNew> listProducts = new List<ProductoNew>();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read()) { listProducts.Add(CreateEntity(reader)); }
            }
            return listProducts;
        }

        public ProductoNew GetById(int id)
        {
            var cmd = CreateCommand("SELECT*FROM productos_new WHERE id_producto=@id");
            cmd.Parameters.AddWithValue("@id", id);
            var producto = new ProductoNew();
            using (var reader = cmd.ExecuteReader()) { reader.Read(); return producto = CreateEntity(reader); }
        }

        public bool IsExistCodigo(string codigo)
        {
            var cmd = CreateCommand("SELECT*FROM productos_new WHERE codigo=@codigo");
            cmd.Parameters.AddWithValue("@codigo", codigo);
            using (var reader = cmd.ExecuteReader())
            { 
                if (reader.Read()) {return true;}
            }
            return false;
        }

        public int Remove(int id)
        {
            var cmd = CreateCommand("DELETE productos_new WHERE id_producto=@id");
            cmd.Parameters.AddWithValue("@id", id);
            return cmd.ExecuteNonQuery();
        }

        public int Update(ProductoNew t)
        {
            var cmd = CreateCommand("UPDATE productos_new SET nombre=@nombre,descripcion=descripcion," +
                "existencia=@existencia,precio=@precio,costo=@costo,unidad_medida_estado=@unidad_medida_estado," +
                "codigo=@codigo,id_usuario=@id_usuario,fecha_creacion=@fecha_creacion,is_eliminado=@is_eliminado,sku=@sku" +
                ",id_proveedor=@id_proveedor,id_bodega=@id_bodega,id_categoria_producto=@id_categoria_producto,id_estado_estado=@id_estado_estado " +
                "WHERE id_producto=@id_producto");
            cmd.Parameters.AddWithValue("@id_producto", t.id_producto);
            cmd.Parameters.AddWithValue("@nombre", t.nombre);
            cmd.Parameters.AddWithValue("@descripcion", t.descripcion);
            cmd.Parameters.AddWithValue("@existencia", t.existencia);
            cmd.Parameters.AddWithValue("@precio", t.precio);
            cmd.Parameters.AddWithValue("@costo", t.costo);
            cmd.Parameters.AddWithValue("@unidad_medida_estado", t.unidad_medida_estado);
            cmd.Parameters.AddWithValue("@codigo", t.codigo);
            cmd.Parameters.AddWithValue("@id_usuario", t.id_usuario);
            cmd.Parameters.AddWithValue("@fecha_creacion", t.fecha_creacion);
            cmd.Parameters.AddWithValue("@is_eliminado", t.is_eliminado);
            cmd.Parameters.AddWithValue("@sku", t.sku);
            cmd.Parameters.AddWithValue("@id_proveedor", t.id_proveedor);
            cmd.Parameters.AddWithValue("@id_bodega", t.id_bodega);
            cmd.Parameters.AddWithValue("@id_categoria_producto", t.id_categoria_producto);
            cmd.Parameters.AddWithValue("@id_estado_estado", t.id_estado_estado);
            return cmd.ExecuteNonQuery();

        }

        public int UpdateSoftDelete(int _id, bool _isEliminado)
        {
            var cmd = CreateCommand("UPDATE productos_new set is_eliminado=@is_eliminado WHERE id_producto=@id_producto");
            cmd.Parameters.AddWithValue("@id_producto", _id);
            cmd.Parameters.AddWithValue("@is_eliminado", _isEliminado);
            return cmd.ExecuteNonQuery();
        }
    }
}
