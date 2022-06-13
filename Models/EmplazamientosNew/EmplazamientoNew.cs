using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.EmplazamientosNew
{
    public class EmplazamientoNew
    {
        private int _id_emplazamiento;
        private string _Rol;
        private string _lote;
        private string _parcela;
        private byte[] _plano;
        private Boolean _is_eliminado;

        public Boolean isEliminado
        {
            get { return _is_eliminado; }
            set { _is_eliminado = value; }
        }

        public byte[] plano
        {
            get { return _plano; }
            set { _plano = value; }
        }

        public string parcela
        {
            get { return _parcela; }
            set { _parcela = value; }
        }
        public string lote
        {
            get { return _lote; }
            set { _lote = value; }
        }

        public string rol
        {
            get { return _Rol; }
            set { _Rol = value; }
        }

        public int idEmplazamiento
        {
            get { return _id_emplazamiento; }
            set { _id_emplazamiento = value; }
        }

    }
}
