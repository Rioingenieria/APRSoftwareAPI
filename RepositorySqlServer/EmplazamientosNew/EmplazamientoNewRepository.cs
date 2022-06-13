using Models.EmplazamientosNew;
using RepositoryInterface.EmplazamientosNew;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorySqlServer.EmplazamientosNew
{
    public class EmplazamientoNewRepository : Repository, IEmplazamientoNewRepository
    {
        public EmplazamientoNewRepository(SqlConnection context,SqlTransaction transaction) 
        {
            _context=context;
            _transaction=transaction;
        }
        public int Create(EmplazamientoNew t)
        {
            var cmd = CreateCommand("INSERT INTO emplazamientos_new (rol,lote,parcela,plano,is_eliminado)" +
                "VALUES(@rol,@lote,@parcela,@plano,@is_eliminado)");
            cmd.Parameters.AddWithValue("@rol", t.rol);
            cmd.Parameters.AddWithValue("@lote", t.lote);
            cmd.Parameters.AddWithValue("@parcela", t.parcela);
            cmd.Parameters.AddWithValue("@plano", t.plano);
            cmd.Parameters.AddWithValue("@is_eliminado", false);
            return cmd.ExecuteNonQuery();   
        }

        public EmplazamientoNew CreateEntity(SqlDataReader dr)
        {
            EmplazamientoNew emplazamiento = new EmplazamientoNew()
            {
                idEmplazamiento = Convert.ToInt32(dr["id_emplazamiento"]),
                rol = Convert.ToString(dr["rol"]),
                lote = Convert.ToString(dr["lote"]),
                parcela = Convert.ToString(dr["parcela"]),
                plano =(byte[])dr["plano"],
                isEliminado = Convert.ToBoolean(dr["is_eliminado"]),
            };
            return emplazamiento;          
        }

        public List<EmplazamientoNew> GetAll()
        {
            var cmd = CreateCommand("SELECT * FROM emplazamientos_new");
            List<EmplazamientoNew> listEmplamiento = new List<EmplazamientoNew>();
            using(var reader = cmd.ExecuteReader())
            {
                while (reader.Read()) { listEmplamiento.Add(CreateEntity(reader)); }
                return listEmplamiento;
            }
        }

        public EmplazamientoNew GetById(int id)
        {
            var cmd = CreateCommand("SELECT * FROM emplazamientos_new WHERE id_emplazamiento=@id_emplazamiento");
            cmd.Parameters.AddWithValue("@id_emplazamiento", id);
            using (var reader = cmd.ExecuteReader())
            {
               reader.Read();
                return CreateEntity(reader);
            }
        }

        public int Remove(int id)
        {
            var cmd = CreateCommand("DELETE emplazamientos_new WHERE id_emplazamiento=@id_emplazamiento");
            cmd.Parameters.AddWithValue("@id_emplazamiento", id);   
            return cmd.ExecuteNonQuery();
        }

        public int Update(EmplazamientoNew t)
        {
            var cmd = CreateCommand("UPDATE emplazamientos_new SET rol=@rol,lote=@lote,parcela=@parcela,plano=@plano " +
                "WHERE id_emplazamiento=@id_emplazamiento");
            cmd.Parameters.AddWithValue("@id_emplazamiento", t.idEmplazamiento);
            cmd.Parameters.AddWithValue("@rol", t.rol);
            cmd.Parameters.AddWithValue("@lote", t.lote);
            cmd.Parameters.AddWithValue("@parcela", t.parcela);
            cmd.Parameters.AddWithValue("@plano", t.plano);
            return cmd.ExecuteNonQuery();
        }

        public int UpdateSoftDelete(int _id, bool _isEliminado)
        {
            var cmd = CreateCommand("UPDATE emplazamientos_new SET is_eliminado=@is_eliminado WHERE id_emplazamiento=@id_emplazamiento");
            cmd.Parameters.AddWithValue("@id_emplazamiento", _id);
            cmd.Parameters.AddWithValue("@is_eliminado", _isEliminado);
            return cmd.ExecuteNonQuery();
        }
    }
}
