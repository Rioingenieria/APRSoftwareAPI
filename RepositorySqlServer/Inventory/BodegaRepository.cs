using Models.Inventory;
using RepositoryInterface.Inventory;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorySqlServer.Inventory
{
    public class BodegaRepository : Repository, IBodegaRepository
    {
        public BodegaRepository(SqlConnection context, SqlTransaction transaction)
        {
            _context = context;
            _transaction = transaction;
        }
        public int Create(Bodega _bodega)
        {
            var cmd = CreateCommand("INSERT INTO bodegas_new(nombre,descripcion,direccion,telefono,correo,id_usuario,fecha_creacion,id_usuario_encargado,is_eliminado)" +
                "VALUES(@nombre,@descripcion,@direccion,@telefono,@correo,@id_usuario,@fecha_creacion,@id_usuario_encargado,@is_eliminado)");
            cmd.Parameters.AddWithValue("@nombre", _bodega.Nombre);
            cmd.Parameters.AddWithValue("@descripcion", _bodega.Descripcion);
            cmd.Parameters.AddWithValue("@direccion", _bodega.Direccion);
            cmd.Parameters.AddWithValue("@telefono", _bodega.Telefono);
            cmd.Parameters.AddWithValue("@correo", _bodega.Correo);
            cmd.Parameters.AddWithValue("@id_usuario", _bodega.IdUsuario);
            cmd.Parameters.AddWithValue("@fecha_creacion", _bodega.FechaCreacion);
            cmd.Parameters.AddWithValue("@id_usuario_encargado", _bodega.IdUsuarioEncargado);
            cmd.Parameters.AddWithValue("@is_eliminado", false);

            var result = cmd.ExecuteNonQuery();
            return result;
        }

        public Bodega CreateEntity(SqlDataReader _bodega)
        {
            Bodega bodega = new Bodega()
            {
                IdBodega = Convert.ToInt16(_bodega["id_bodega"]),
                Nombre = Convert.ToString(_bodega["nombre"]),
                Descripcion = Convert.ToString(_bodega["descripcion"]),
                Direccion = Convert.ToString(_bodega["direccion"]),
                Telefono = Convert.ToString(_bodega["telefono"]),
                Correo = Convert.ToString(_bodega["correo"]),
                FechaCreacion = Convert.ToDateTime(_bodega["fecha_creacion"]),
                IdUsuario = Convert.ToInt16(_bodega["id_usuario"]),
                IdUsuarioEncargado = Convert.ToInt16(_bodega["id_usuario_encargado"]),
                IsEliminado = Convert.ToBoolean(_bodega["is_eliminado"])
            };
            return bodega;
        }
        public Bodega CreateEntityInnerJoin(SqlDataReader _bodega)
        {
            Bodega bodega = new Bodega();
            bodega = CreateEntity(_bodega);
            bodega.NombreUsuario = Convert.ToString(_bodega["nombre_usuario"]);
            bodega.ApellidoUsuario = Convert.ToString(_bodega["apellido"]);
            return bodega;
        }
        public List<Bodega> GetAll()
        {
            var result = new List<Bodega>();
            var cmd = CreateCommand("SELECT a.id_bodega,a.nombre,a.descripcion,a.direccion,a.telefono,a.correo,a.fecha_creacion,a.id_usuario,a.id_usuario_encargado,a.is_eliminado,b.nombre as nombre_usuario,b.apellido " +
                "FROM bodegas_new a " +
                "INNER JOIN usuarios b " +
                "ON a.id_usuario_encargado=b.id_usuario " +
                "WHERE a.is_eliminado=@is_eliminado");
            cmd.Parameters.AddWithValue("@is_eliminado", false);
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(CreateEntityInnerJoin(reader));
                }
            }
            return result;
        }

        public Bodega GetById(int _idBodega)
        {
            var result = new Bodega();
            var cmd = CreateCommand("SELECT*FROM bodegas_new " +
                "WHERE id_bodega=@id_bodega");
            cmd.Parameters.AddWithValue("@id_bodega", _idBodega);
            using (var reader = cmd.ExecuteReader())
            {
                reader.Read();
                return CreateEntity(reader);
            }
        }
        public bool IsExistNombreBodega(string _bodega)
        {
            var result = new Bodega();
            var cmd = CreateCommand("SELECT*FROM bodegas_new " +
                "WHERE nombre=@nombre");
            cmd.Parameters.AddWithValue("@nombre", _bodega);
            using (var reader = cmd.ExecuteReader())
            {
                reader.Read();
                return reader.HasRows;
            }
        }

        public int Remove(Bodega _idBodega)
        {
            var cmd = CreateCommand("DELETE FROM bodegas_new " +
                "WHERE id_bodega=@id_bodega");
            cmd.Parameters.AddWithValue("@id_bodega", _idBodega);
            return cmd.ExecuteNonQuery();
        }

        public int Update(Bodega _bodega)
        {
            var cmd = CreateCommand("UPDATE bodegas_new " +
                "SET nombre=@nombre," +
                "descripcion=@descripcion," +
                "direccion=@direccion," +
                "id_usuario=@id_usuario," +
                "id_usuario_encargado=@id_usuario_encargado " +
                "WHERE id_bodega=@id_bodega");
            cmd.Parameters.AddWithValue("@nombre", _bodega.Nombre);
            cmd.Parameters.AddWithValue("@descripcion", _bodega.Descripcion);
            cmd.Parameters.AddWithValue("@direccion", _bodega.Direccion);
            cmd.Parameters.AddWithValue("@telefono", _bodega.Telefono);
            cmd.Parameters.AddWithValue("@correo", _bodega.Correo);
            cmd.Parameters.AddWithValue("@id_usuario", _bodega.IdUsuario);
            cmd.Parameters.AddWithValue("@id_usuario_encargado", _bodega.IdUsuarioEncargado);
            cmd.Parameters.AddWithValue("@id_bodega", _bodega.IdBodega);
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
