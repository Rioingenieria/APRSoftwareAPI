using Common.Constantes;
using Models.MedidoresNew;
using RepositoryInterface.MedidoresNew;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorySqlServer.MedidoresNew
{
    public class MedidorNewRepository : Repository, IMedidorNewRepository
    {
        public MedidorNewRepository(SqlConnection context, SqlTransaction transaction)
        {
            _context = context;
            _transaction = transaction;
        }
        public int Create(MedidorNew _medidorNew)
        {
            var cmd = CreateCommand("INSERT INTO medidores_new" +
                                    "           (numero_medidor" +
                                    "           ,instalacion_fecha" +
                                    "           ,instalacion_fecha_verdad" +
                                    "           ,unidad_medidor_estado" +
                                    "           ,alcantarillado" +
                                    "           ,id_subsidio" +
                                    "           ,id_cliente" +
                                    "           ,id_red" +
                                    "           ,nicho" +
                                    "           ,diametro_estado" +
                                    "           ,id_emplazamiento" +
                                    "           ,segundo_hogar" +
                                    "           ,estado_cliente_estado" +
                                    "           ,id_exencion" +
                                    "           ,id_sector" +
                                    "           ,id_tarifa" +
                                    "           ,id_configuracion_periodico" +
                                    "           ,id_dato_facturacion" +
                                    "           ,tipo_medidor_estado" +
                                    "           ,sincronizacion_web" +
                                    "           ,id_cliente_global" +
                                    "           ,numero_vivienda" +
                                    "           ,direccion" +
                                    "           ,id_configuracion_facturacion" +
                                    "           ,fecha_creacion" +
                                    "           ,id_usuario" +
                                    "           ,is_eliminado)" +
                                    "     VALUES" +
                                    "           (@numero_medidor" +
                                    "           ,@instalacion_fecha" +
                                    "           ,@instalacion_fecha_verdad" +
                                    "           ,@unidad_medidor_estado" +
                                    "           ,@alcantarillado" +
                                    "           ,@id_subsidio" +
                                    "           ,@id_cliente" +
                                    "           ,@id_red" +
                                    "           ,@nicho" +
                                    "           ,@diametro_estado" +
                                    "           ,@id_emplazamiento" +
                                    "           ,@segundo_hogar" +
                                    "           ,@estado_cliente_estado" +
                                    "           ,@id_exencion" +
                                    "           ,@id_sector" +
                                    "           ,@id_tarifa" +
                                    "           ,@id_configuracion_periodico" +
                                    "           ,@id_dato_facturacion" +
                                    "           ,@tipo_medidor_estado" +
                                    "           ,@sincronizacion_web" +
                                    "           ,@id_cliente_global" +
                                    "           ,@numero_vivienda" +
                                    "           ,@direccion" +
                                    "           ,@id_configuracion_facturacion " +
                                    "           ,@fecha_creacion " +
                                    "           ,@id_usuario " +
                                    "           ,@is_eliminado)");
            GetEntity(_medidorNew, ref cmd);
            return cmd.ExecuteNonQuery();
        }
        public MedidorNew GetById(int id)
        {
            var _medidorNew = new MedidorNew();
            var cmd = CreateCommand("SELECT     id_medidor" +
                                    "           ,numero_medidor" +
                                    "           ,instalacion_fecha" +
                                    "           ,instalacion_fecha_verdad" +
                                    "           ,unidad_medidor_estado" +
                                    "           ,alcantarillado" +
                                    "           ,id_subsidio" +
                                    "           ,id_cliente" +
                                    "           ,id_red" +
                                    "           ,nicho" +
                                    "           ,diametro_estado" +
                                    "           ,id_emplazamiento" +
                                    "           ,segundo_hogar" +
                                    "           ,estado_cliente_estado" +
                                    "           ,id_exencion" +
                                    "           ,id_sector" +
                                    "           ,id_tarifa" +
                                    "           ,id_configuracion_periodico" +
                                    "           ,id_dato_facturacion" +
                                    "           ,tipo_medidor_estado" +
                                    "           ,sincronizacion_web" +
                                    "           ,id_cliente_global" +
                                    "           ,numero_vivienda" +
                                    "           ,direccion " +
                                    "           ,id_configuracion_facturacion " +
                                    "           ,fecha_creacion " +
                                    "           ,id_usuario " +
                                    "           ,is_eliminado " +
                                    "FROM   medidores_new " +
                                    "WHERE id_medidor = @id");
            cmd.Parameters.AddWithValue("@id", id);
            using (var unMedidorNew = cmd.ExecuteReader())
            {
                //_medidorNew = CreateEntity(unMedidorNew);
                //_medidorNew.IdMedidor = Convert.ToInt32(unMedidorNew["id_medidor"]);
                _medidorNew.NumeroMedidor = unMedidorNew["numero_medidor"].ToString();
                _medidorNew.InstalacionFecha = Convert.ToDateTime(unMedidorNew["instalacion_fecha"].ToString());
                _medidorNew.InstalacionFechaVerdad = Convert.ToBoolean(unMedidorNew["instalacion_fecha_verdad"]);
                _medidorNew.UnidadMedidorEstado = Convert.ToInt32(unMedidorNew["unidad_medidor_estado"]);
                _medidorNew.Alcantarillado = Convert.ToBoolean(unMedidorNew["alcantarillado"]);
                _medidorNew.IdSubsidio = Convert.ToInt32(unMedidorNew["id_subsidio"]);
                _medidorNew.IdCliente = Convert.ToInt32(unMedidorNew["id_cliente"]);
                _medidorNew.IdRed = Convert.ToInt32(unMedidorNew["id_red"]);
                _medidorNew.Nicho = Convert.ToBoolean(unMedidorNew["nicho"]);
                _medidorNew.DiametroEstado = Convert.ToInt32(unMedidorNew["diametro_estado"]);
                _medidorNew.IdEmplazamiento = Convert.ToInt32(unMedidorNew["id_emplazamiento"]);
                _medidorNew.SegundoHogar = Convert.ToInt32(unMedidorNew["segundo_hogar"]);
                _medidorNew.EstadoClienteEstado = Convert.ToInt32(unMedidorNew["estado_cliente_estado"]);
                _medidorNew.IdExencion = Convert.ToInt32(unMedidorNew["id_exencion"]);
                _medidorNew.IdSector = Convert.ToInt32(unMedidorNew["id_sector"]);
                _medidorNew.IdTarifa = Convert.ToInt32(unMedidorNew["id_tarifa"]);
                _medidorNew.IdConfiguracionPeriodico = Convert.ToInt32(unMedidorNew["id_configuracion_periodico"]);
                _medidorNew.IdDatoFacturacion = Convert.ToInt32(unMedidorNew["id_dato_configuracion"]);
                _medidorNew.TipoMedidorEstado = Convert.ToInt32(unMedidorNew["tipo_medidor_estado"]);
                _medidorNew.SincronizacionWeb = Convert.ToBoolean(unMedidorNew["sincronizacion_web"]);
                _medidorNew.IdClienteGlobal = Convert.ToInt32(unMedidorNew["id_cliente_global"]);
                _medidorNew.NumeroVivienda = Convert.ToInt32(unMedidorNew["numero_vivienda"]);
                _medidorNew.Direccion = unMedidorNew["direccion"].ToString();
                _medidorNew.IdConfiguracionFacturacion = Convert.ToInt32(unMedidorNew["id_configuracion_facturacion"]);
                _medidorNew.FechaCreacion = Convert.ToDateTime(unMedidorNew["fecha_creacion"].ToString());
                _medidorNew.IdUsuario = Convert.ToInt32(unMedidorNew["id_usuario"]);
                _medidorNew.IsEliminado = Convert.ToBoolean(unMedidorNew["is_eliminado"]);
            }
            return _medidorNew;
        }
        public List<MedidorNew> GetAll()
        {
            var result = new List<MedidorNew>();
            var cmd = CreateCommand("SELECT     id_medidor" +
                                    "           ,numero_medidor" +
                                    "           ,instalacion_fecha" +
                                    "           ,instalacion_fecha_verdad" +
                                    "           ,unidad_medidor_estado" +
                                    "           ,alcantarillado" +
                                    "           ,id_subsidio" +
                                    "           ,id_cliente" +
                                    "           ,id_red" +
                                    "           ,nicho" +
                                    "           ,diametro_estado" +
                                    "           ,id_emplazamiento" +
                                    "           ,segundo_hogar" +
                                    "           ,estado_cliente_estado" +
                                    "           ,id_exencion" +
                                    "           ,id_sector" +
                                    "           ,id_tarifa" +
                                    "           ,id_configuracion_periodico" +
                                    "           ,id_dato_facturacion" +
                                    "           ,tipo_medidor_estado" +
                                    "           ,sincronizacion_web" +
                                    "           ,id_cliente_global" +
                                    "           ,numero_vivienda" +
                                    "           ,direccion " +
                                    "           ,id_configuracion_facturacion " +
                                    "           ,fecha_creacion " +
                                    "           ,id_usuario " +
                                    "           ,is_eliminado " +
                                    "FROM   medidores_new");
            using (var unMedidorNew = cmd.ExecuteReader())
            {
                while (unMedidorNew.Read())
                {
                    result.Add(CreateEntity(unMedidorNew));
                }
            }
            return result;
        }
        public int Remove(MedidorNew _medidorNew)
        {
            var cmd = CreateCommand("DELETE FROM medidores_new " +
                                    "WHERE id_medidor = @id");
            cmd.Parameters.AddWithValue("@id", _medidorNew.IdMedidor);
            return cmd.ExecuteNonQuery();
        }
        public int Update(MedidorNew _medidorNew)
        {
            var cmd = CreateCommand("UPDATE medidores_new" +
                                    "   SET numero_medidor = @numero_medidor" +
                                    "      ,instalacion_fecha = @instalacion_fecha" +
                                    "      ,instalacion_fecha_verdad = @instalacion_fecha_verdad" +
                                    "      ,unidad_medidor_estado = @unidad_medidor_estado" +
                                    "      ,alcantarillado = @alcantarillado" +
                                    "      ,id_subsidio = @id_subsidio" +
                                    "      ,id_cliente = @id_cliente" +
                                    "      ,id_red = @id_red" +
                                    "      ,nicho = @nicho" +
                                    "      ,diametro_estado = @diametro_estado" +
                                    "      ,id_emplazamiento = @id_emplazamiento" +
                                    "      ,segundo_hogar = @segundo_hogar" +
                                    "      ,estado_cliente_estado = @estado_cliente_estado" +
                                    "      ,id_exencion = @id_exencion" +
                                    "      ,id_sector = @id_sector" +
                                    "      ,id_tarifa = @id_tarifa" +
                                    "      ,id_configuracion_periodico = @id_configuracion_periodico" +
                                    "      ,id_dato_facturacion = @id_dato_facturacion" +
                                    "      ,tipo_medidor_estado = @tipo_medidor_estado" +
                                    "      ,sincronizacion_web = @sincronizacion_web" +
                                    "      ,id_cliente_global = @id_cliente_global" +
                                    "      ,numero_vivienda = @numero_vivienda" +
                                    "      ,direccion = @direccion" +
                                    "      ,id_configuracion_facturacion = @id_configuracion_facturacion " +
                                    "      ,fecha_creacion = @fecha_creacion " +
                                    "      ,id_usuario = @id_usuario " +
                                    "      ,is_eliminado = @is_eliminado " +
                                    " WHERE id_medidor = @id_medidor");
            GetEntity(_medidorNew, ref cmd);
            return cmd.ExecuteNonQuery();
        }
        public int UpdateSoftDelete(int _id, bool _isEliminado)
        {
            var cmd = CreateCommand("UPDATE medidores_new " +
                                    "   SET is_eliminado = @isEliminado " +
                                    "WHERE id_medidor = @id_medidor ");

            cmd.Parameters.AddWithValue("@id_medidor", _id);
            cmd.Parameters.AddWithValue("@isEliminado", _isEliminado);
            return cmd.ExecuteNonQuery();
        }
        public bool IsExistNumeroMedidorNew(string _numeroMedidorNew)
        {
            var cmd = CreateCommand("SELECT*FROM medidores_new " +
                "WHERE numero_medidor=@numero_medidor");
            cmd.Parameters.AddWithValue("@numero_medidor", _numeroMedidorNew);
            using (var reader = cmd.ExecuteReader())
            {
                reader.Read();
                return reader.HasRows;
            }
        }
        public MedidorNew CreateEntity(SqlDataReader unMedidorNew)
        {
            MedidorNew _medidorNew = new MedidorNew();
            //{
            //    IdMedidor = Convert.ToInt32(unMedidorNew["id_medidor"]),
            //    NumeroMedidor = unMedidorNew["numero_medidor"].ToString(),
            //    InstalacionFecha = Convert.ToDateTime(unMedidorNew["instalacion_fecha"].ToString()),
            //    InstalacionFechaVerdad = Convert.ToBoolean(unMedidorNew["instalacion_fecha_verdad"]),
            //    UnidadMedidorEstado = Convert.ToInt32(unMedidorNew["unidad_medidor_estado"]),
            //    Alcantarillado = Convert.ToBoolean(unMedidorNew["alcantarillado"]),
            //    IdSubsidio = Convert.ToInt32(unMedidorNew["id_subsidio"]),
            //    IdCliente = Convert.ToInt32(unMedidorNew["id_cliente"]),
            //    IdRed = Convert.ToInt32(unMedidorNew["id_red"]),
            //    Nicho = Convert.ToBoolean(unMedidorNew["nicho"]),
            //    DiametroEstado = Convert.ToInt32(unMedidorNew["diametro_estado"]),
            //    IdEmplazamiento = Convert.ToInt32(unMedidorNew["id_emplazamiento"]),
            //    SegundoHogar = Convert.ToInt32(unMedidorNew["segundo_hogar"]),
            //    EstadoClienteEstado = Convert.ToInt32(unMedidorNew["estado_cliente_estado"]),
            //    IdExencion = Convert.ToInt32(unMedidorNew["id_exencion"]),
            //    IdSector = Convert.ToInt32(unMedidorNew["id_sector"]),
            //    IdTarifa = Convert.ToInt32(unMedidorNew["id_tarifa"]),
            //    IdConfiguracionPeriodico = Convert.ToInt32(unMedidorNew["id_configuracion_periodico"]),
            //    IdDatoFacturacion = Convert.ToInt32(unMedidorNew["id_dato_configuracion"]),
            //    TipoMedidorEstado = Convert.ToInt32(unMedidorNew["tipo_medidor_estado"]),
            //    SincronizacionWeb = Convert.ToBoolean(unMedidorNew["sincronizacion_web"]),
            //    IdClienteGlobal = Convert.ToInt32(unMedidorNew["id_cliente_global"]),
            //    NumeroVivienda = Convert.ToInt32(unMedidorNew["numero_vivienda"]),
            //    Direccion = unMedidorNew["direccion"].ToString(),
            //    IdConfiguracionFacturacion = Convert.ToInt32(unMedidorNew["id_configuracion_facturacion"]),
            //    FechaCreacion = Convert.ToDateTime(unMedidorNew["fecha_creacion"].ToString()),
            //    IdUsuario = Convert.ToInt32(unMedidorNew["id_usuario"]),
            //    IsEliminado = Convert.ToBoolean(unMedidorNew["is_eliminado"])
            //};
            _medidorNew.IdMedidor = Convert.ToInt32(unMedidorNew["id_medidor"]);
           _medidorNew.NumeroMedidor = unMedidorNew["numero_medidor"].ToString();
           _medidorNew.InstalacionFecha = Convert.ToDateTime(unMedidorNew["instalacion_fecha"].ToString());
           _medidorNew.InstalacionFechaVerdad = Convert.ToBoolean(unMedidorNew["instalacion_fecha_verdad"]);
           _medidorNew.UnidadMedidorEstado = Convert.ToInt32(unMedidorNew["unidad_medidor_estado"]);
           _medidorNew.Alcantarillado = Convert.ToBoolean(unMedidorNew["alcantarillado"]);
           _medidorNew.IdSubsidio = Convert.ToInt32(unMedidorNew["id_subsidio"]);
           _medidorNew.IdCliente = Convert.ToInt32(unMedidorNew["id_cliente"]);
           _medidorNew.IdRed = Convert.ToInt32(unMedidorNew["id_red"]);
           _medidorNew.Nicho = Convert.ToBoolean(unMedidorNew["nicho"]);
           _medidorNew.DiametroEstado = Convert.ToInt32(unMedidorNew["diametro_estado"]);
           _medidorNew.IdEmplazamiento = Convert.ToInt32(unMedidorNew["id_emplazamiento"]);
           _medidorNew.SegundoHogar = Convert.ToInt32(unMedidorNew["segundo_hogar"]);
           _medidorNew.EstadoClienteEstado = Convert.ToInt32(unMedidorNew["estado_cliente_estado"]);
           _medidorNew.IdExencion = Convert.ToInt32(unMedidorNew["id_exencion"]);
           _medidorNew.IdSector = Convert.ToInt32(unMedidorNew["id_sector"]);
           _medidorNew.IdTarifa = Convert.ToInt32(unMedidorNew["id_tarifa"]);
           _medidorNew.IdConfiguracionPeriodico = Convert.ToInt32(unMedidorNew["id_configuracion_periodico"]);
           _medidorNew.IdDatoFacturacion = Convert.ToInt32(unMedidorNew["id_dato_configuracion"]);
           _medidorNew.TipoMedidorEstado = Convert.ToInt32(unMedidorNew["tipo_medidor_estado"]);
           _medidorNew.SincronizacionWeb = Convert.ToBoolean(unMedidorNew["sincronizacion_web"]);
           _medidorNew.IdClienteGlobal = Convert.ToInt32(unMedidorNew["id_cliente_global"]);
           _medidorNew.NumeroVivienda = Convert.ToInt32(unMedidorNew["numero_vivienda"]);
           _medidorNew.Direccion = unMedidorNew["direccion"].ToString();
           _medidorNew.IdConfiguracionFacturacion = Convert.ToInt32(unMedidorNew["id_configuracion_facturacion"]);
           _medidorNew.FechaCreacion = Convert.ToDateTime(unMedidorNew["fecha_creacion"].ToString());
           _medidorNew.IdUsuario = Convert.ToInt32(unMedidorNew["id_usuario"]);
            _medidorNew.IsEliminado = Convert.ToBoolean(unMedidorNew["is_eliminado"]);
            return _medidorNew;
        }
        public void GetEntity(MedidorNew _medidorNew, ref SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@id_medidor", _medidorNew.IdMedidor);
            cmd.Parameters.AddWithValue("@numero_medidor", _medidorNew.NumeroMedidor);
            cmd.Parameters.AddWithValue("@instalacion_fecha", _medidorNew.InstalacionFecha);
            cmd.Parameters.AddWithValue("@instalacion_fecha_verdad", _medidorNew.InstalacionFechaVerdad);
            cmd.Parameters.AddWithValue("@unidad_medidor_estado", _medidorNew.UnidadMedidorEstado);
            cmd.Parameters.AddWithValue("@alcantarillado", _medidorNew.Alcantarillado);
            cmd.Parameters.AddWithValue("@id_subsidio", _medidorNew.IdSubsidio);
            cmd.Parameters.AddWithValue("@id_cliente", _medidorNew.IdCliente);
            cmd.Parameters.AddWithValue("@id_red", _medidorNew.IdRed);
            cmd.Parameters.AddWithValue("@nicho", _medidorNew.Nicho);
            cmd.Parameters.AddWithValue("@diametro_estado", _medidorNew.DiametroEstado);
            cmd.Parameters.AddWithValue("@id_emplazamiento", _medidorNew.IdEmplazamiento);
            cmd.Parameters.AddWithValue("@segundo_hogar", _medidorNew.SegundoHogar);
            cmd.Parameters.AddWithValue("@estado_cliente_estado", _medidorNew.EstadoClienteEstado);
            cmd.Parameters.AddWithValue("@id_exencion", _medidorNew.IdExencion);
            cmd.Parameters.AddWithValue("@id_sector", _medidorNew.IdSector);
            cmd.Parameters.AddWithValue("@id_tarifa", _medidorNew.IdTarifa);
            cmd.Parameters.AddWithValue("@id_configuracion_periodico", _medidorNew.IdConfiguracionPeriodico);
            cmd.Parameters.AddWithValue("@id_dato_facturacion", _medidorNew.IdDatoFacturacion);
            cmd.Parameters.AddWithValue("@tipo_medidor_estado", _medidorNew.TipoMedidorEstado);
            cmd.Parameters.AddWithValue("@sincronizacion_web", _medidorNew.SincronizacionWeb);
            cmd.Parameters.AddWithValue("@id_cliente_global", _medidorNew.IdClienteGlobal);
            cmd.Parameters.AddWithValue("@numero_vivienda", _medidorNew.NumeroVivienda);
            cmd.Parameters.AddWithValue("@direccion", _medidorNew.Direccion);
            cmd.Parameters.AddWithValue("@id_configuracion_facturacion", _medidorNew.IdConfiguracionFacturacion);
            cmd.Parameters.AddWithValue("@fecha_creacion", _medidorNew.FechaCreacion);
            cmd.Parameters.AddWithValue("@id_usuario", _medidorNew.IdUsuario);
            cmd.Parameters.AddWithValue("@is_eliminado", _medidorNew.IsEliminado);
        }
    }
}
