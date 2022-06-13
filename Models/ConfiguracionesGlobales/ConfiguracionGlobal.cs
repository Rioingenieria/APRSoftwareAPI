using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ConfiguracionesGlobales
{
    public class ConfiguracionGlobal
    {
        private int _id_configuracion;
        private Boolean _web;
        private Boolean _is_ambiente_produccion;
        private int _id_usuario;
        private DateTime _fecha_creacion;
        private Boolean _is_eliminado;

        public Boolean isEliminado
        {
            get { return _is_eliminado; }
            set { _is_eliminado = value; }
        }

        public DateTime fechaCreacion
        {
            get { return _fecha_creacion; }
            set { _fecha_creacion = value; }
        }

        public int idUsuario
        {
            get { return _id_usuario; }
            set { _id_usuario = value; }
        }

        public Boolean isAmbienteProduccion
        {
            get { return _is_ambiente_produccion; }
            set { _is_ambiente_produccion = value; }
        }

        public Boolean web
        {
            get { return _web; }
            set { _web = value; }
        }

        public int idConfiguracion
        {
            get { return _id_configuracion; }
            set { _id_configuracion = value; }
        }


    }
}
