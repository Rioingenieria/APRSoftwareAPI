using Models.ConfiguracionesGlobales;
using RepositoryInterface.ConfiguracionesGlobales;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorySqlServer.ConfiguracionesGlobales
{
    public class ConfiguracionGlobalRepository : Repository, IConfiguracionGlobalRepository
    {
        public ConfiguracionGlobalRepository(SqlConnection context,SqlTransaction transaction) 
        { 
            _context = context;
            _transaction = transaction;
        }

        public int Create(ConfiguracionGlobal t)
        {
            var cmd = CreateCommand("INSERT INTO configuraciones_globales (web,is_ambiente_produccion,id_usuario,fecha_creacion,is_eliminado)" +
                "VALUES" +
                "(@web,@is_ambiente_produccion,@id_usuario,@fecha_creacion,@is_eliminado)");
            cmd.Parameters.AddWithValue("@web", t.web);
            cmd.Parameters.AddWithValue("@is_ambiente_produccion", t.isAmbienteProduccion);
            cmd.Parameters.AddWithValue("@id_usuario", t.idUsuario);
            cmd.Parameters.AddWithValue("@fecha_creacion", t.fechaCreacion);
            cmd.Parameters.AddWithValue("@is_eliminado", false);
            return cmd.ExecuteNonQuery();
        }

        public ConfiguracionGlobal CreateEntity(SqlDataReader dr)
        {
            ConfiguracionGlobal configuracion = new ConfiguracionGlobal
            {
            web=Convert.ToBoolean(dr["web"]),
            isAmbienteProduccion =Convert.ToBoolean(dr["is_ambiente_produccion"]),
            fechaCreacion=Convert.ToDateTime(dr["fecha_creacion"]),
            idUsuario=Convert.ToInt16(dr["id_usuario"]),
            isEliminado=Convert.ToBoolean(dr["is_eliminado"])
            };
            return configuracion;
        }

        public List<ConfiguracionGlobal> GetAll()
        {
            var cmd = CreateCommand("SELECT*FROM configuraciones_globales");
            var listConfig = new List<ConfiguracionGlobal>();
            using(var reader = cmd.ExecuteReader())
            {
                while (reader.Read()) { listConfig.Add(CreateEntity(reader)); }
            }
            return listConfig;
        }

        public ConfiguracionGlobal GetById(int id)
        {
            var cmd = CreateCommand("SELECT*FROM configuraciones_globales WHERE id_configuracion=@id");
            cmd.Parameters.AddWithValue("@id", id);
            var config =new ConfiguracionGlobal();
            using(var reader = cmd.ExecuteReader()) {reader.Read(); return config = CreateEntity(reader); }       
        }

        public int Remove(int id)
        {
            var cmd = CreateCommand("DELETE configuraciones_globales WHERE id_configuracion=@id");
            cmd.Parameters.AddWithValue("@id", id);
            return cmd.ExecuteNonQuery();
        }

        public int Update(ConfiguracionGlobal t)
        {
            var cmd = CreateCommand("UPDATE configuraciones_globales  set " +
                "web=@web,is_ambiente_produccion=@is_ambiente_produccion,id_usuario=@id_usuario," +
                "fecha_creacion=@fecha_creacion " +
                "WHERE id_configuracion=@id");
            cmd.Parameters.AddWithValue("@id", t.idConfiguracion);
            cmd.Parameters.AddWithValue("@web", t.web);
            cmd.Parameters.AddWithValue("@is_ambiente_produccion", t.isAmbienteProduccion);
            cmd.Parameters.AddWithValue("@id_usuario", t.idUsuario);
            cmd.Parameters.AddWithValue("@fecha_creacion", t.fechaCreacion);
            return cmd.ExecuteNonQuery();
        }

        public int UpdateSoftDelete(int _id, bool _isEliminado)
        {
            var cmd = CreateCommand("UPDATE configuraciones_globales SET is_eliminado=@is_eliminado " +
                "WHERE id_configuracion=@id_configuracion");
            cmd.Parameters.AddWithValue("@id_configuracion", _id);
            cmd.Parameters.AddWithValue("@is_eliminado", _isEliminado);
            var result = cmd.ExecuteNonQuery();
            return result;
        }
    }
}
