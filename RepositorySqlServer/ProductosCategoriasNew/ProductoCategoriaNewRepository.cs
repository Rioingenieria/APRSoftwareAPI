using Models.ProductosCategoriasNew;
using RepositoryInterface.ProductosCategoriaNew;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorySqlServer.ProductosCategoriasNew
{
    public class ProductoCategoriaNewRepository : Repository, IProductoCategoriaNewRepository
    {
        public ProductoCategoriaNewRepository(SqlConnection context, SqlTransaction transaction)
        {
            _context = context;
            _transaction = transaction;
        }
        public int Create(ProductoCategoriaNew t)
        {
            var cmd = CreateCommand("INSERT INTO productos_categorias_new (nombre,descripcion,is_eliminado,id_usuario,fecha_creacion)" +
                "VALUES" +
                "(@nombre,@descripcion,@is_eliminado,@id_usuario,@fecha_creacion)");
            cmd.Parameters.AddWithValue("@nombre", t.nombre);
            cmd.Parameters.AddWithValue("@descripcion",t.descripcion);
            cmd.Parameters.AddWithValue("@is_eliminado",false);
            cmd.Parameters.AddWithValue("@id_usuario",t.idUsuario);
            cmd.Parameters.AddWithValue("@fecha_creacion",t.fechaCreacion);
            return cmd.ExecuteNonQuery();
        }

        public ProductoCategoriaNew CreateEntity(SqlDataReader dr)
        {
            ProductoCategoriaNew productoCategoria=new ProductoCategoriaNew() 
            {
            idProductoCategoria=Convert.ToInt16(dr["id_producto_categoria"]),
            nombre=Convert.ToString(dr["nombre"]),
            descripcion=Convert.ToString(dr["descripcion"]),
            isEliminado=Convert.ToBoolean(dr["is_eliminado"]),
            idUsuario=Convert.ToInt16(dr["id_usuario"]),
            fechaCreacion=Convert.ToDateTime(dr["fecha_creacion"])
            };
            return productoCategoria;
        }

        public List<ProductoCategoriaNew> GetAll()
        {
            var cmd = CreateCommand("SELECT*FROM productos_categorias_new");
            List<ProductoCategoriaNew> listProducts = new List<ProductoCategoriaNew>();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read()) { listProducts.Add(CreateEntity(reader)); }
            }
            return listProducts;
        }

        public ProductoCategoriaNew GetById(int id)
        {
            var cmd = CreateCommand("SELECT*FROM productos_categorias_new WHERE id_producto_categoria=@id");
            cmd.Parameters.AddWithValue("@id", id);
            var producto = new ProductoCategoriaNew();
            using (var reader = cmd.ExecuteReader()) { reader.Read(); return producto = CreateEntity(reader); }
        }

        public int Remove(int id)
        {
            var cmd = CreateCommand("DELETE productos_categorias_new WHERE id_producto_categoria=@id");
            cmd.Parameters.AddWithValue("@id", id);
            return cmd.ExecuteNonQuery();
        }

        public int Update(ProductoCategoriaNew t)
        {
            var cmd = CreateCommand("UPDATE productos_categorias_new SET nombre=@nombre,descripcion=@descripcion" +
                ",is_eliminado=@is_eliminado,id_usuario=@id_usuario,fecha_creacion=@fecha_creacion " +
                "WHERE id_producto_categoria=@id_producto_categoria");
            cmd.Parameters.AddWithValue("@id_producto_categoria", t.idProductoCategoria);
            cmd.Parameters.AddWithValue("@nombre", t.nombre);
            cmd.Parameters.AddWithValue("@descripcion", t.descripcion);
            cmd.Parameters.AddWithValue("@is_eliminado", t.isEliminado);
            cmd.Parameters.AddWithValue("@id_usuario", t.idUsuario);
            cmd.Parameters.AddWithValue("@fecha_creacion", t.fechaCreacion);
            return cmd.ExecuteNonQuery();
        }

        public int UpdateSoftDelete(int _id, bool _isEliminado)
        {
            var cmd = CreateCommand("UPDATE productos_categorias_new SET is_eliminado=@is_eliminado " +
                "WHERE id_producto_categoria=@id_producto_categoria");
            cmd.Parameters.AddWithValue("@id_producto_categoria", _id);
            cmd.Parameters.AddWithValue("@is_eliminado", _isEliminado);
            return cmd.ExecuteNonQuery();
        }
    }
}
