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
            cmd.Parameters.AddWithValue("@años_subsidio", t.añosSubsidio);
            cmd.Parameters.AddWithValue("@meses_subsidio", t.mesesSubsidio);
            cmd.Parameters.AddWithValue("@iva_usuario", t.ivaUsuario);
            cmd.Parameters.AddWithValue("@funcion_escalonada", t.funcionEscalonada);
            cmd.Parameters.AddWithValue("@informacion", t.informacion);
            cmd.Parameters.AddWithValue("@meses_ctramite", t.mesesCtramite);
            cmd.Parameters.AddWithValue("@dias_vencimiento", t.diasVencimiento);
            cmd.Parameters.AddWithValue("@subsidio", t.subsidio);
            cmd.Parameters.AddWithValue("@ultima_boleta", t.ultimaBoleta);
            cmd.Parameters.AddWithValue("@fecha_caducar", t.fechaCaducar);
            cmd.Parameters.AddWithValue("@caducado", t.caducado);
            cmd.Parameters.AddWithValue("@dias_noti", t.diasNoti);
            cmd.Parameters.AddWithValue("@porcentaje_consumo", t.porcentajeConsumo);
            cmd.Parameters.AddWithValue("@alcantarillado", t.alcantarillado);
            cmd.Parameters.AddWithValue("@subsidio_iva", t.subsidioIva);
            cmd.Parameters.AddWithValue("@admin_subsidio", t.adminSubsidio);
            cmd.Parameters.AddWithValue("@dte", t.dte);
            cmd.Parameters.AddWithValue("@caja_vecina", t.cajaVecina);
            cmd.Parameters.AddWithValue("@app_movil", t.appMovil);
            cmd.Parameters.AddWithValue("@tramo_subsidio", t.tramoSubsidio);
            cmd.Parameters.AddWithValue("@tipo_servicio", t.tipoServicio);
            cmd.Parameters.AddWithValue("@exencion_iva", t.exencionIva);
            cmd.Parameters.AddWithValue("@dias_aviso_corte", t.diasAvisoCorte);
            cmd.Parameters.AddWithValue("@version", t.version);
            cmd.Parameters.AddWithValue("@frecuencia_servidor", t.frecuenciaServidor);
            cmd.Parameters.AddWithValue("@periodo_inicio_servidor", t.periodoInicioServidor);
            cmd.Parameters.AddWithValue("@carpeta_megasync", t.carpetaMegasync);
            cmd.Parameters.AddWithValue("@subsidio_solo_agua", t.subsidioSoloAgua);
            cmd.Parameters.AddWithValue("@usuario_megasync", t.usuarioMegasync);
            cmd.Parameters.AddWithValue("@password_megasync", t.passwordMegasync);
            cmd.Parameters.AddWithValue("@contar_clientes_subsidio_0", t.contarClientesSubsidio_0);
            cmd.Parameters.AddWithValue("@inicio_tarifa_verano", t.inicioTarifaVerano);
            cmd.Parameters.AddWithValue("@fin_tarifa_verano", t.finTarifaVerano);
            cmd.Parameters.AddWithValue("@color_principal", t.colorPrincipal);
            cmd.Parameters.AddWithValue("@color_secundario", t.colorSecundario);
            cmd.Parameters.AddWithValue("@envio_whatsapp", t.envioWhatsapp);
            cmd.Parameters.AddWithValue("@fecha_creacion", t.fechaCreacion);
            cmd.Parameters.AddWithValue("@id_usuario", t.idUsuario);
            cmd.Parameters.AddWithValue("@is_eliminado", false);
            return cmd.ExecuteNonQuery();
        }

        public ConfiguracionPeriodicoNew CreateEntity(SqlDataReader dr)
        {
            ConfiguracionPeriodicoNew configuracionPeriodicoNew = new ConfiguracionPeriodicoNew()
            {
               
                añosSubsidio= Convert.ToInt16(dr["años_subsidio"]),
                alcantarillado= Convert.ToBoolean(dr["alcantarillado"]),
                caducado= Convert.ToString(dr["caducado"]),
                carpetaMegasync= Convert.ToString(dr["carpeta_megasync"]),
                diasNoti=Convert.ToInt16(dr["dias_noti"]),
                fechaCaducar= Convert.ToDateTime(dr["fecha_caducar"]),
                fechaCreacion= Convert.ToDateTime(dr["fecha_creacion"]),
                idUsuario=Convert.ToInt16(dr["id_usuario"]),
                informacion=Convert.ToString(dr["informacion"]),
                inicioTarifaVerano=Convert.ToString(dr["inicio_tarifa_verano"]),
                isEliminado=Convert.ToBoolean(dr["is_eliminado"]),
                ivaUsuario=Convert.ToBoolean(dr["iva_usuario"]),
                mesesCtramite=Convert.ToInt16(dr["meses_ctramite"]),
                porcentajeConsumo=Convert.ToInt16(dr["porcentaje_consumo"]),
                subsidio=Convert.ToInt16(dr["subsidio"]),
                ultimaBoleta=Convert.ToBoolean(dr["ultima_boleta"]),
                subsidioIva = Convert.ToBoolean(dr["subsidio_iva"]),
                adminSubsidio = Convert.ToBoolean(dr["admin_subsidio"]),
                dte = Convert.ToString(dr["dte"]),
                cajaVecina = Convert.ToString(dr["caja_vecina"]),
                envioWhatsapp = Convert.ToString(dr["envio_whatsapp"]),
                colorSecundario = Convert.ToInt32(dr["color_secundario"]),
                colorPrincipal = Convert.ToInt32(dr["color_principal"]),
                finTarifaVerano = Convert.ToString(dr["fin_tarifa_verano"]),
                contarClientesSubsidio_0 = Convert.ToBoolean(dr["contar_clientes_subsidio_0"]),
                passwordMegasync = Convert.ToString(dr["password_megasync"]),
                usuarioMegasync = Convert.ToString(dr["usuario_megasync"]),
                subsidioSoloAgua = Convert.ToBoolean(dr["subsidio_solo_agua"]),
                periodoInicioServidor = Convert.ToDateTime(dr["periodo_inicio_servidor"]),
                frecuenciaServidor = Convert.ToInt32(dr["frecuencia_servidor"]),
                version = Convert.ToString(dr["version"]),
                diasAvisoCorte = Convert.ToInt32(dr["dias_aviso_corte"]),
                exencionIva = Convert.ToBoolean(dr["exencion_iva"]),
                tipoServicio = Convert.ToInt32(dr["tipo_servicio"]),
                tramoSubsidio = Convert.ToBoolean(dr["tramo_subsidio"]),
                appMovil = Convert.ToBoolean(dr["app_movil"]),
                diasVencimiento= Convert.ToInt32(dr["dias_vencimiento"]),
                funcionEscalonada= Convert.ToBoolean(dr["funcion_escalonada"]),
                mesesSubsidio= Convert.ToInt32(dr["meses_subsidio"]),
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
                "color_secundario=@color_secundario,envio_whatsapp=@envio_whatsapp,fecha_creacion=@fecha_creacion,id_usuario=@id_usuario " +
                "WHERE id_configuracion_periodico=@id_configuracion_periodico");
            cmd.Parameters.AddWithValue("@id_configuracion_periodico", t.idConfiguracionPeriodico);
            cmd.Parameters.AddWithValue("@años_subsidio", t.añosSubsidio);
            cmd.Parameters.AddWithValue("@meses_subsidio", t.mesesSubsidio);
            cmd.Parameters.AddWithValue("@iva_usuario", t.ivaUsuario);
            cmd.Parameters.AddWithValue("@funcion_escalonada", t.funcionEscalonada);
            cmd.Parameters.AddWithValue("@informacion", t.informacion);
            cmd.Parameters.AddWithValue("@meses_ctramite", t.mesesCtramite);
            cmd.Parameters.AddWithValue("@dias_vencimiento", t.diasVencimiento);
            cmd.Parameters.AddWithValue("@subsidio", t.subsidio);
            cmd.Parameters.AddWithValue("@ultima_boleta", t.ultimaBoleta);
            cmd.Parameters.AddWithValue("@fecha_caducar", t.fechaCaducar);
            cmd.Parameters.AddWithValue("@caducado", t.caducado);
            cmd.Parameters.AddWithValue("@dias_noti", t.diasNoti);
            cmd.Parameters.AddWithValue("@porcentaje_consumo", t.porcentajeConsumo);
            cmd.Parameters.AddWithValue("@alcantarillado", t.alcantarillado);
            cmd.Parameters.AddWithValue("@subsidio_iva", t.subsidioIva);
            cmd.Parameters.AddWithValue("@admin_subsidio", t.adminSubsidio);
            cmd.Parameters.AddWithValue("@dte", t.dte);
            cmd.Parameters.AddWithValue("@caja_vecina", t.cajaVecina);
            cmd.Parameters.AddWithValue("@app_movil", t.appMovil);
            cmd.Parameters.AddWithValue("@tramo_subsidio", t.tramoSubsidio);
            cmd.Parameters.AddWithValue("@tipo_servicio", t.tipoServicio);
            cmd.Parameters.AddWithValue("@exencion_iva", t.exencionIva);
            cmd.Parameters.AddWithValue("@dias_aviso_corte", t.diasAvisoCorte);
            cmd.Parameters.AddWithValue("@version", t.version);
            cmd.Parameters.AddWithValue("@frecuencia_servidor", t.frecuenciaServidor);
            cmd.Parameters.AddWithValue("@periodo_inicio_servidor", t.periodoInicioServidor);
            cmd.Parameters.AddWithValue("@carpeta_megasync", t.carpetaMegasync);
            cmd.Parameters.AddWithValue("@subsidio_solo_agua", t.subsidioSoloAgua);
            cmd.Parameters.AddWithValue("@usuario_megasync", t.usuarioMegasync);
            cmd.Parameters.AddWithValue("@password_megasync", t.passwordMegasync);
            cmd.Parameters.AddWithValue("@contar_clientes_subsidio_0", t.contarClientesSubsidio_0);
            cmd.Parameters.AddWithValue("@inicio_tarifa_verano", t.inicioTarifaVerano);
            cmd.Parameters.AddWithValue("@fin_tarifa_verano", t.finTarifaVerano);
            cmd.Parameters.AddWithValue("@color_principal", t.colorPrincipal);
            cmd.Parameters.AddWithValue("@color_secundario", t.colorSecundario);
            cmd.Parameters.AddWithValue("@envio_whatsapp", t.envioWhatsapp);
            cmd.Parameters.AddWithValue("@fecha_creacion", t.fechaCreacion);
            cmd.Parameters.AddWithValue("@id_usuario", t.idUsuario);
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
