using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace NinosActivos.Mysql
{
    internal class Insercciones
    {
        //INSERCCIONES EN TABLA NIÑO
        public static bool InsertarNino(string Nombre, string Apellidos, int Edad, int Peso, 
                                        double Estatura, string Usuario, string Contrasena)
        {
            int retorno = 0;
            try
            {
                //Los comandos son exactamente igual que en el SQL comun, solo que aqui mandamos
                //los parametros que nos llegan
                var comando = new MySqlCommand(String.Format(
                    $"INSERT INTO nino(Nombre, Apellidos, Edad, Peso, Estatura, Usuario, Contrasena) " +
                    $"VALUES ('{Nombre}', '{Apellidos}', {Edad}, {Peso}, {Estatura}, '{Usuario}', MD5('{Contrasena}'));")
                    //Aqui es donde hacemos uso de la conexion, como puedes ver no se declaro el objeto
                    //Solo se manda llamar la clase eso ahorra mucha ram :D
                    ,Conexion.obtenerConexion());
                retorno = comando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            //Si se realizo la inserción devolvera el numero de columnas afectadas
            return retorno > 0;
        }

        //INSERCCIONES EN TABLA PLAN
        public static bool InsertarPlan(int NinoID, char Dificultad)
        {
            var retorno = 0;
            try
            {
                var comando = new MySqlCommand(String.Format(
                    $"INSERT INTO plan(NinoID, Dificultad) " +
                    $"VALUES ({NinoID}, '{Dificultad}')")
                    ,Conexion.obtenerConexion());
                retorno = comando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            return retorno > 0;
        }
    }
}
