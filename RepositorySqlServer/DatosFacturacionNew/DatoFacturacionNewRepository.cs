using Common.Constantes;
using Models.DatosFacturacionNew;
using RepositoryInterface.DatosFacturacionNew;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorySqlServer.DatosFacturacionNew
{
    public class DatoFacturacionNewRepository : Repository, IDatoFacturacionNewRepository
    {
        public DatoFacturacionNewRepository(SqlConnection context, SqlTransaction transaction)
        {
            _context = context;
            _transaction = transaction;
        }
        public int Create(DatoFacturacionNew t)
        {
            var cmd = CreateCommand("INSERT INTO datos_facturaciones_new " +
                      "(rut,razon_social,direccion,comuna_estado,id_giro_facturacion,email_intercambio," +
                      "documento_pago,forma_pago_estado,id_usuario,fecha_creacion)" +
                      "VALUES" +
                      "(@rut,@razon_social,@direccion,@comuna_estado,@id_giro_facturacion,@email_intercambio," +
                      "@documento_pago,@forma_pago_estado,@id_usuario,@fecha_creacion)");
            GetEntity(t, ref cmd);
            return cmd.ExecuteNonQuery();
        }

        public DatoFacturacionNew CreateEntity(SqlDataReader dr)
        {
            DatoFacturacionNew _datosFacturacion = new DatoFacturacionNew()
            {
                IdDatoFacturacion = Convert.ToInt32(dr["id_dato_facturacion"]),
                Rut = dr["rut"].ToString(),
                RazonSocial = dr["razon_social"].ToString(),
                Direccion = dr["direccion"].ToString(),
                ComunaEstado = Convert.ToInt32(dr["comuna_estado"]),
                IdGiroFacturacion = Convert.ToInt32(dr["id_giro_facturacion"]),
                EmailIntercambio = dr["email_intercambio"].ToString(),
                DocumentoPago = Convert.ToInt32(dr["documento_pago"]),
                FormaPagoEstado = Convert.ToInt32(dr["forma_pago_estado"]),
                IdUsuario = Convert.ToInt32(dr["id_usuario"]),
                FechaCreacion = dr["fecha_creacion"].ToString() == "" ? DateTime.Parse(NumerosYFechas.DateMinValue) : Convert.ToDateTime(dr["fecha_creacion"].ToString()),
                isEliminado= Convert.ToBoolean(dr["is_eliminado"]),
            };
            return _datosFacturacion;
        }

        public List<DatoFacturacionNew> GetAll()
        {
            var result = new List<DatoFacturacionNew>();
            var cmd = CreateCommand("SELECT*FROM datos_facturaciones_new");
            using (var unDatoFacturacion = cmd.ExecuteReader())
            {
                while (unDatoFacturacion.Read())
                {
                    result.Add(CreateEntity(unDatoFacturacion));
                }
            }
            return result;
        }

        public DatoFacturacionNew GetById(int id)
        {

            var cmd = CreateCommand("SELECT*FROM datos_facturaciones_new WHERE id_dato_facturacion = @id");
            cmd.Parameters.AddWithValue("@id", id);
            DatoFacturacionNew dato=new DatoFacturacionNew();
            using (var reader = cmd.ExecuteReader()){reader.Read();dato = CreateEntity(reader); return dato;}
        }

        public bool IsExistRazonSocial(string _razonSocial)
        {
            var cmd = CreateCommand("SELECT*FROM datos_facturaciones_new WHERE razon_social=@razon_social");
            cmd.Parameters.AddWithValue("@razon_social", _razonSocial);
            using (var reader = cmd.ExecuteReader())
            {
                reader.Read();
                return reader.HasRows;
            }
        }

        public int Remove(DatoFacturacionNew _datoFacturacion)
        {
            var cmd = CreateCommand("DELETE FROM datos_facturaciones_new WHERE id_dato_facturacion = @id");
            cmd.Parameters.AddWithValue("@id", _datoFacturacion.IdDatoFacturacion);
            return cmd.ExecuteNonQuery();
        }

        public int Update(DatoFacturacionNew t)
        {
            var cmd = CreateCommand("UPDATE datos_facturaciones_new SET rut = @rut,razon_social= @razon_social, " +
                  "direccion = @direccion,comuna_estado = @comuna_estado,id_giro_facturacion = @id_giro_facturacion, " +
                  "email_intercambio = @email_intercambio,documento_pago = @documento_pago,forma_pago_estado = @forma_pago_estado," +
                  "id_usuario=@id_usuario,fecha_creacion = @fecha_creacion " +
                  "WHERE id_dato_facturacion = @id_dato_facturacion");
            GetEntity(t, ref cmd);
            return cmd.ExecuteNonQuery(); ;
        }

        public int UpdateSoftDelete(int _id, bool _isEliminado)
        {
            var cmd = CreateCommand("UPDATE datos_facturaciones_new SET is_eliminado=@isEliminado " +
                "WHERE id_dato_facturacion = @id_dato_facturacion");
            cmd.Parameters.AddWithValue("@id_dato_facturacion", _id);
            cmd.Parameters.AddWithValue("@isEliminado", _isEliminado);
            return cmd.ExecuteNonQuery();
        }
        public void GetEntity(DatoFacturacionNew _datosFacturacion, ref SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@id_dato_facturacion", _datosFacturacion.IdDatoFacturacion);
            cmd.Parameters.AddWithValue("@rut", _datosFacturacion.Rut);
            cmd.Parameters.AddWithValue("@razon_social", _datosFacturacion.RazonSocial);
            cmd.Parameters.AddWithValue("@direccion", _datosFacturacion.Direccion);
            cmd.Parameters.AddWithValue("@comuna_estado", _datosFacturacion.ComunaEstado);
            cmd.Parameters.AddWithValue("@id_giro_facturacion", _datosFacturacion.IdGiroFacturacion);
            cmd.Parameters.AddWithValue("@email_intercambio", _datosFacturacion.EmailIntercambio);
            cmd.Parameters.AddWithValue("@documento_pago", _datosFacturacion.DocumentoPago);
            cmd.Parameters.AddWithValue("@forma_pago_estado", _datosFacturacion.FormaPagoEstado);
            cmd.Parameters.AddWithValue("@id_usuario", _datosFacturacion.IdUsuario);
            cmd.Parameters.AddWithValue("@fecha_creacion", _datosFacturacion.FechaCreacion);
        }
    }
}
