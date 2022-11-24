using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NinosActivos.Modelos
{
    internal class Encriptado
    {
        public static string ObtenerMD5(string contrasena)
        {
            var md5 = MD5.Create();
            var encoding = new ASCIIEncoding();
            var sb = new StringBuilder();
            byte[] stream = md5.ComputeHash(encoding.GetBytes(contrasena));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
    }
}
