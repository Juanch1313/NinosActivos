using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace NinosActivos.Mysql
{
    internal class Modificaciones
    {
        public static bool ModificarDificultad(char Dificultad)
        {
            var resultado = 0;
            try
            {
                var comando = new MySqlCommand(String.Format(
                    $"UPDATE plan " +
                    $"SET Dificultad = '{Dificultad}' " +
                    $"WHERE NinoID = {Selecciones.ObtenerUsuario().ID}")
                    ,Conexion.obtenerConexion());
                resultado = comando.ExecuteNonQuery();
            }
            catch { throw; }
            return resultado > 0;
        }
        
        public static bool ModificarFecha()
        {
            var resultado = 0;
            try
            {
                var comando = new MySqlCommand(String.Format(
                    $"UPDATE plan " +
                    $"SET Fecha = NOW() " +
                    $"WHERE NinoID = {Selecciones.ObtenerUsuario().ID}")
                    , Conexion.obtenerConexion());
                resultado = comando.ExecuteNonQuery();
            }
            catch { throw; }
            return resultado > 0;
        }
    }
}
