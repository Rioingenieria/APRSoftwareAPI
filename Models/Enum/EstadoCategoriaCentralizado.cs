using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Enum
{
    public class EstadoCategoriaCentralizado
    {

        public enum EstadoCategoriaEnum
        {
            NotSet,
            EstadoCliente,
            /// <summary>
            /// Estado del registro en la base de datos. 
            ///<example>
            ///Ej. Eliminado o Vigente.
            /// </example>
            /// </summary>
            EstadoRegistro,
            /// <summary>
            /// Nombres de documentos tributarios electronicos. 
            ///<example>
            ///Ej. Factura electronica Etc.
            /// </example>
            /// </summary>
            NombreDte,
            /// <summary>
            /// Estados de los productos de inventario. 
            ///<example>
            ///Ej. Bueno,Regular Etc.
            /// </example>
            /// </summary>
            EstadoProductoInventario,
            /// <summary>
            /// Tipo subsidio socio. 
            ///<example>
            ///Ej. 100%.
            /// </example>
            /// </summary>
            TipoSubsidio


        }
    }
}
