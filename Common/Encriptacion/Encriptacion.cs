using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Common.Encriptacion
{
    public class Encriptacion
    {

        /// <summary>
        ///  Esta función "encripta" la cadena que le envíamos en el parámentro de entrada.
        /// </summary>
        /// <param name="_cadenaAencriptar"></param>
        /// <returns></returns>

        public static string Encriptar(string _cadenaAencriptar)
        {
            string result = string.Empty;
            byte[] encryted =
            System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
            result = Convert.ToBase64String(encryted);
            return result;
        }
        /// <summary>
        /// Esta función "desencripta" la cadena que le envíamos en el parámentro de entrada.
        /// </summary>
        /// <param name="_cadenaAdesencriptar"></param>
        /// <returns></returns>
        public static string DesEncriptar(string _cadenaAdesencriptar)
        {
            string result = string.Empty;
            byte[] decryted =
            Convert.FromBase64String(_cadenaAdesencriptar);
            //result = 
            System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }
        /// <summary>
        /// Este metodo de encriptado es en un solo sentido, se comparan resultados encriptados, pero no se conoce el original desencriptado
        /// </summary>
        /// <param name="_cadenaAencriptar"></param>
        /// <returns></returns>
        public static string EncriptarSha256(string _cadenaAencriptar)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = sha256.ComputeHash(encoding.GetBytes(_cadenaAencriptar));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
    }
}
