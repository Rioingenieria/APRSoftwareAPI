using Models.ClientesNew;
using RepositoryInterface.ClientesNew;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorySqlServer.ClientesNew
{
    public class ClienteNewRepository : Repository, IClienteNewRepository
    {
        public ClienteNewRepository(SqlConnection context,SqlTransaction transaction) 
        {
            _context = context;
            _transaction = transaction;
        }
        public int Create(ClienteNew t)
        {
            var cmd = CreateCommand("INSERT INTO clientes_new (nombre,apellido,rut,domicilio,email,ingreso,tipo_cliente_estado,num_socio,telefono," +
                "num_vivi,genero,fecha_nacimiento,firmar_libro,envio_whatsapp,fecha_creacion,id_usuario,is_eliminado)" +
                "VALUES(@nombre,@apellido,@rut,@domicilio,@email,@ingreso,@tipo_cliente_estado,@num_socio,@telefono,@num_vivi,@genero," +
                "@fecha_nacimiento,@firmar_libro,@envio_whatsapp,@fecha_creacion,@id_usuario,@is_eliminado)");
            cmd.Parameters.AddWithValue("@nombre", t.nombre);
            cmd.Parameters.AddWithValue("@apellido", t.apellido);
            cmd.Parameters.AddWithValue("@rut", t.rut);
            cmd.Parameters.AddWithValue("@domicilio", t.domicilio);
            cmd.Parameters.AddWithValue("@email", t.email);
            cmd.Parameters.AddWithValue("@ingreso", t.ingreso);
            cmd.Parameters.AddWithValue("@tipo_cliente_estado", t.tipoClienteEstado);
            cmd.Parameters.AddWithValue("@num_socio", t.numSocio);
            cmd.Parameters.AddWithValue("@telefono", t.telefono);
            cmd.Parameters.AddWithValue("@num_vivi", t.numVivi);
            cmd.Parameters.AddWithValue("@genero", t.genero);
            cmd.Parameters.AddWithValue("@fecha_nacimiento", t.fechaNacimiento);
            cmd.Parameters.AddWithValue("@firmar_libro", t.firmarLibro);
            cmd.Parameters.AddWithValue("@envio_whatsapp", t.envioWhatsapp);
            cmd.Parameters.AddWithValue("@fecha_creacion", t.fechaCreacion);
            cmd.Parameters.AddWithValue("@id_usuario", t.idUsuario);
            cmd.Parameters.AddWithValue("is_eliminado", false);
            return cmd.ExecuteNonQuery();
        }

        public ClienteNew CreateEntity(SqlDataReader dr)
        {
            ClienteNew cliente= new ClienteNew() 
            {
                idCliente=Convert.ToInt32(dr["id_cliente"]),
                nombre=Convert.ToString(dr["nombre"]),
                apellido=Convert.ToString(dr["apellido"]),
                rut=Convert.ToString(dr["rut"]),
                domicilio=Convert.ToString(dr["domicilio"]),
                email=Convert.ToString(dr["email"]),
                ingreso=Convert.ToDateTime(dr["ingreso"]),
                tipoClienteEstado=Convert.ToInt32(dr["tipo_cliente_estado"]),
                numSocio=Convert.ToInt32(dr["num_socio"]),
                telefono=Convert.ToString(dr["telefono"]),
                numVivi=Convert.ToInt32(dr["num_vivi"]),
                genero=Convert.ToString(dr["genero"]),
                fechaNacimiento=Convert.ToDateTime(dr["fecha_nacimiento"]),
                firmarLibro=Convert.ToBoolean(dr["firmar_libro"]),
                envioWhatsapp=Convert.ToString(dr["envio_whatsapp"]),
                fechaCreacion=Convert.ToDateTime(dr["fecha_creacion"]),
                idUsuario=Convert.ToInt32(dr["id_usuario"]),
                isEliminado=Convert.ToBoolean(dr["is_eliminado"])
            };
            return cliente;
        }

        public List<ClienteNew> GetAll()
        {
            var cmd = CreateCommand("SELECT*FROM clientes_new");
            List<ClienteNew> clientList = new List<ClienteNew>();
            using (var reader = cmd.ExecuteReader()) 
            {
                while (reader.Read()) { clientList.Add(CreateEntity(reader)); }
                return clientList;
            };
        }

        public ClienteNew GetById(int id)
        {
            var cmd = CreateCommand("SELECT*FROM clientes_new WHERE id_cliente=@id_cliente");
            cmd.Parameters.AddWithValue("@id_cliente", id);
            using (var reader = cmd.ExecuteReader())
            {
                reader.Read();
                return CreateEntity(reader);
            };
        }

        public bool IsExitsRutCliente(string _rut)
        {
            var cmd = CreateCommand("SELECT*FROM clientes_new WHERE rut=@rut");
            cmd.Parameters.AddWithValue("@rut", _rut);
            using (var reader = cmd.ExecuteReader())
            {
               if(reader.Read()) { return true; }
            };
            return false;
        }

        public int Remove(int id)
        {
            var cmd = CreateCommand("DELETE clientes_new WHERE id_cliente=@id_cliente ");
            cmd.Parameters.AddWithValue("@id_cliente", id);
            return cmd.ExecuteNonQuery();
        }

        public int Update(ClienteNew t)
        {
            var cmd = CreateCommand("UPDATE clientes_new SET nombre=@nombre,apellido=@apellido,rut=@rut,domicilio=@domicilio,email=@email," +
                "ingreso=@ingreso,tipo_cliente_estado=@tipo_cliente_estado,num_socio=@num_socio,telefono=@telefono,num_vivi=@num_vivi,genero=@genero," +
             "fecha_nacimiento=@fecha_nacimiento,firmar_libro=@firmar_libro,envio_whatsapp=@envio_whatsapp,fecha_creacion=@fecha_creacion,id_usuario=@id_usuario " +
             "WHERE id_cliente=@id_cliente");
            cmd.Parameters.AddWithValue("@id_cliente", t.idCliente);
            cmd.Parameters.AddWithValue("@nombre", t.nombre);
            cmd.Parameters.AddWithValue("@apellido", t.apellido);
            cmd.Parameters.AddWithValue("@rut", t.rut);
            cmd.Parameters.AddWithValue("@domicilio", t.domicilio);
            cmd.Parameters.AddWithValue("@email", t.email);
            cmd.Parameters.AddWithValue("@ingreso", t.ingreso);
            cmd.Parameters.AddWithValue("@tipo_cliente_estado", t.tipoClienteEstado);
            cmd.Parameters.AddWithValue("@num_socio", t.numSocio);
            cmd.Parameters.AddWithValue("@telefono", t.telefono);
            cmd.Parameters.AddWithValue("@num_vivi", t.numVivi);
            cmd.Parameters.AddWithValue("@genero", t.genero);
            cmd.Parameters.AddWithValue("@fecha_nacimiento", t.fechaNacimiento);
            cmd.Parameters.AddWithValue("@firmar_libro", t.firmarLibro);
            cmd.Parameters.AddWithValue("@envio_whatsapp", t.envioWhatsapp);
            cmd.Parameters.AddWithValue("@fecha_creacion", t.fechaCreacion);
            cmd.Parameters.AddWithValue("@id_usuario", t.idUsuario);
            return cmd.ExecuteNonQuery();
        }

        public int UpdateSoftDelete(int _id, bool _isEliminado)
        {
            var cmd = CreateCommand("UPDATE clientes_new SET is_eliminado=@is_eliminado WHERE id_cliente=@id_cliente");
            cmd.Parameters.AddWithValue("@id_cliente", _id);
            cmd.Parameters.AddWithValue("@is_eliminado", _isEliminado);
            return cmd.ExecuteNonQuery();
        }
    }
}
