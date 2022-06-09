using Models.Inventory.BodegasNew;
using Models.Inventory.BodegasUsuariosNew;
using Models.Usuarios;
using RepositoryInterface.Inventory.BodegasUsuariosNew;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorySqlServer.Inventory.BodegasUsuariosNew
{
    public class BodegaUsuarioNewRepository : Repository, IBodegaUsuarioNewRepository
    {
        public BodegaUsuarioNewRepository(SqlConnection context, SqlTransaction transaction)
        {
            _context = context;
            _transaction = transaction;
        }

        public int Create(BodegaUsuarioNew t)
        {
            throw new NotImplementedException();
        }

        public BodegaUsuarioNew CreateEntity(SqlDataReader _bodegaUsuarioNew)
        {
            BodegaNew bodegaNew = new BodegaNew()
            {
                IdBodega = Convert.ToInt32(_bodegaUsuarioNew["id_bodega"]),
                Nombre = Convert.ToString(_bodegaUsuarioNew["nombre"]),
                Descripcion = Convert.ToString(_bodegaUsuarioNew["descripcion"]),
                Direccion = Convert.ToString(_bodegaUsuarioNew["direccion"]),
                Telefono = Convert.ToString(_bodegaUsuarioNew["telefono"]),
                Correo = Convert.ToString(_bodegaUsuarioNew["correo"]),
                IdUsuario = Convert.ToInt32(_bodegaUsuarioNew["id_usuario"]),
                IdUsuarioEncargado = Convert.ToInt16(_bodegaUsuarioNew["id_usuario_encargado"]),
                FechaCreacion = Convert.ToDateTime(_bodegaUsuarioNew["fecha_creacion"]),
                IsEliminado = Convert.ToBoolean(_bodegaUsuarioNew["is_eliminado"])
            };
            //bodegaNew.IdBodega = Convert.ToInt32(_bodegaUsuarioNew["id_bodega"]);
            //bodegaNew.Nombre = Convert.ToString(_bodegaUsuarioNew["nombre"]);
            //bodegaNew.Descripcion = Convert.ToString(_bodegaUsuarioNew["descripcion"]);
            //bodegaNew.Direccion = Convert.ToString(_bodegaUsuarioNew["direccion"]);
            //bodegaNew.Telefono = Convert.ToString(_bodegaUsuarioNew["telefono"]);
            //bodegaNew.Correo = Convert.ToString(_bodegaUsuarioNew["correo"]);
            //bodegaNew.IdUsuario = Convert.ToInt32(_bodegaUsuarioNew["id_usuario"]);
            //bodegaNew.IdUsuarioEncargado = Convert.ToInt16(_bodegaUsuarioNew["id_usuario_encargado"]);
            //bodegaNew.FechaCreacion = Convert.ToDateTime(_bodegaUsuarioNew["fecha_creacion"]);
            //bodegaNew.IsEliminado = Convert.ToBoolean(_bodegaUsuarioNew["is_eliminado"]);
            Usuario usuario = new Usuario()
            {
                IdUsuario = Convert.ToInt32(_bodegaUsuarioNew["id_usuario"]),
                NombreUsuario = Convert.ToString(_bodegaUsuarioNew["usuario"]),
                Nombre = Convert.ToString(_bodegaUsuarioNew["nombre"]),
                Apellido = Convert.ToString(_bodegaUsuarioNew["apellido"]),
                Rut = Convert.ToString(_bodegaUsuarioNew["rut"]),
                Cargo = Convert.ToString(_bodegaUsuarioNew["cargo"]),
                Contraseña = Convert.ToString(_bodegaUsuarioNew["contraseña"]),
                IdTipoUsuario = Convert.ToInt16(_bodegaUsuarioNew["id_tipo_usuario"]),
                TipoUsuario = Convert.ToString(_bodegaUsuarioNew["tipo_usuario"]),
                FechaNacimiento = Convert.ToDateTime(_bodegaUsuarioNew["fecha_nacimiento"]),
                Email = Convert.ToString(_bodegaUsuarioNew["email"]),
                ContraseñaGenerada = Convert.ToBoolean(_bodegaUsuarioNew["contraseñagenerada"]),
                FotoUrl = Convert.ToString(_bodegaUsuarioNew["foto_url"]),
                //Foto = (byte[])_bodegaUsuarioNew["foto"],
                IsEliminado = Convert.ToBoolean(_bodegaUsuarioNew["is_eliminado"])
            };
            BodegaUsuarioNew bodegaUsuarioNew = new BodegaUsuarioNew()
            {
                BodegaNew = bodegaNew,
                Usuario = usuario
            };
            return bodegaUsuarioNew;
        }

        public List<BodegaUsuarioNew> GetAll()
        {
            var result = new List<BodegaUsuarioNew>();
            var cmd = CreateCommand("SELECT * FROM bodegas_new a " +
                                    "INNER JOIN usuarios b " +
                                    "ON a.id_usuario_encargado=b.id_usuario");
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(CreateEntity(reader));
                }
            }
            return result;
        }
        public BodegaUsuarioNew GetById(int id)
        {
            BodegaUsuarioNew result = new BodegaUsuarioNew();
            var cmd = CreateCommand("SELECT * FROM bodegas_new a " +
                                    "INNER JOIN usuarios b " +
                                    "ON a.id_usuario_encargado=b.id_usuario " +
                                    "WHERE a.id_usuario_encargado=@id_usuario");
            cmd.Parameters.AddWithValue("@id_usuario", id);
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    result = CreateEntity(reader);
                }
            }
            return result;
        }

        public int Remove(BodegaUsuarioNew id)
        {
            throw new NotImplementedException();
        }

        public int Update(BodegaUsuarioNew t)
        {
            throw new NotImplementedException();
        }

        public int UpdateSoftDelete(int _id, bool _isEliminado)
        {
            throw new NotImplementedException();
        }

        private void GetEntity(BodegaUsuarioNew _bodegaUsuarioNew, ref SqlCommand cmd, BodegaNew _bodegaNew, Usuario _usuario)
        {
            cmd.Parameters.AddWithValue("@id_usuario", _usuario.IdUsuario);
            cmd.Parameters.AddWithValue("@usuario", _usuario.NombreUsuario);
            cmd.Parameters.AddWithValue("@cargo", _usuario.Cargo);
            cmd.Parameters.AddWithValue("@nombre", _usuario.Nombre);
            cmd.Parameters.AddWithValue("@apellido", _usuario.Apellido);
            cmd.Parameters.AddWithValue("@rut", _usuario.Rut);
            cmd.Parameters.AddWithValue("@contraseña", _usuario.Contraseña);
            cmd.Parameters.AddWithValue("@id_tipo_usuario", _usuario.IdTipoUsuario);
            cmd.Parameters.AddWithValue("@tipo_usuario", _usuario.TipoUsuario);
            cmd.Parameters.AddWithValue("@fecha_nacimiento", _usuario.FechaNacimiento);
            cmd.Parameters.AddWithValue("@email", _usuario.Email);
            cmd.Parameters.AddWithValue("@contraseñagenerada", _usuario.ContraseñaGenerada);
            cmd.Parameters.AddWithValue("@foto_url", _usuario.FotoUrl);
            cmd.Parameters.AddWithValue("@foto", _usuario.Foto);
            cmd.Parameters.AddWithValue("@is_eliminado", _usuario.IsEliminado);
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
    }
}
