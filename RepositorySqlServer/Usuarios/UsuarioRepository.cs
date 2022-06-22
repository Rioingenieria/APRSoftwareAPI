using Common.Constantes;
using Models.Response;
using Models.Usuarios;
using RepositoryInterface.Usuarios;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorySqlServer.Usuarios
{
    public class UsuarioRepository : Repository, IUsuarioRepository
    {
        public UsuarioRepository(SqlConnection context, SqlTransaction transaction)
        {
            _context = context;
            _transaction = transaction;
        }
        public int Create(Usuario _usuario)
        {
            var cmd = CreateCommand("INSERT INTO usuarios" +
                                    "   (usuario," +
                                    "   cargo," +
                                    "   nombre," +
                                    "   apellido," +
                                    "   rut," +
                                    "   contraseña," +
                                    "   id_tipo_usuario," +
                                    "   tipo_usuario," +
                                    "   fecha_nacimiento," +
                                    "   email," +
                                    "   contraseñagenerada," +
                                    "   foto_url," +
                                    "   foto," +
                                    "   is_eliminado)" +
                                    "VALUES" +
                                    "   (@usuario," +
                                    "   @cargo," +
                                    "   @nombre," +
                                    "   @apellido," +
                                    "   @rut," +
                                    "   @contraseña," +
                                    "   @id_tipo_usuario," +
                                    "   @tipo_usuario," +
                                    "   @fecha_nacimiento," +
                                    "   @email," +
                                    "   @contraseñagenerada," +
                                    "   @foto_url," +
                                    "   @foto," +
                                    "   @is_eliminado)");
            GetEntity(_usuario, ref cmd);
            var result = cmd.ExecuteNonQuery();
            return result;
        }
        public Usuario CreateEntity(SqlDataReader _usuario)
        {
            Usuario usuario = new Usuario()
            {
                IdUsuario = Convert.ToInt16(_usuario["id_usuario"]),
                NombreUsuario = (_usuario["usuario"] == DBNull.Value) ? string.Empty : Convert.ToString(_usuario["usuario"]),
                Nombre = _usuario["nombre"].ToString() == String.Empty ? string.Empty : Convert.ToString(_usuario["nombre"]),
                Apellido = _usuario["apellido"].ToString() == String.Empty ? string.Empty : Convert.ToString(_usuario["apellido"]),
                Rut = _usuario["rut"] == DBNull.Value ? string.Empty : Convert.ToString(_usuario["rut"]),
                Cargo = _usuario["cargo"].ToString() == String.Empty ? string.Empty : Convert.ToString(_usuario["cargo"]),
                Contraseña = _usuario["contraseña"].ToString() == String.Empty ? string.Empty : Convert.ToString(_usuario["contraseña"]),
                IdTipoUsuario = _usuario["id_tipo_usuario"].ToString() == String.Empty ? 0 : Convert.ToInt16(_usuario["id_tipo_usuario"]),
                TipoUsuario = _usuario["tipo_usuario"].ToString() == String.Empty ? string.Empty : Convert.ToString(_usuario["tipo_usuario"]),
                FechaNacimiento = _usuario["fecha_nacimiento"].ToString() == String.Empty ? DateTime.Parse(NumerosYFechas.DateMinValue) : Convert.ToDateTime(_usuario["fecha_nacimiento"]),
                Email = _usuario["email"].ToString() == String.Empty ? string.Empty : Convert.ToString(_usuario["email"]),
                ContraseñaGenerada = _usuario["contraseñagenerada"].ToString() == "" ? false : Convert.ToBoolean(_usuario["contraseñagenerada"]),
                FotoUrl = _usuario["foto_url"].ToString() == String.Empty ? string.Empty : Convert.ToString(_usuario["foto_url"]),
                Foto = _usuario["foto"].ToString() == "" ? null : (byte[])_usuario["foto"],
                IsEliminado = _usuario["is_eliminado"].ToString() == "" ? false : Convert.ToBoolean(_usuario["is_eliminado"])
            };
            return usuario;
        }
        public List<Usuario> GetAll()
        {
            List<Usuario> result = new List<Usuario>();
            SqlCommand cmd = CreateCommand("SELECT * FROM usuarios");
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(CreateEntity(reader));
                }
            }
            return result;
        }
        public List<Usuario> GetAllIdNombreApellido()
        {
            var result = new List<Usuario>();
            var cmd = CreateCommand("SELECT id_usuario,CONCAT(nombre,' ',apellido) AS nombre FROM usuarios");
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new Usuario()
                    {
                        IdUsuario = Convert.ToInt32(reader["id_usuario"]),
                        Nombre = Convert.ToString(reader["nombre"])
                    });
                }
            }
            return result;
        }
        public Usuario GetById(int id)
        {
            Usuario result = new Usuario();
            SqlCommand cmd = CreateCommand("SELECT * FROM usuarios " +
                                            "WHERE id_usuario=@id_usuario");
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
        public bool IsExistNombreUsuario(string _nombre)
        {
            var cmd = CreateCommand("SELECT*FROM usuarios " +
                "WHERE usuario=@nombre");
            cmd.Parameters.AddWithValue("@nombre", _nombre);
            using (var reader = cmd.ExecuteReader())
            {
                reader.Read();
                return reader.HasRows;
            }
        }     
        public int Update(Usuario _usuario)
        {
            var cmd = CreateCommand("UPDATE usuarios" +
                                    "   SET usuario = @usuario" +
                                    "      ,cargo = @cargo" +
                                    "      ,nombre = @nombre" +
                                    "      ,apellido = @apellido" +
                                    "      ,rut = @rut" +
                                    "      ,contraseña = @contraseña" +
                                    "      ,id_tipo_usuario = @id_tipo_usuario" +
                                    "      ,tipo_usuario = @tipo_usuario" +
                                    "      ,fecha_nacimiento = @fecha_nacimiento" +
                                    "      ,email = @email" +
                                    "      ,contraseñagenerada = @contraseñagenerada" +
                                    "      ,foto_url = @foto_url" +
                                    "      ,foto = @foto" +
                                    "      ,is_eliminado = @is_eliminado " +
                                    "WHERE id_usuario = @id_usuario");
            GetEntity(_usuario, ref cmd);
            var result = cmd.ExecuteNonQuery();
            return result;
        }
        private void GetEntity(Usuario _usuario, ref SqlCommand cmd)
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
        }
        public int UpdateSoftDelete(int _id, bool _isEliminado)
        {
            var cmd = CreateCommand("UPDATE usuarios " +
                                    "   SET is_eliminado = @isEliminado " +
                                    "WHERE id_usuario = @id_usuario ");
            cmd.Parameters.AddWithValue("@id_usuario", _id);
            cmd.Parameters.AddWithValue("@isEliminado", _isEliminado);
            return cmd.ExecuteNonQuery();
        }
        public int Remove(Usuario _usuario)
        {
            var cmd = CreateCommand("DELETE FROM usuarios " +
                                    "WHERE id_usuario = @id_usuario");
            cmd.Parameters.AddWithValue("@id_usuario", _usuario.IdUsuario);
            return cmd.ExecuteNonQuery();
        }

        public UsuarioResponse AuthUsuarioAPI(Usuario _usuario)
        {
            UsuarioResponse usuarioResponse = null;
            var cmd = CreateCommand("select usuario,contraseña from usuarios where usuario=@usuario and contraseña=@contraseña");
            cmd.Parameters.AddWithValue("@usuario", _usuario.NombreUsuario);
            cmd.Parameters.AddWithValue("@contraseña", _usuario.Contraseña);

            using (var reader = cmd.ExecuteReader())
            {
                usuarioResponse = new UsuarioResponse() {
                    UsuarioNombre= Convert.ToString(reader["usuario"]),
                    Token=""                 
             };


            }
            return usuarioResponse;

        }
    }
}
