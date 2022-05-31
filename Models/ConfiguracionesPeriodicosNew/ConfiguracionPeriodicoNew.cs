using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ConfiguracionesPeriodicosNew
{
    public class ConfiguracionPeriodicoNew
    {
        private int _id_configuracion_periodico;
        private int _años_subsidio;
        private int _meses_subsidio;
        private Boolean _iva_usuario;
        private Boolean _funcion_escalonada;
        private string _informacion;
        private int _meses_ctramite;
        private int _dias_vencimiento;
        private int _subsidio;
        private Boolean _ultima_boleta;
        private DateTime _fecha_caducar;
        private string _caducado;
        private int _dias_noti;
        private int _porcentaje_consumo;
        private Boolean _alcantarillado;
        private Boolean _subsidio_iva;
        private Boolean _admin_subsidio;
        private string _dte;
        private string _caja_vecina;
        private Boolean _app_movil;
        private Boolean _tramo_subsidio;
        private int _tipo_servicio;
        private Boolean _exencion_iva;
        private int _dias_aviso_corte;
        private string _version;
        private int _frecuencia_servidor;
        private DateTime _periodo_inicio_servidor;
        private string _carpeta_megasync;
        private Boolean _subsidio_solo_agua;
        private string _usuario_megasnyc;
        private string _password_megasync;
        private Boolean _contar_clientes_subsidio_0;
        private string _incio_tarifa_verano;
        private string _fin_tarifa_verano;
        private int _color_principal;
        private int _color_secundario;
        private string _envio_whatsapp;
        private DateTime _fecha_creacion;
        private int _id_usuario;
        private Boolean _is_eliminado;

        public Boolean is_eliminado
        {
            get { return _is_eliminado; }
            set { _is_eliminado = value; }
        }

        public int id_usuario
        {
            get { return _id_usuario; }
            set { _id_usuario = value; }
        }

        public DateTime fecha_creacion
        {
            get { return _fecha_creacion; }
            set { _fecha_creacion = value; }
        }

        public string envio_whatsapp
        {
            get { return _envio_whatsapp; }
            set { _envio_whatsapp = value; }
        }

        public int color_secundario
        {
            get { return _color_secundario; }
            set { _color_secundario = value; }
        }

        public int color_principal
        {
            get { return _color_principal; }
            set { _color_principal = value; }
        }

        public string fin_tarifa_verano
        {
            get { return _fin_tarifa_verano; }
            set { _fin_tarifa_verano = value; }
        }

        public string inicio_tarifa_verano
        {
            get { return _incio_tarifa_verano; }
            set { _incio_tarifa_verano = value; }
        }

        public Boolean contar_clientes_subsidio_0
        {
            get { return _contar_clientes_subsidio_0; }
            set { _contar_clientes_subsidio_0 = value; }
        }

        public string password_megasync
        {
            get { return _password_megasync; }
            set { _password_megasync = value; }
        }

        public string usuario_megasync
        {
            get { return _usuario_megasnyc; }
            set { _usuario_megasnyc = value; }
        }

        public Boolean subsidio_solo_agua
        {
            get { return _subsidio_solo_agua; }
            set { _subsidio_solo_agua = value; }
        }

        public string carpeta_megasync
        {
            get { return _carpeta_megasync; }
            set { _carpeta_megasync = value; }
        }

        public DateTime periodo_inicio_servidor
        {
            get { return _periodo_inicio_servidor; }
            set { _periodo_inicio_servidor = value; }
        }

        public int frecuencia_servidor
        {
            get { return _frecuencia_servidor; }
            set { _frecuencia_servidor = value; }
        }

        public string version
        {
            get { return _version; }
            set { _version = value; }
        }

        public int dias_aviso_corte
        {
            get { return _dias_aviso_corte; }
            set { _dias_aviso_corte = value; }
        }

        public Boolean exencion_iva
        {
            get { return _exencion_iva; }
            set { _exencion_iva = value; }
        }

        public int tipo_servicio
        {
            get { return _tipo_servicio; }
            set { _tipo_servicio = value; }
        }

        public Boolean  tramo_subsidio
        {
            get { return _tramo_subsidio; }
            set { _tramo_subsidio = value; }
        }

        public Boolean app_movil
        {
            get { return _app_movil; }
            set { _app_movil = value; }
        }

        public string caja_vecina
        {
            get { return _caja_vecina; }
            set { _caja_vecina = value; }
        }

        public string dte
        {
            get { return _dte; }
            set { _dte = value; }
        }


        public Boolean admin_subsidio
        {
            get { return _admin_subsidio; }
            set { _admin_subsidio = value; }
        }

        public Boolean subsidio_iva
        {
            get { return _subsidio_iva; }
            set { _subsidio_iva = value; }
        }

        public Boolean alcantarillado
        {
            get { return _alcantarillado; }
            set { _alcantarillado = value; }
        }

        public int porcentaje_consumo
        {
            get { return _porcentaje_consumo; }
            set { _porcentaje_consumo = value; }
        }

        public int dias_noti
        {
            get { return _dias_noti; }
            set { _dias_noti = value; }
        }

        public string caducado
        {
            get { return _caducado; }
            set { _caducado = value; }
        }

        public DateTime fecha_caducar
        {
            get { return _fecha_caducar; }
            set { _fecha_caducar = value; }
        }

        public Boolean ultima_boleta
        {
            get { return _ultima_boleta; }
            set { _ultima_boleta = value; }
        }

        public int subsidio
        {
            get { return _subsidio; }
            set { _subsidio = value; }
        }
        public int dias_vencimiento
        {
            get { return _dias_vencimiento; }
            set { _dias_vencimiento = value; }
        }
        public int meses_ctramite
        {
            get { return _meses_ctramite; }
            set { _meses_ctramite = value; }
        }

        public string informacion
        {
            get { return _informacion; }
            set { _informacion = value; }
        }

        public Boolean funcion_escalonada
        {
            get { return _funcion_escalonada; }
            set { _funcion_escalonada = value; }
        }
        public Boolean iva_usuario
        {
            get { return _iva_usuario; }
            set { _iva_usuario = value; }
        }
        public int meses_subsidio
        {
            get { return _meses_subsidio; }
            set { _meses_subsidio = value; }
        }

        public int años_subsidio
        {
            get { return _años_subsidio; }
            set { _años_subsidio = value; }
        }


        public int id_configuracion_periodico
        {
            get { return _id_configuracion_periodico; }
            set { _id_configuracion_periodico = value; }
        }

    }
}
