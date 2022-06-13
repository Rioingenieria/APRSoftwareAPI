using Models.ProveedoresNew;
using RepositoryInterface.ProveedoresNew;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorySqlServer.ProveedoresNew
{
    public class ProveedorNewRepository : Repository, IProveedorNewRepository
    {
        public ProveedorNewRepository(SqlConnection context, SqlTransaction transaction)
        {
            _context = context;
            _transaction = transaction;
        }
        public int Create(ProveedorNew t)
        {
            var cmd = CreateCommand("INSERT INTO proveedores_new (nombre,ciudad,telefono,email,descripcion," +
              "id_dato_facturacion,is_eliminado)" +
              "VALUES(@nombre,@ciudad,@telefono,@email,@descripcion,@id_dato_facturacion,@is_eliminado)");
            cmd.Parameters.AddWithValue("@nombre", t.nombre);
            cmd.Parameters.AddWithValue("@ciudad", t.ciudad);
            cmd.Parameters.AddWithValue("@telefono", t.telefono);
            cmd.Parameters.AddWithValue("@email", t.email);
            cmd.Parameters.AddWithValue("@descripcion", t.descripcion);
            cmd.Parameters.AddWithValue("@id_dato_facturacion", t.idDatoFacturacion);
            cmd.Parameters.AddWithValue("@is_eliminado", false);
            return cmd.ExecuteNonQuery();
        }

        public ProveedorNew CreateEntity(SqlDataReader dr)
        {
            ProveedorNew proveedorNew = new ProveedorNew() 
            {
                idProveedor=Convert.ToInt32(dr["id_proveedor"]),
                nombre=Convert.ToString(dr["nombre"]),
                ciudad=Convert.ToString(dr["ciudad"]),
                telefono=Convert.ToString(dr["telefono"]),
                email=Convert.ToString(dr["email"]),
                descripcion=Convert.ToString(dr["descripcion"]),
                idDatoFacturacion=Convert.ToInt32(dr["id_dato_facturacion"]),
                isEliminado=Convert.ToBoolean(dr["is_eliminado"]),
            };
            return proveedorNew;
        }

        public List<ProveedorNew> GetAll()
        {
            var cmd = CreateCommand("SELECT*FROM Proveedores_new");
            List<ProveedorNew> listProducts = new List<ProveedorNew>();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read()) { listProducts.Add(CreateEntity(reader)); }
            }
            return listProducts;
        }

        public ProveedorNew GetById(int id)
        {
            var cmd = CreateCommand("SELECT*FROM Proveedores_new WHERE id_proveedor=@id");
            cmd.Parameters.AddWithValue("@id", id);
            var producto = new ProveedorNew();
            using (var reader = cmd.ExecuteReader()) { reader.Read(); return producto = CreateEntity(reader); }
        }

        public int Remove(int id)
        {
            var cmd = CreateCommand("DELETE Proveedores_new WHERE id_proveedor=@id");
            cmd.Parameters.AddWithValue("@id", id);
            return cmd.ExecuteNonQuery();
        }

        public int Update(ProveedorNew t)
        {
            var cmd = CreateCommand("UPDATE proveedores_new SET nombre=@nombre,ciudad=@ciudad,telefono=@telefono," +
                "email=@email,descripcion=@descripcion,id_dato_facturacion=@id_dato_facturacion,is_eliminado=@is_eliminado" +
                " WHERE id_proveedor=@id_proveedor");
            cmd.Parameters.AddWithValue("@id_proveedor", t.idProveedor);
            cmd.Parameters.AddWithValue("@nombre", t.nombre);
            cmd.Parameters.AddWithValue("@ciudad", t.ciudad);
            cmd.Parameters.AddWithValue("@telefono", t.telefono);
            cmd.Parameters.AddWithValue("@email", t.email);
            cmd.Parameters.AddWithValue("@descripcion", t.descripcion);
            cmd.Parameters.AddWithValue("@id_dato_facturacion", t.idDatoFacturacion);
            cmd.Parameters.AddWithValue("@is_eliminado", t.isEliminado);
            return cmd.ExecuteNonQuery();
        }

        public int UpdateSoftDelete(int _id, bool _isEliminado)
        {
            var cmd = CreateCommand("UPDATE proveedores_new SET is_eliminado=@is_eliminado" +
               " WHERE id_proveedor=@id_proveedor");
            cmd.Parameters.AddWithValue("@id_proveedor", _id);
            cmd.Parameters.AddWithValue("@is_eliminado", _isEliminado);
            return cmd.ExecuteNonQuery();
        }
    }
}
