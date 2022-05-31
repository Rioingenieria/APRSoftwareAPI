using Models.ConfiguracionesPeriodicosNew;
using RepositoryInterface.ConfiguracionesPeriodicosNew;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorySqlServer.ConfiguracionesPeriodicasNew
{
    public class ConfiguracionPeriodicoNewRepository : Repository, IConfiguracionPeriodicoNewRepository
    {
        public ConfiguracionPeriodicoNewRepository(SqlConnection context, SqlTransaction transaction)
        {
            _context = context;
            _transaction = transaction;
        }
        public int Create(ConfiguracionPeriodicoNew t)
        {
            var cmd = CreateCommand("INSERT INTO configuraciones_periodicos_new (años_subsidio,meses_subsidio,iva_usuario,funcion_escalonada,informacion,meses_ctramite,dias_vencimiento,subsidio,ultima_boleta," +
                "fecha_caducar,caducado,dias_noti,porcentaje_consumo,alcantarillado,subsidio_iva,admin_subsidio,dte,caja_vecina,app_movil,tramo_subsidio,tipo_servicio," +
                "exencion_iva,dias_aviso_corte,version,frecuencia_servidor,periodo_inicio_servidor,carpeta_megasync,subsidio_solo_agua,usuario_megasync,password_megasync," +
                "contar_clientes_subsidio_0,inicio_tarifa_verano,fin_tarifa_verano,color_principal,color_secundario,envio_whatsapp,fecha_creacion,id_usuario," +
                "is_eliminado)" +
                "VALUES" +
                "(@años_subsidio,@meses_subsidio,@iva_usuario,@funcion_escalonada,@informacion,@meses_ctramite,@dias_vencimiento,@subsidio,@ultima_boleta,@fecha_caducar,@caducado,@dias_noti,@porcentaje_consumo," +
                "@alcantarillado,@subsidio_iva,@admin_subsidio,@dte,@caja_vecina,@app_movil,@tramo_subsidio,@tipo_servicio," +
                "@exencion_iva,@dias_aviso_corte,@version,@frecuencia_servidor,@periodo_inicio_servidor,@carpeta_megasync,@subsidio_solo_agua,@usuario_megasync,@password_megasync," +
                "@contar_clientes_subsidio_0,@inicio_tarifa_verano,@fin_tarifa_verano,@color_principal,@color_secundario,@envio_whatsapp,@fecha_creacion," +
                "@id_usuario,@is_eliminado)");
            cmd.Parameters.AddWithValue("@años_subsidio", t.años_subsidio);
            cmd.Parameters.AddWithValue("@meses_subsidio", t.meses_subsidio);
            cmd.Parameters.AddWithValue("@iva_usuario", t.iva_usuario);
            cmd.Parameters.AddWithValue("@funcion_escalonada", t.funcion_escalonada);
            cmd.Parameters.AddWithValue("@informacion", t.informacion);
            cmd.Parameters.AddWithValue("@meses_ctramite", t.meses_ctramite);
            cmd.Parameters.AddWithValue("@dias_vencimiento", t.dias_vencimiento);
            cmd.Parameters.AddWithValue("@subsidio", t.subsidio);
            cmd.Parameters.AddWithValue("@ultima_boleta", t.ultima_boleta);
            cmd.Parameters.AddWithValue("@fecha_caducar", t.fecha_caducar);
            cmd.Parameters.AddWithValue("@caducado", t.caducado);
            cmd.Parameters.AddWithValue("@dias_noti", t.dias_noti);
            cmd.Parameters.AddWithValue("@porcentaje_consumo", t.porcentaje_consumo);
            cmd.Parameters.AddWithValue("@alcantarillado", t.alcantarillado);
            cmd.Parameters.AddWithValue("@subsidio_iva", t.subsidio_iva);
            cmd.Parameters.AddWithValue("@admin_subsidio", t.admin_subsidio);
            cmd.Parameters.AddWithValue("@dte", t.dte);
            cmd.Parameters.AddWithValue("@caja_vecina", t.caja_vecina);
            cmd.Parameters.AddWithValue("@app_movil", t.app_movil);
            cmd.Parameters.AddWithValue("@tramo_subsidio", t.tramo_subsidio);
            cmd.Parameters.AddWithValue("@tipo_servicio", t.tipo_servicio);
            cmd.Parameters.AddWithValue("@exencion_iva", t.exencion_iva);
            cmd.Parameters.AddWithValue("@dias_aviso_corte", t.dias_aviso_corte);
            cmd.Parameters.AddWithValue("@version", t.version);
            cmd.Parameters.AddWithValue("@frecuencia_servidor", t.frecuencia_servidor);
            cmd.Parameters.AddWithValue("@periodo_inicio_servidor", t.periodo_inicio_servidor);
            cmd.Parameters.AddWithValue("@carpeta_megasync", t.carpeta_megasync);
            cmd.Parameters.AddWithValue("@subsidio_solo_agua", t.subsidio_solo_agua);
            cmd.Parameters.AddWithValue("@usuario_megasync", t.usuario_megasync);
            cmd.Parameters.AddWithValue("@password_megasync", t.password_megasync);
            cmd.Parameters.AddWithValue("@contar_clientes_subsidio_0", t.contar_clientes_subsidio_0);
            cmd.Parameters.AddWithValue("@inicio_tarifa_verano", t.inicio_tarifa_verano);
            cmd.Parameters.AddWithValue("@fin_tarifa_verano", t.fin_tarifa_verano);
            cmd.Parameters.AddWithValue("@color_principal", t.color_principal);
            cmd.Parameters.AddWithValue("@color_secundario", t.color_secundario);
            cmd.Parameters.AddWithValue("@envio_whatsapp", t.envio_whatsapp);
            cmd.Parameters.AddWithValue("@fecha_creacion", t.fecha_creacion);
            cmd.Parameters.AddWithValue("@id_usuario", t.id_usuario);
            cmd.Parameters.AddWithValue("@is_eliminado", t.is_eliminado);
            return cmd.ExecuteNonQuery();
        }

        public ConfiguracionPeriodicoNew CreateEntity(SqlDataReader dr)
        {
            ConfiguracionPeriodicoNew configuracionPeriodicoNew = new ConfiguracionPeriodicoNew()
            {
               
                años_subsidio= Convert.ToInt16(dr["años_subsidio"]),
                alcantarillado= Convert.ToBoolean(dr["alcantarillado"]),
                caducado= Convert.ToString(dr["caducado"]),
                carpeta_megasync= Convert.ToString(dr["carpeta_megasync"]),
                dias_noti=Convert.ToInt16(dr["dias_noti"]),
                fecha_caducar= Convert.ToDateTime(dr["fecha_caducar"]),
                fecha_creacion= Convert.ToDateTime(dr["fecha_creacion"]),
                id_usuario=Convert.ToInt16(dr["id_usuario"]),
                informacion=Convert.ToString(dr["informacion"]),
                inicio_tarifa_verano=Convert.ToString(dr["inicio_tarifa_verano"]),
                is_eliminado=Convert.ToBoolean(dr["is_eliminado"]),
                iva_usuario=Convert.ToBoolean(dr["iva_usuario"]),
                meses_ctramite=Convert.ToInt16(dr["meses_ctramite"]),
                porcentaje_consumo=Convert.ToInt16(dr["porcentaje_consumo"]),
                subsidio=Convert.ToInt16(dr["subsidio"]),
                ultima_boleta=Convert.ToBoolean(dr["ultima_boleta"]),
                subsidio_iva = Convert.ToBoolean(dr["subsidio_iva"]),
                admin_subsidio = Convert.ToBoolean(dr["admin_subsidio"]),
                dte = Convert.ToString(dr["dte"]),
                caja_vecina = Convert.ToString(dr["caja_vecina"]),
                envio_whatsapp = Convert.ToString(dr["envio_whatsapp"]),
                color_secundario = Convert.ToInt32(dr["color_secundario"]),
                color_principal = Convert.ToInt32(dr["color_principal"]),
                fin_tarifa_verano = Convert.ToString(dr["fin_tarifa_verano"]),
                contar_clientes_subsidio_0 = Convert.ToBoolean(dr["contar_clientes_subsidio_0"]),
                password_megasync = Convert.ToString(dr["password_megasync"]),
                usuario_megasync = Convert.ToString(dr["usuario_megasync"]),
                subsidio_solo_agua = Convert.ToBoolean(dr["subsidio_solo_agua"]),
                periodo_inicio_servidor = Convert.ToDateTime(dr["periodo_inicio_servidor"]),
                frecuencia_servidor = Convert.ToInt32(dr["frecuencia_servidor"]),
                version = Convert.ToString(dr["version"]),
                dias_aviso_corte = Convert.ToInt32(dr["dias_aviso_corte"]),
                exencion_iva = Convert.ToBoolean(dr["exencion_iva"]),
                tipo_servicio = Convert.ToInt32(dr["tipo_servicio"]),
                tramo_subsidio = Convert.ToBoolean(dr["tramo_subsidio"]),
                app_movil = Convert.ToBoolean(dr["app_movil"]),
                dias_vencimiento= Convert.ToInt32(dr["dias_vencimiento"]),
                funcion_escalonada= Convert.ToBoolean(dr["funcion_escalonada"]),
                meses_subsidio= Convert.ToInt32(dr["meses_subsidio"]),
            };
            return configuracionPeriodicoNew;
        }

        public List<ConfiguracionPeriodicoNew> GetAll()
        {
            var cmd = CreateCommand("SELECT*FROM configuraciones_periodicos_new ");
            var listConfig = new List<ConfiguracionPeriodicoNew>();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read()) { listConfig.Add(CreateEntity(reader)); }
            }
            return listConfig;
        }

        public ConfiguracionPeriodicoNew GetById(int id)
        {
            var cmd = CreateCommand("SELECT*FROM configuraciones_periodicos_new WHERE id_configuracion_periodico=@id");
            cmd.Parameters.AddWithValue("@id", id);
            var config = new ConfiguracionPeriodicoNew();
            using (var reader = cmd.ExecuteReader()) { reader.Read(); return config = CreateEntity(reader); }
        }

        public int Remove(int id)
        {
            var cmd = CreateCommand("DELETE configuraciones_periodicos_new WHERE id_configuracion_periodico=@id");
            cmd.Parameters.AddWithValue("@id", id);
            return cmd.ExecuteNonQuery();
        }

        public int Update(ConfiguracionPeriodicoNew t)
        {
            var cmd = CreateCommand("UPDATE configuraciones_periodicos_new SET " +
                "años_subsidio=@años_subsidio,meses_subsidio=@meses_subsidio,iva_usuario=@iva_usuario,funcion_escalonada=@funcion_escalonada," +
                "informacion=@informacion,meses_ctramite=@meses_ctramite,subsidio=@subsidio," +
                "ultima_boleta=@ultima_boleta,fecha_caducar=@fecha_caducar," +
                "caducado=@caducado,dias_noti=@dias_noti,porcentaje_consumo=@porcentaje_consumo,alcantarillado=@alcantarillado," +
                "subsidio_iva=@subsidio_iva,admin_subsidio=@admin_subsidio," +
                "dte=@dte,caja_vecina=@caja_vecina,app_movil=@app_movil,tramo_subsidio=@tramo_subsidio,tipo_servicio=@tipo_servicio," +
                "exencion_iva=@exencion_iva,dias_aviso_corte=@dias_aviso_corte,version=@version,frecuencia_servidor=@frecuencia_servidor,periodo_inicio_servidor=@periodo_inicio_servidor," +
                "carpeta_megasync=@carpeta_megasync,subsidio_solo_agua=@subsidio_solo_agua,usuario_megasync=@usuario_megasync," +
                "password_megasync=@password_megasync," +
                "contar_clientes_subsidio_0=@contar_clientes_subsidio_0,inicio_tarifa_verano=@inicio_tarifa_verano,fin_tarifa_verano=@fin_tarifa_verano,color_principal=@color_principal," +
                "color_secundario=@color_secundario,envio_whatsapp=@envio_whatsapp,fecha_creacion=@fecha_creacion,id_usuario=@id_usuario, is_eliminado=@is_eliminado " +
                "WHERE id_configuracion_periodico=@id_configuracion_periodico");
            cmd.Parameters.AddWithValue("@id_configuracion_periodico", t.id_configuracion_periodico);
            cmd.Parameters.AddWithValue("@años_subsidio", t.años_subsidio);
            cmd.Parameters.AddWithValue("@meses_subsidio", t.meses_subsidio);
            cmd.Parameters.AddWithValue("@iva_usuario", t.iva_usuario);
            cmd.Parameters.AddWithValue("@funcion_escalonada", t.funcion_escalonada);
            cmd.Parameters.AddWithValue("@informacion", t.informacion);
            cmd.Parameters.AddWithValue("@meses_ctramite", t.meses_ctramite);
            cmd.Parameters.AddWithValue("@dias_vencimiento", t.dias_vencimiento);
            cmd.Parameters.AddWithValue("@subsidio", t.subsidio);
            cmd.Parameters.AddWithValue("@ultima_boleta", t.ultima_boleta);
            cmd.Parameters.AddWithValue("@fecha_caducar", t.fecha_caducar);
            cmd.Parameters.AddWithValue("@caducado", t.caducado);
            cmd.Parameters.AddWithValue("@dias_noti", t.dias_noti);
            cmd.Parameters.AddWithValue("@porcentaje_consumo", t.porcentaje_consumo);
            cmd.Parameters.AddWithValue("@alcantarillado", t.alcantarillado);
            cmd.Parameters.AddWithValue("@subsidio_iva", t.subsidio_iva);
            cmd.Parameters.AddWithValue("@admin_subsidio", t.admin_subsidio);
            cmd.Parameters.AddWithValue("@dte", t.dte);
            cmd.Parameters.AddWithValue("@caja_vecina", t.caja_vecina);
            cmd.Parameters.AddWithValue("@app_movil", t.app_movil);
            cmd.Parameters.AddWithValue("@tramo_subsidio", t.tramo_subsidio);
            cmd.Parameters.AddWithValue("@tipo_servicio", t.tipo_servicio);
            cmd.Parameters.AddWithValue("@exencion_iva", t.exencion_iva);
            cmd.Parameters.AddWithValue("@dias_aviso_corte", t.dias_aviso_corte);
            cmd.Parameters.AddWithValue("@version", t.version);
            cmd.Parameters.AddWithValue("@frecuencia_servidor", t.frecuencia_servidor);
            cmd.Parameters.AddWithValue("@periodo_inicio_servidor", t.periodo_inicio_servidor);
            cmd.Parameters.AddWithValue("@carpeta_megasync", t.carpeta_megasync);
            cmd.Parameters.AddWithValue("@subsidio_solo_agua", t.subsidio_solo_agua);
            cmd.Parameters.AddWithValue("@usuario_megasync", t.usuario_megasync);
            cmd.Parameters.AddWithValue("@password_megasync", t.password_megasync);
            cmd.Parameters.AddWithValue("@contar_clientes_subsidio_0", t.contar_clientes_subsidio_0);
            cmd.Parameters.AddWithValue("@inicio_tarifa_verano", t.inicio_tarifa_verano);
            cmd.Parameters.AddWithValue("@fin_tarifa_verano", t.fin_tarifa_verano);
            cmd.Parameters.AddWithValue("@color_principal", t.color_principal);
            cmd.Parameters.AddWithValue("@color_secundario", t.color_secundario);
            cmd.Parameters.AddWithValue("@envio_whatsapp", t.envio_whatsapp);
            cmd.Parameters.AddWithValue("@fecha_creacion", t.fecha_creacion);
            cmd.Parameters.AddWithValue("@id_usuario", t.id_usuario);
            cmd.Parameters.AddWithValue("@is_eliminado", t.is_eliminado);
            return cmd.ExecuteNonQuery();
        }

        public int UpdateSoftDelete(int _id, bool _isEliminado)
        {
            var cmd = CreateCommand("UPDATE configuraciones_periodicos_new " +
                "SET is_eliminado=@is_eliminado " +
                "WHERE id_configuracion_periodico=@id_configuracion_periodico");
            cmd.Parameters.AddWithValue("@id_configuracion_periodico", _id);
            cmd.Parameters.AddWithValue("@is_eliminado", _isEliminado);
            var result = cmd.ExecuteNonQuery();
            return result;
        }
    }
}
