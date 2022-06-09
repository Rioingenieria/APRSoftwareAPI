using Models.Inventory.BodegasNew;
using RepositoryInterface.Inventory.BodegasNew;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorySqlServer.Inventory.BodegasNew
{
    public class BodegaNewRepository : Repository, IBodegaNewRepository
    {
        public BodegaNewRepository(SqlConnection context, SqlTransaction transaction)
        {
            _context = context;
            _transaction = transaction;
        }
        private static void GetEntity(BodegaNew _bodegaNew, ref SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@id_bodega", _bodegaNew.IdBodega);
            cmd.Parameters.AddWithValue("@nombre", _bodegaNew.Nombre);
            cmd.Parameters.AddWithValue("@descripcion", _bodegaNew.Descripcion);
            cmd.Parameters.AddWithValue("@direccion", _bodegaNew.Direccion);
            cmd.Parameters.AddWithValue("@telefono", _bodegaNew.Telefono);
            cmd.Parameters.AddWithValue("@correo", _bodegaNew.Correo);
            cmd.Parameters.AddWithValue("@id_usuario", _bodegaNew.IdUsuario);
            cmd.Parameters.AddWithValue("@fecha_creacion", _bodegaNew.FechaCreacion);
            cmd.Parameters.AddWithValue("@id_usuario_encargado", _bodegaNew.IdUsuarioEncargado);
            cmd.Parameters.AddWithValue("@is_eliminado", false);
        }
        public BodegaNew CreateEntity(SqlDataReader _bodegaNew)
        {
            BodegaNew bodega = new BodegaNew()
            {
                IdBodega = Convert.ToInt16(_bodegaNew["id_bodega"]),
                Nombre = Convert.ToString(_bodegaNew["nombre"]),
                Descripcion = Convert.ToString(_bodegaNew["descripcion"]),
                Direccion = Convert.ToString(_bodegaNew["direccion"]),
                Telefono = Convert.ToString(_bodegaNew["telefono"]),
                Correo = Convert.ToString(_bodegaNew["correo"]),
                FechaCreacion = Convert.ToDateTime(_bodegaNew["fecha_creacion"]),
                IdUsuario = Convert.ToInt16(_bodegaNew["id_usuario"]),
                IdUsuarioEncargado = Convert.ToInt16(_bodegaNew["id_usuario_encargado"]),
                IsEliminado = Convert.ToBoolean(_bodegaNew["is_eliminado"])
            };
            return bodega;
        }
        public int Create(BodegaNew _bodegaNew)
        {
            var cmd = CreateCommand("INSERT INTO bodegas_new" +
                                    "       (nombre," +
                                    "       descripcion," +
                                    "       direccion," +
                                    "       telefono," +
                                    "       correo," +
                                    "       id_usuario," +
                                    "       fecha_creacion," +
                                    "       id_usuario_encargado," +
                                    "       is_eliminado)" +
                                    "   VALUES" +
                                    "       (@nombre," +
                                    "       @descripcion," +
                                    "       @direccion," +
                                    "       @telefono," +
                                    "       @correo," +
                                    "       @id_usuario," +
                                    "       @fecha_creacion," +
                                    "       @id_usuario_encargado," +
                                    "       @is_eliminado)");
            GetEntity(_bodegaNew,ref cmd);
            var result = cmd.ExecuteNonQuery();
            return result;
        }
        public List<BodegaNew> GetAll()
        {
            var result = new List<BodegaNew>();
            var cmd = CreateCommand("SELECT id_bodega" +
                                    "      ,nombre" +
                                    "      ,descripcion" +
                                    "      ,direccion" +
                                    "      ,telefono" +
                                    "      ,correo" +
                                    "      ,id_usuario" +
                                    "      ,id_usuario_encargado" +
                                    "      ,fecha_creacion" +
                                    "      ,is_eliminado" +
                                    "  FROM bodegas_new");
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(CreateEntity(reader));
                }
            }
            return result;
        }

        public BodegaNew GetById(int _idBodega)
        {
            var result = new BodegaNew();
            var cmd = CreateCommand("SELECT*FROM bodegas_new " +
                                    "WHERE id_bodega=@id_bodega");
            cmd.Parameters.AddWithValue("@id_bodega", _idBodega);
            using (var reader = cmd.ExecuteReader())
            {
                reader.Read();
                return CreateEntity(reader);
            }
        }
        public bool IsExistNombreBodega(string _bodegaNew)
        {
            var result = new BodegaNew();
            var cmd = CreateCommand("SELECT*FROM bodegas_new " +
                                    "WHERE nombre=@nombre");
            cmd.Parameters.AddWithValue("@nombre", _bodegaNew);
            using (var reader = cmd.ExecuteReader())
            {
                reader.Read();
                return reader.HasRows;
            }
        }

        public int Remove(BodegaNew _idBodega)
        {
            var cmd = CreateCommand("DELETE FROM bodegas_new " +
                                    "WHERE id_bodega=@id_bodega");
            cmd.Parameters.AddWithValue("@id_bodega", _idBodega.IdBodega);
            return cmd.ExecuteNonQuery();
        }

        public int Update(BodegaNew _bodegaNew)
        {
            var cmd = CreateCommand("UPDATE bodegas_new " +
                "SET nombre=@nombre," +
                "descripcion=@descripcion," +
                "direccion=@direccion," +
                "id_usuario=@id_usuario," +
                "id_usuario_encargado=@id_usuario_encargado " +
                "WHERE id_bodega=@id_bodega");
            GetEntity(_bodegaNew, ref cmd);
            var result = cmd.ExecuteNonQuery();
            return result;
        }

        public int UpdateSoftDelete(int _idBodega, Boolean _isEliminado)
        {
            var cmd = CreateCommand("UPDATE bodegas_new " +
                                    "SET is_eliminado=@is_eliminado " +
                                    "WHERE id_bodega=@id_bodega");
            cmd.Parameters.AddWithValue("@id_bodega", _idBodega);
            cmd.Parameters.AddWithValue("@is_eliminado", _isEliminado);
            var result = cmd.ExecuteNonQuery();
            return result;
        }
    }
}
