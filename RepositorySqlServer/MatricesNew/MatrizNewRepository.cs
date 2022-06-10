using Models.MatricesNew;
using RepositoryInterface.MatricesNew;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorySqlServer.MatricesNew
{
    public class MatrizNewRepository : Repository, IMatrizNewRepository
    {
        public MatrizNewRepository(SqlConnection context,SqlTransaction transaction) 
        {
         _context = context;
         _transaction = transaction;
        }
        public int Create(MatrizNew t)
        {
            var cmd = CreateCommand("INSERT INTO matrices_new (id_pozo,nombre,descripcion,is_eliminado)VALUES" +
                "(@id_pozo,@nombre,@descripcion,@is_eliminado)");
            cmd.Parameters.AddWithValue("@id_pozo", t.idPozo);
            cmd.Parameters.AddWithValue("@nombre", t.nombre);
            cmd.Parameters.AddWithValue("@descripcion", t.descripcion);
            cmd.Parameters.AddWithValue("@is_eliminado", false);
            return cmd.ExecuteNonQuery();
        }

        public MatrizNew CreateEntity(SqlDataReader dr)
        {
            MatrizNew matriz=new MatrizNew() 
            { 
                idMatriz=Convert.ToInt32(dr["id_matriz"]),
                idPozo=Convert.ToInt32(dr["id_pozo"]),
                nombre=Convert.ToString(dr["nombre"]),
                descripcion=Convert.ToString(dr["descripcion"]),
                isEliminado=Convert.ToBoolean(dr["is_eliminado"])
            };
            return matriz;
        }

        public List<MatrizNew> GetAll()
        {
            var cmd = CreateCommand("SELECT * FROM matrices_new");
            var listMatriz=new List<MatrizNew>();
            using (var reader = cmd.ExecuteReader()) 
            {
            while (reader.Read()){listMatriz.Add(CreateEntity(reader));}            
            return listMatriz;
            }
        }

        public MatrizNew GetById(int id)
        {
            var cmd = CreateCommand("SELECT * FROM matrices_new WHERE id_matriz=@id_matriz");
            cmd.Parameters.AddWithValue("@id_matriz", id);
            using(var reader = cmd.ExecuteReader()) { reader.Read(); return CreateEntity(reader);}
        }

        public int Remove(int id)
        {
            var cmd = CreateCommand("DELETE matrices_new WHERE id_matriz=@id_matriz");
            cmd.Parameters.AddWithValue("@id_matriz", id);
            return cmd.ExecuteNonQuery();
        }

        public int Update(MatrizNew t)
        {
            var cmd = CreateCommand("UPDATE matrices_new SET id_pozo=@id_pozo,nombre=@nombre,descripcion=@descripcion " +
                "WHERE id_matriz=@id_matriz");
            cmd.Parameters.AddWithValue("@id_matriz", t.idMatriz);
            cmd.Parameters.AddWithValue("@id_pozo", t.idPozo);
            cmd.Parameters.AddWithValue("@nombre", t.nombre);
            cmd.Parameters.AddWithValue("@descripcion", t.descripcion);
            return cmd.ExecuteNonQuery();
        }

        public int UpdateSoftDelete(int _id, bool _isEliminado)
        {
            var cmd = CreateCommand("UPDATE matrices_new SET is_eliminado=@is_eliminado " +
                 "WHERE id_matriz=@id_matriz");
            cmd.Parameters.AddWithValue("@id_matriz", _id);
            cmd.Parameters.AddWithValue("@is_eliminado", _isEliminado);
            return cmd.ExecuteNonQuery();
        }
    }
}
