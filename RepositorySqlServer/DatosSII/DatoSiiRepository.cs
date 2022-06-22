using Models.DatosSII;
using RepositoryInterface.DatosSII;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorySqlServer.DatosSII
{
    public class DatoSiiRepository : Repository, IDatoSiiRepository
    {
        public DatoSiiRepository(SqlConnection context,SqlTransaction transaction) 
        {
            _context=context;
            _transaction=transaction;
        }
        public int Create(DatoSii t)
        {
            var cmd = CreateCommand("INSERT INTO datos_sii (rut_empresa,razon_social,rut_certificado,nombre_certificado,giro,direccion,comuna,codigo_actividades,fecha_resolucion," +
                "numero_resolucion,ciudad,razon_social_boleta,giro_boleta,unidad_sii,telefono,correo,id_apr_global,datos_sii_servidor,telefono_emergencia,tipo_empresa," +
                "facebook,pagina_web,fecha_autorizacion,codigo_licenciatura,nombre_licenciatura,codigo_region,nombre_region,codigo_comuna,nombre_comuna,is_eliminado)" +
                "VALUES" +
                "(@rut_empresa,@razon_social,@rut_certificado,@nombre_certificado,@giro,@direccion,@comuna,@codigo_actividades,@fecha_resolucion,@numero_resolucion,@ciudad," +
                "@razon_social_boleta,@giro_boleta,@unidad_sii,@telefono,@correo,@id_apr_global,@datos_sii_servidor,@telefono_emergencia,@tipo_empresa," +
                "@facebook,@pagina_web,@fecha_autorizacion,@codigo_licenciatura,@nombre_licenciatura,@codigo_region,@nombre_region,@codigo_comuna,@nombre_comuna,@is_eliminado)");
           cmd.Parameters.AddWithValue("@rut_empresa", t.rut);
           cmd.Parameters.AddWithValue("@razon_social", t.razonSocial);
           cmd.Parameters.AddWithValue("@rut_certificado", t.rutCertificado);
           cmd.Parameters.AddWithValue("@nombre_certificado", t.nombreCertificado);
           cmd.Parameters.AddWithValue("@giro", t.giro);
           cmd.Parameters.AddWithValue("@direccion", t.direccion);
           cmd.Parameters.AddWithValue("@comuna", t.comuna);
           cmd.Parameters.AddWithValue("@codigo_actividades", t.codigoActividades);
           cmd.Parameters.AddWithValue("@fecha_resolucion", t.fechaResolucion);
           cmd.Parameters.AddWithValue("@numero_resolucion", t.numeroResolucion);
           cmd.Parameters.AddWithValue("@ciudad", t.ciudad);
           cmd.Parameters.AddWithValue("@razon_social_boleta", t.razonSocialBoleta);
           cmd.Parameters.AddWithValue("@giro_boleta", t.giroBoleta);
           cmd.Parameters.AddWithValue("@unidad_sii", t.unidadSii);
           cmd.Parameters.AddWithValue("@telefono", t.telefono);
           cmd.Parameters.AddWithValue("@correo", t.correo);
           cmd.Parameters.AddWithValue("@id_apr_global", t.idAprGlobal);
           cmd.Parameters.AddWithValue("@datos_sii_servidor", t.datosSiiServidor);
           cmd.Parameters.AddWithValue("@telefono_emergencia", t.telefonoEmergencia);
           cmd.Parameters.AddWithValue("@tipo_empresa", t.tipoEmpresa);
           cmd.Parameters.AddWithValue("@facebook", t.facebook);
           cmd.Parameters.AddWithValue("@pagina_web", t.paginaWeb);
           cmd.Parameters.AddWithValue("@fecha_autorizacion", t.fechaAutorizacion);
           cmd.Parameters.AddWithValue("@codigo_licenciatura", t.codigoLicenciatura);
           cmd.Parameters.AddWithValue("@nombre_licenciatura", t.nombreLicenciatura);
           cmd.Parameters.AddWithValue("@codigo_region", t.codigoRegion);
           cmd.Parameters.AddWithValue("@nombre_region", t.nombreRegion);
           cmd.Parameters.AddWithValue("@codigo_comuna", t.codigoComuna);
           cmd.Parameters.AddWithValue("@nombre_comuna", t.nombreComuna);
           cmd.Parameters.AddWithValue("@is_eliminado", t.isEliminado);
            return cmd.ExecuteNonQuery();
        }

        public DatoSii CreateEntity(SqlDataReader dr)
        {
            DatoSii datoSii = new DatoSii() 
            {
                idEmpresa=Convert.ToInt32(dr["id_empresa"]),
                rut=Convert.ToString(dr["rut_empresa"]),
                razonSocial=Convert.ToString(dr["razon_social"]),
                rutCertificado=Convert.ToString(dr["rut_certificado"]),
                nombreCertificado=Convert.ToString(dr["nombre_certificado"]),
                giro=Convert.ToString(dr["giro"]),
                direccion=Convert.ToString(dr["direccion"]),
                comuna=Convert.ToString(dr["comuna"]),
                codigoActividades=Convert.ToString(dr["codigo_actividades"]),
                fechaResolucion=Convert.ToDateTime(dr["fecha_resolucion"]),
                numeroResolucion=Convert.ToString(dr["numero_resolucion"]),
                ciudad=Convert.ToString(dr["ciudad"]),
                razonSocialBoleta=Convert.ToString(dr["razon_social_boleta"]),
                giroBoleta=Convert.ToString(dr["giro_boleta"]),
                unidadSii=Convert.ToString(dr["unidad_sii"]),
                telefono=Convert.ToString(dr["telefono"]),
                correo=Convert.ToString(dr["correo"]),
                idAprGlobal=Convert.ToInt32(dr["id_apr_global"]),
                datosSiiServidor=Convert.ToBoolean(dr["datos_sii_servidor"]),
                telefonoEmergencia=Convert.ToString(dr["telefono_emergencia"]),
                tipoEmpresa=Convert.ToString(dr["tipo_empresa"]),
                facebook=Convert.ToString(dr["facebook"]),
                paginaWeb=Convert.ToString(dr["pagina_web"]),
                fechaAutorizacion=Convert.ToDateTime(dr["fecha_autorizacion"]),
                codigoLicenciatura=Convert.ToInt32(dr["codigo_licenciatura"]),
                nombreLicenciatura=Convert.ToString(dr["nombre_licenciatura"]),
                codigoRegion=Convert.ToString(dr["codigo_region"]),
                nombreRegion=Convert.ToString(dr["nombre_region"]),
                codigoComuna=Convert.ToString(dr["nombre_region"]),
                nombreComuna=Convert.ToString(dr["nombre_region"]),
                isEliminado=Convert.ToBoolean(dr["is_eliminado"])
            };
            return datoSii;
        }

        public List<DatoSii> GetAll()
        {
            var cmd = CreateCommand("SELECT*FROM datos_sii");
            var datoSiiList=new List<DatoSii>();
            using (var reader = cmd.ExecuteReader())
            { 
                while (reader.Read()) { datoSiiList.Add(CreateEntity(reader));} 
                return datoSiiList;
            };
        }

        public DatoSii GetById(int id)
        {
            var cmd = CreateCommand("SELECT*FROM datos_sii WHERE id_empresa=@id_empresa");
            cmd.Parameters.AddWithValue("@id_empresa", id);
            using(var reader = cmd.ExecuteReader()) { reader.Read(); return CreateEntity(reader); };          
        }

        public int Remove(int id)
        {
            var cmd = CreateCommand("DELETE datos_sii WHERE id_empresa=@id_empresa");
            cmd.Parameters.AddWithValue("@id_empresa",id);
            return cmd.ExecuteNonQuery();
        }

        public int Update(DatoSii t)
        {
            var cmd = CreateCommand("UPDATE datos_sii SET rut_empresa=@rut_empresa,razon_social=@razon_social,rut_certificado=@rut_certificado,nombre_certificado=@nombre_certificado," +
                "giro=@giro,direccion=@direccion,comuna=@comuna,codigo_actividades=@codigo_actividades,fecha_resolucion=@fecha_resolucion," +
                "numero_resolucion=@numero_resolucion,ciudad=@ciudad,razon_social_boleta=@razon_social_boleta,giro_boleta=@giro_boleta,unidad_sii=@unidad_sii," +
                "telefono=@telefono,correo=@correo,id_apr_global=@id_apr_global,datos_sii_servidor=@datos_sii_servidor,telefono_emergencia=@telefono_emergencia," +
                "tipo_empresa=@tipo_empresa,facebook=@facebook,pagina_web=@pagina_web,fecha_autorizacion=@fecha_autorizacion,codigo_licenciatura=@codigo_licenciatura," +
                "nombre_licenciatura=@nombre_licenciatura,codigo_region=@codigo_region,nombre_region=@nombre_region,codigo_comuna=@codigo_comuna,nombre_comuna=@nombre_comuna " +
               "WHERE id_empresa=@id_empresa");
            cmd.Parameters.AddWithValue("@id_empresa", t.idEmpresa);
            cmd.Parameters.AddWithValue("@rut_empresa", t.rut);
            cmd.Parameters.AddWithValue("@razon_social", t.razonSocial);
            cmd.Parameters.AddWithValue("@rut_certificado", t.rutCertificado);
            cmd.Parameters.AddWithValue("@nombre_certificado", t.nombreCertificado);
            cmd.Parameters.AddWithValue("@giro", t.giro);
            cmd.Parameters.AddWithValue("@direccion", t.direccion);
            cmd.Parameters.AddWithValue("@comuna", t.comuna);
            cmd.Parameters.AddWithValue("@codigo_actividades", t.codigoActividades);
            cmd.Parameters.AddWithValue("@fecha_resolucion", t.fechaResolucion);
            cmd.Parameters.AddWithValue("@numero_resolucion", t.numeroResolucion);
            cmd.Parameters.AddWithValue("@ciudad", t.ciudad);
            cmd.Parameters.AddWithValue("@razon_social_boleta", t.razonSocialBoleta);
            cmd.Parameters.AddWithValue("@giro_boleta", t.giroBoleta);
            cmd.Parameters.AddWithValue("@unidad_sii", t.unidadSii);
            cmd.Parameters.AddWithValue("@telefono", t.telefono);
            cmd.Parameters.AddWithValue("@correo", t.correo);
            cmd.Parameters.AddWithValue("@id_apr_global", t.idAprGlobal);
            cmd.Parameters.AddWithValue("@datos_sii_servidor", t.datosSiiServidor);
            cmd.Parameters.AddWithValue("@telefono_emergencia", t.telefonoEmergencia);
            cmd.Parameters.AddWithValue("@tipo_empresa", t.tipoEmpresa);
            cmd.Parameters.AddWithValue("@facebook", t.facebook);
            cmd.Parameters.AddWithValue("@pagina_web", t.paginaWeb);
            cmd.Parameters.AddWithValue("@fecha_autorizacion", t.fechaAutorizacion);
            cmd.Parameters.AddWithValue("@codigo_licenciatura", t.codigoLicenciatura);
            cmd.Parameters.AddWithValue("@nombre_licenciatura", t.nombreLicenciatura);
            cmd.Parameters.AddWithValue("@codigo_region", t.codigoRegion);
            cmd.Parameters.AddWithValue("@nombre_region", t.nombreRegion);
            cmd.Parameters.AddWithValue("@codigo_comuna", t.codigoComuna);
            cmd.Parameters.AddWithValue("@nombre_comuna", t.nombreComuna);
            return cmd.ExecuteNonQuery();
        }

        public int UpdateSoftDelete(int _id, bool _isEliminado)
        {
            var cmd = CreateCommand("UPDATE datos_sii SET is_eliminado=@is_eliminado WHERE id_empresa=@id_empresa");
            cmd.Parameters.AddWithValue("@id_empresa", _id);
            cmd.Parameters.AddWithValue("@is_eliminado", _isEliminado);
            return cmd.ExecuteNonQuery();
        }
    }
}
