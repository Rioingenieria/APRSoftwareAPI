using Common.Constantes;
using Common.Encriptacion;
using Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkSqlServer
{
    public class ConnectionStringSql
    {

        public static string CreateConnection()
        {
            string CadenaDesencriptada = Encriptacion.DesEncriptar(File.ReadAllText(Rutas.RutaBaseCarpetas + "\\configuracion.json"));
            List<CadenaConexion> cnEntity = JsonConvert.DeserializeObject<List<CadenaConexion>>(CadenaDesencriptada);
            string cnString = string.Empty;
            cnEntity[0].NombreBd = "aprsoftware";
            if (cnEntity[0].Web == "no")
            {
                cnString = "Data source=" + cnEntity[0].NombreServidor +
                                 ";Initial Catalog=" + cnEntity[0].NombreBd +
                                 ";Integrated Security=True";

            }
            else
            {
                cnString = "Data source=" + cnEntity[0].NombreServidor +
                                  ";Initial Catalog=" + cnEntity[0].NombreBd +
                   ";User Id=" + cnEntity[0].Usuario +
                  ";Password=" + cnEntity[0].Contrasena + "";
            }
            return cnString;
        }
    }
}
