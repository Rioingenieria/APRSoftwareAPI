using Models.Inventory.ProductosBodegasNew;
using RepositoryInterface.Inventory.ProductosBodegasNew;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorySqlServer.Inventory.ProductosBodegasNew
{
    public class ProductoBodegaNewRepository : Repository, IProductoBodegaNewRepository
    {
        public ProductoBodegaNewRepository(SqlConnection context, SqlTransaction transaction)
        {
            _context = context;
            _transaction = transaction;
        }
        public ProductoBodegaNew CreateEntity(SqlDataReader _productoBodegaNew)
        {
            ProductoBodegaNew productoBodegaNew = new ProductoBodegaNew()
            {
                IdBodega = Convert.ToInt32(_productoBodegaNew["id_bodega"]),
                IdProducto = Convert.ToInt32(_productoBodegaNew["id_producto"]),
                IdProductoBodega = Convert.ToInt32(_productoBodegaNew["id_producto_bodega"]),
                IsEliminado = Convert.ToBoolean(_productoBodegaNew["is_eliminado"])
            };
            return productoBodegaNew;
        }
        private void GetEntity(ProductoBodegaNew _productoBodegaNew, ref SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@id_producto", _productoBodegaNew.IdProducto);
            cmd.Parameters.AddWithValue("@id_bodega", _productoBodegaNew.IdBodega);
            cmd.Parameters.AddWithValue("@id_producto_bodega", _productoBodegaNew.IdProductoBodega);
            cmd.Parameters.AddWithValue("@is_eliminado", _productoBodegaNew.IsEliminado);
        }
        public int Create(ProductoBodegaNew _productoBodegaNew)
        {
            var cmd = CreateCommand("INSERT INTO productos_bodegas_new" +
                                    "   (id_producto," +
                                    "   id_bodega," +
                                    "   is_eliminado)" +
                                    "VALUES" +
                                    "   (@id_producto," +
                                    "   @id_bodega," +
                                    "   @is_eliminado)");
            GetEntity(_productoBodegaNew, ref cmd);
            var result = cmd.ExecuteNonQuery();
            return result;
        }
        public List<ProductoBodegaNew> GetAll()
        {
            List<ProductoBodegaNew> result = new List<ProductoBodegaNew>();
            SqlCommand cmd = CreateCommand("SELECT * FROM productos_bodegas_new");
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(CreateEntity(reader));
                }
            }
            return result;
        }
        public ProductoBodegaNew GetById(int id)
        {
            ProductoBodegaNew result = new ProductoBodegaNew();
            SqlCommand cmd = CreateCommand("SELECT * FROM productos_bodegas_new " +
                                           "WHERE id_producto_bodega = @id_producto_bodega");
            cmd.Parameters.AddWithValue("@id_producto_bodega", id);
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    result = CreateEntity(reader);
                }
            }
            return result;
        }
        public bool IsExistIdBodega(int _idBodega)
        {
            var cmd = CreateCommand("SELECT * FROM bodegas_new " +
                "WHERE id_bodega = @id_bodega");
            cmd.Parameters.AddWithValue("@id_bodega", _idBodega);
            using (var reader = cmd.ExecuteReader())
            {
                reader.Read();
                return reader.HasRows;
            }
        }

        public bool IsExistIdProducto(int _idProducto)
        {
            var cmd = CreateCommand("SELECT * FROM productos_new " +
                "WHERE id_producto = @id_producto");
            cmd.Parameters.AddWithValue("@id_producto", _idProducto);
            using (var reader = cmd.ExecuteReader())
            {
                reader.Read();
                return reader.HasRows;
            }
        }

        public int Remove(ProductoBodegaNew _productoBodegaNew)
        {
            var cmd = CreateCommand("DELETE FROM productos_bodegas_new " +
                                    "WHERE id_producto_bodega = @id_producto_bodega");
            cmd.Parameters.AddWithValue("@id_producto_bodega", _productoBodegaNew.IdProductoBodega);
            return cmd.ExecuteNonQuery();
        }

        public int Update(ProductoBodegaNew _productoBodegaNew)
        {
            var cmd = CreateCommand("UPDATE productos_bodegas_new" +
                                    "   SET id_producto = @id_producto" +
                                    "      ,id_bodega = @id_bodega" +
                                    "      ,is_eliminado = @is_eliminado " +
                                    "WHERE id_producto_bodega = @id_producto_bodega");
            GetEntity(_productoBodegaNew, ref cmd);
            var result = cmd.ExecuteNonQuery();
            return result;
        }

        public int UpdateSoftDelete(int _id, bool _isEliminado)
        {
            var cmd = CreateCommand("UPDATE productos_bodegas_new " +
                                    "   SET is_eliminado = @isEliminado " +
                                    "WHERE id_producto_bodega = @id_producto_bodega ");
            cmd.Parameters.AddWithValue("@id_producto_bodega", _id);
            cmd.Parameters.AddWithValue("@isEliminado", _isEliminado);
            return cmd.ExecuteNonQuery();
        }
    }
}
