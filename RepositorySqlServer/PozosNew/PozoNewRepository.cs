using Models.PozosNew;
using RepositoryInterface.PozosNew;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorySqlServer.PozosNew
{
    public class PozoNewRepository : Repository, IPozoNewRepository
    {
        public PozoNewRepository(SqlConnection context,SqlTransaction transaction)
        {
            _context = context;
            _transaction = transaction;
        }
        public int Create(PozoNew t)
        {
            var cmd = CreateCommand("INSERT INTO pozos_new (nombre,descripcion,is_eliminado)" +
                "VALUES(@nombre,@descripcion,@is_eliminado)");
            cmd.Parameters.AddWithValue("@nombre",t.nombre);
            cmd.Parameters.AddWithValue("@descripcion",t.descripcion);
            cmd.Parameters.AddWithValue("@is_eliminado",false);
            return cmd.ExecuteNonQuery();
        }

        public PozoNew CreateEntity(SqlDataReader dr)
        {
            PozoNew pozo=new PozoNew() 
            {
                idPozo=Convert.ToInt32(dr["id_pozo"]),
                nombre=Convert.ToString(dr["nombre"]),
                descripcion=Convert.ToString(dr["descripcion"]),
                isEliminado=Convert.ToBoolean(dr["is_eliminado"]),
            };
            return pozo;
        }

        public List<PozoNew> GetAll()
        {
            var cmd = CreateCommand("SELECT*FROM pozos_new");
            var listPozos=new List<PozoNew>();
            using(var reader = cmd.ExecuteReader())
            { 
                while (reader.Read()){ listPozos.Add(CreateEntity(reader));
             }
                return listPozos;}
        }

        public PozoNew GetById(int id)
        {
            var cmd = CreateCommand("SELECT*FROM pozos_new WHERE id_pozo=@id_pozo");
            cmd.Parameters.AddWithValue("@id_pozo",id);

            using (var reader = cmd.ExecuteReader())
            {
                reader.Read(); 
                return CreateEntity(reader);
            }
        }

        public int Remove(int id)
        {
            var cmd = CreateCommand("DELETE pozos_new WHERE id_pozo=@id_pozo");
            cmd.Parameters.AddWithValue("@id_pozo", id);
            return cmd.ExecuteNonQuery();
        }

        public int Update(PozoNew t)
        {
            var cmd = CreateCommand("UPDATE pozos_new SET nombre=@nombre,descripcion=@descripcion WHERE id_pozo=@id_pozo");
            cmd.Parameters.AddWithValue("@id_pozo", t.idPozo);
            cmd.Parameters.AddWithValue("@nombre", t.nombre);
            cmd.Parameters.AddWithValue("@descripcion", t.descripcion);
            return cmd.ExecuteNonQuery();
        }

        public int UpdateSoftDelete(int _id, bool _isEliminado)
        {
            var cmd = CreateCommand("UPDATE pozos_new SET is_eliminado=@is_eliminado WHERE id_pozo=@id_pozo");
            cmd.Parameters.AddWithValue("@id_pozo", _id);
            cmd.Parameters.AddWithValue("@is_eliminado", _isEliminado);
            return cmd.ExecuteNonQuery();
        }
    }
}
