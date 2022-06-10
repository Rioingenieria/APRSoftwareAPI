using Models.ProductosKitsNew;
using RepositoryInterface.ProductosKitsNewRepository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorySqlServer.ProductosKitsNew
{
    public class ProductoKitNewRepository : Repository, IProductoKitNewRepository
    {
        public ProductoKitNewRepository(SqlConnection context, SqlTransaction transaction)
        {
            _context = context;
            _transaction = transaction;
        }
        public int Create(ProductoKitNew t)
        {
            var cmd = CreateCommand("INSERT INTO productos_kits_new (id_kit,cantidad_producto,id_producto,is_eliminado)" +
                "VALUES" +
                "(@id_kit,@cantidad_producto,@id_producto,@is_eliminado)");
            cmd.Parameters.AddWithValue("@id_kit",t.idKit);
            cmd.Parameters.AddWithValue("@cantidad_producto",t.cantidadProducto);
            cmd.Parameters.AddWithValue("@id_producto",t.idProducto);
            cmd.Parameters.AddWithValue("@is_eliminado",false);
            return cmd.ExecuteNonQuery();
        }

        public ProductoKitNew CreateEntity(SqlDataReader dr)
        {
            ProductoKitNew Producto = new ProductoKitNew() 
            {
                idProducto=Convert.ToInt32(dr["id_producto"]),
                idKit=Convert.ToInt32(dr["id_kit"]),
                cantidadProducto=Convert.ToDecimal(dr["cantidad_producto"]),
                idProductoKit=Convert.ToInt32(dr["id_producto_kit"]),
                isEliminado=Convert.ToBoolean(dr["is_eliminado"])
            };
            return Producto;
        }

        public List<ProductoKitNew> GetAll()
        {
            var cmd = CreateCommand("SELECT* FROM productos_kits_new");
            List<ProductoKitNew> listProduct = new List<ProductoKitNew>();
            using(var reader = cmd.ExecuteReader()) 
            {
                while (reader.Read()) { listProduct.Add(CreateEntity(reader)); }
                return listProduct;
            }
        }

        public ProductoKitNew GetById(int id)
        {
            var cmd = CreateCommand("SELECT* FROM productos_kits_new WHERE id_producto_kit=@id");
            cmd.Parameters.AddWithValue("@id", id);
            using (var reader = cmd.ExecuteReader())
            {
                reader.Read(); { return CreateEntity(reader); }
            }
        }

        public int Remove(int id)
        {
            var cmd = CreateCommand("DELETE productos_kits_new WHERE id_producto_kit=@id");
            cmd.Parameters.AddWithValue("@id", id);
            return cmd.ExecuteNonQuery();
        }

        public int Update(ProductoKitNew t)
        {
            var cmd = CreateCommand("UPDATE productos_kits_new SET id_kit=@id_kit,cantidad_producto=@cantidad_producto," +
                "id_producto=@id_producto" +
                " WHERE id_producto_kit=@id_producto_kit");
            cmd.Parameters.AddWithValue("@id_producto", t.idProducto);
            cmd.Parameters.AddWithValue("@id_kit", t.idKit);
            cmd.Parameters.AddWithValue("@cantidad_producto", t.cantidadProducto);
            cmd.Parameters.AddWithValue("@id_producto_kit", t.idProductoKit);
            return cmd.ExecuteNonQuery();
        }

        public int UpdateSoftDelete(int _id, bool _isEliminado)
        {
            var cmd = CreateCommand("UPDATE productos_kits_new SET is_eliminado=@is_eliminado " +
               "WHERE id_producto_kit=@id_producto");
            cmd.Parameters.AddWithValue("@id_producto", _id);
            cmd.Parameters.AddWithValue("@is_eliminado", _isEliminado);
            return cmd.ExecuteNonQuery();
        }
    }
}
