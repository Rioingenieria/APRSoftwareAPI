using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SalidaLogs
    {
        public enum TIPO { INFOR, ALERT, ERROR, FATAL }

        public static void Agregar(Exception ex)
        {
            Agregar(TIPO.ERROR, ex.Message);
            Agregar(TIPO.ERROR, ex.StackTrace);
            Agregar(TIPO.ERROR, ex.Source);
        }

        public static void AgregarPersonalizado(string texto)
        {
            Agregar(TIPO.INFOR, texto);
        }
        public static void AgregarLog(Exception ex)
        {
            Agregar(TIPO.ERROR, ex.Message);
            Agregar(TIPO.ERROR, ex.StackTrace);
            Agregar(TIPO.ERROR, ex.Source);
        }
        public static void Agregar(TIPO tipoMensaje, string texto)
        {
            string AppRoot = AppDomain.CurrentDomain.BaseDirectory;

            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("C:\\APRSoft_DTE\\Logs\\log.txt", rollingInterval: RollingInterval.Day, retainedFileCountLimit: 15, shared: true)
                .CreateLogger();
            switch (tipoMensaje)
            {
                case TIPO.INFOR:
                    Log.Information(texto);
                    break;
                case TIPO.ALERT:
                    Log.Warning(texto);
                    break;
                case TIPO.ERROR:
                    Log.Error(texto);
                    break;
                case TIPO.FATAL:
                    Log.Fatal(texto);
                    break;
            }
            Log.CloseAndFlush();
        }
    }
}
