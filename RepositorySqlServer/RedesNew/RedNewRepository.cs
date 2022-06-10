using Models.RedesNew;
using RepositoryInterface.RedesNew;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorySqlServer.RedesNew
{
    public class RedNewRepository : Repository, IRedNewRepository
    {
        public RedNewRepository(SqlConnection context,SqlTransaction Transaction) 
        {
            _context=context;
            _transaction=Transaction;
        }
        public int Create(RedNew t)
        {
            var cmd = CreateCommand("INSERT INTO redes_new (id_matriz,presion_red,profundidad_red,nombre,descripcion,is_eliminado)" +
                "VALUES(@id_matriz,@presion_red,@profundidad_red,@nombre,@descripcion,@is_eliminado)");
            cmd.Parameters.AddWithValue("@id_matriz",t.idMatriz);
            cmd.Parameters.AddWithValue("@presion_red",t.presionRed);
            cmd.Parameters.AddWithValue("@profundidad_red",t.profundidadRed);
            cmd.Parameters.AddWithValue("@nombre",t.nombre);
            cmd.Parameters.AddWithValue("@descripcion",t.descripcion);
            cmd.Parameters.AddWithValue("@is_eliminado",false);
            return cmd.ExecuteNonQuery();
        }

        public RedNew CreateEntity(SqlDataReader dr)
        {
            RedNew red = new RedNew() 
            { 
                idRed=Convert.ToInt32(dr["id_red"]),
                idMatriz=Convert.ToInt32(dr["id_matriz"]),
                presionRed=Convert.ToDecimal(dr["presion_red"]),
                profundidadRed=Convert.ToDecimal(dr["profundidad_red"]),
                nombre=Convert.ToString(dr["nombre"]),
                descripcion=Convert.ToString(dr["descripcion"]),
                isEliminado=Convert.ToBoolean(dr["is_eliminado"])
            };
            return red; 
        }

        public List<RedNew> GetAll()
        {
            var cmd = CreateCommand("SELECT * FROM redes_new");
            var list = new List<RedNew>();
            using (var reader = cmd.ExecuteReader()) 
            {
                while (reader.Read()) { list.Add(CreateEntity(reader)); }
                return list;
            };
        }

        public RedNew GetById(int id)
        {
            var cmd = CreateCommand("SELECT * FROM redes_new WHERE id_red=@id_red");
            cmd.Parameters.AddWithValue("@id_red",id);
            var red = new RedNew();
            using(var reader = cmd.ExecuteReader()) { reader.Read();  return CreateEntity(reader); }

        }

        public int Remove(int id)
        {
            var cmd = CreateCommand("DELETE redes_new WHERE id_red=@id_red");
            cmd.Parameters.AddWithValue("@id_red", id);
            return cmd.ExecuteNonQuery();
        }

        public int Update(RedNew t)
        {
            var cmd = CreateCommand("UPDATE redes_new SET id_matriz=@id_matriz,presion_red=@presion_red,profundidad_red=@profundidad_red," +
                "nombre=@nombre,descripcion=@descripcion WHERE id_red=@id_red");
            cmd.Parameters.AddWithValue("@id_red", t.idRed);
            cmd.Parameters.AddWithValue("@id_matriz", t.idMatriz);
            cmd.Parameters.AddWithValue("@presion_red", t.presionRed);
            cmd.Parameters.AddWithValue("@profundidad_red", t.profundidadRed);
            cmd.Parameters.AddWithValue("@nombre", t.nombre);
            cmd.Parameters.AddWithValue("@descripcion", t.descripcion);
            return cmd.ExecuteNonQuery();
        }

        public int UpdateSoftDelete(int _id, bool _isEliminado)
        {
            var cmd = CreateCommand("UPDATE redes_new SET is_eliminado=@is_eliminado WHERE id_red=@id_red");
            cmd.Parameters.AddWithValue("@id_red", _id);
            cmd.Parameters.AddWithValue("@is_eliminado", _isEliminado);;
            return cmd.ExecuteNonQuery();
        }
    }
}
