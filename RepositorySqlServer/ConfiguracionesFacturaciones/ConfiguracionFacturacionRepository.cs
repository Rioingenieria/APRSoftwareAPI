using Models.ConfiguracionesFacturaciones;
using RepositoryInterface.ConfiguracionesFacturaciones;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorySqlServer.ConfiguracionesFacturaciones
{
    public class ConfiguracionFacturacionRepository : Repository, IConfiguracionFacturacionRepository
    {
        public ConfiguracionFacturacionRepository(SqlConnection context, SqlTransaction transaction)
        {
            _context = context;
            _transaction = transaction;
        }
        private void GetEntity(ConfiguracionFacturacion _configuracionFacturacion, ref SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@id_configuracion_facturacion", _configuracionFacturacion.IdConfiguracionFacturacion);
            cmd.Parameters.AddWithValue("@termica_factura", _configuracionFacturacion.TermicaFactura);
            cmd.Parameters.AddWithValue("@termica_boleta", _configuracionFacturacion.TermicaBoleta);
            cmd.Parameters.AddWithValue("@termica_comprobante", _configuracionFacturacion.TermicaComprobante);
            cmd.Parameters.AddWithValue("@cuenta_boleta", _configuracionFacturacion.CuentaBoleta);
            cmd.Parameters.AddWithValue("@saldo_anterior_dte", _configuracionFacturacion.SaldoAnteriorDTE);
            cmd.Parameters.AddWithValue("@recibo_termico", _configuracionFacturacion.ReciboTermico);
            cmd.Parameters.AddWithValue("@encabezado_cuenta_boleta", _configuracionFacturacion.EncabezadoCuentaBoleta);
            cmd.Parameters.AddWithValue("@color_principal_dte", _configuracionFacturacion.ColorPrincipalDTE);
            cmd.Parameters.AddWithValue("@color_secundario_dte", _configuracionFacturacion.ColorPrincipalDTE);
            cmd.Parameters.AddWithValue("@interes_estado", _configuracionFacturacion.InteresEstado);
            cmd.Parameters.AddWithValue("@valor_interes", _configuracionFacturacion.ValorInteres);
            cmd.Parameters.AddWithValue("@fecha_creacion", _configuracionFacturacion.FechaCreacion);
            cmd.Parameters.AddWithValue("@id_usuario", _configuracionFacturacion.IdUsuario);
            cmd.Parameters.AddWithValue("@is_eliminado", _configuracionFacturacion.IsEliminado);
        }
        public int Create(ConfiguracionFacturacion _configuracionFacturacion)
        {
            var cmd = CreateCommand("INSERT INTO configuraciones_facturaciones_new" +
                                    "           (termica_factura" +
                                    "           ,termica_boleta" +
                                    "           ,termica_comprobante" +
                                    "           ,cuenta_boleta" +
                                    "           ,saldo_anterior_dte" +
                                    "           ,recibo_termico" +
                                    "           ,encabezado_cuenta_boleta" +
                                    "           ,color_principal_dte" +
                                    "           ,color_secundario_dte" +
                                    "           ,interes_estado" +
                                    "           ,valor_interes" +
                                    "           ,fecha_creacion" +
                                    "           ,id_usuario" +
                                    "           ,is_eliminado)" +
                                    "     VALUES" +
                                    "           (@termica_factura" +
                                    "           ,@termica_boleta" +
                                    "           ,@termica_comprobante" +
                                    "           ,@cuenta_boleta" +
                                    "           ,@saldo_anterior_dte" +
                                    "           ,@recibo_termico" +
                                    "           ,@encabezado_cuenta_boleta" +
                                    "           ,@color_principal_dte" +
                                    "           ,@color_secundario_dte" +
                                    "           ,@interes_estado" +
                                    "           ,@valor_interes" +
                                    "           ,@fecha_creacion" +
                                    "           ,@id_usuario" +
                                    "           ,@is_eliminado)");
            GetEntity(_configuracionFacturacion, ref cmd);
            var result = cmd.ExecuteNonQuery();
            return result;
        }
        public ConfiguracionFacturacion CreateEntity(SqlDataReader configuracionFacturacion)
        {
            ConfiguracionFacturacion _configuracionFacturacion = new ConfiguracionFacturacion() 
            {
                IdConfiguracionFacturacion = Convert.ToInt32(configuracionFacturacion["id_configuracion_facturacion"]),
                TermicaFactura = Convert.ToBoolean(configuracionFacturacion["termica_factura"]),
                TermicaBoleta = Convert.ToBoolean(configuracionFacturacion["termica_boleta"]),
                TermicaComprobante = Convert.ToBoolean(configuracionFacturacion["termica_comprobante"]),
                CuentaBoleta = Convert.ToBoolean(configuracionFacturacion["cuenta_boleta"]),
                SaldoAnteriorDTE = Convert.ToBoolean(configuracionFacturacion["saldo_anterior_dte"]),
                ReciboTermico = Convert.ToBoolean(configuracionFacturacion["recibo_termico"]),
                EncabezadoCuentaBoleta = configuracionFacturacion["encabezado_cuenta_boleta"].ToString(),
                ColorPrincipalDTE = Convert.ToDecimal(configuracionFacturacion["color_principal_dte"]),
                ColorSecundarioDTE = Convert.ToDecimal(configuracionFacturacion["color_secundario_dte"]),
                InteresEstado = Convert.ToInt32(configuracionFacturacion["interes_estado"]),
                ValorInteres = Convert.ToDecimal(configuracionFacturacion["valor_interes"]),
                FechaCreacion = Convert.ToDateTime(configuracionFacturacion["fecha_creacion"]),
                IdUsuario = Convert.ToInt32(configuracionFacturacion["id_usuario"]),
                IsEliminado = Convert.ToBoolean(configuracionFacturacion["is_eliminado"])
            };
            return _configuracionFacturacion;
        }
        public List<ConfiguracionFacturacion> GetAll()
        {
            List<ConfiguracionFacturacion> result = new List<ConfiguracionFacturacion>();
            SqlCommand cmd = CreateCommand("SELECT * FROM configuraciones_facturaciones_new");
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(CreateEntity(reader));
                }
            }
            return result;
        }
        public ConfiguracionFacturacion GetById(int id)
        {
            ConfiguracionFacturacion result = new ConfiguracionFacturacion();
            SqlCommand cmd = CreateCommand("SELECT * FROM configuraciones_facturaciones_new " +
                                            "WHERE id_configuracion_facturacion = @id_configuracion_facturacion");
            cmd.Parameters.AddWithValue("@id_configuracion_facturacion", id);
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    result = CreateEntity(reader);
                }
            }
            return result;
        }
        public bool IsExistIdUsuario(int _idUsuario)
        {
            var cmd = CreateCommand("SELECT * FROM configuraciones_facturaciones_new " +
                "WHERE id_usuario=@id_usuario");
            cmd.Parameters.AddWithValue("@id_usuario", _idUsuario);
            using (var reader = cmd.ExecuteReader())
            {
                reader.Read();
                return reader.HasRows;
            }
        }
        public int Remove(ConfiguracionFacturacion configuracionFacturacion)
        {
            var cmd = CreateCommand("DELETE FROM configuraciones_facturaciones_new " +
                                    "WHERE id_configuracion_facturacion = @id_configuracion_facturacion");
            cmd.Parameters.AddWithValue("@id_configuracion_facturacion", configuracionFacturacion.IdConfiguracionFacturacion);
            return cmd.ExecuteNonQuery();
        }
        public int Update(ConfiguracionFacturacion configuracionFacturacion)
        {
            var cmd = CreateCommand("UPDATE configuraciones_facturaciones_new" +
                                    "   SET termica_factura = @termica_factura" +
                                    "      ,termica_boleta = @termica_boleta" +
                                    "      ,termica_comprobante = @termica_comprobante" +
                                    "      ,cuenta_boleta = @cuenta_boleta" +
                                    "      ,saldo_anterior_dte = @saldo_anterior_dte" +
                                    "      ,recibo_termico = @recibo_termico" +
                                    "      ,encabezado_cuenta_boleta = @encabezado_cuenta_boleta" +
                                    "      ,color_principal_dte = @color_principal_dte" +
                                    "      ,color_secundario_dte = @color_secundario_dte" +
                                    "      ,interes_estado = @interes_estado" +
                                    "      ,valor_interes = @valor_interes" +
                                    "      ,fecha_creacion = @fecha_creacion" +
                                    "      ,id_usuario = @id_usuario" +
                                    "      ,is_eliminado = @is_eliminado");
            GetEntity(configuracionFacturacion, ref cmd);
            var result = cmd.ExecuteNonQuery();
            return result;
        }
        public int UpdateSoftDelete(int _id, bool _isEliminado)
        {
            var cmd = CreateCommand("UPDATE configuraciones_facturaciones_new " +
                                    "   SET is_eliminado = @isEliminado " +
                                    "WHERE id_configuracion_facturacion = @id_configuracion_facturacion ");
            cmd.Parameters.AddWithValue("@id_configuracion_facturacion", _id);
            cmd.Parameters.AddWithValue("@isEliminado", _isEliminado);
            return cmd.ExecuteNonQuery();
        }
    }
}
