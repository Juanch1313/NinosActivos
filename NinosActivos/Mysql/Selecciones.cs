using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using NinosActivos.Modelos;

namespace NinosActivos.Mysql
{
    internal class Selecciones
    {
        private static List<Ejercicio> ejercicios = new List<Ejercicio>();
        private static Nino UsuarioActual = new Nino();

        public static Nino ObtenerUsuario() { return UsuarioActual; }
        public static bool ObtenerSesion(string Usuario, string Contrasena)
        {
            var retorno = 0;
            try
            {
                var comando = new MySqlCommand(String.Format(
                    $"SELECT * FROM nino " +
                    $"WHERE Usuario = '{Usuario}' AND Contrasena = '{Contrasena}';")
                ,Conexion.obtenerConexion());
                var lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    retorno++;
                    UsuarioActual.ID = lector.GetInt32(0);
                    UsuarioActual.Nombre = lector.GetString(1);
                    UsuarioActual.Apellidos = lector.GetString(2);
                    UsuarioActual.Peso = lector.GetByte(4);
                    UsuarioActual.Estatura = lector.GetDouble(5);
                    UsuarioActual.Usuario = lector.GetString(6);
                    UsuarioActual.Contrasena = lector.GetString(7);
                }
            }
            catch
            {
            }

            return retorno == 1;  
        }

        public static List<Ejercicio> ObtenerEjercicios()
        {
            if(ejercicios.Count == 0)
            {
                var comando = new MySqlCommand(String.Format("SELECT * FROM ejercicio"), Conexion.obtenerConexion());
                var lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    var ejercicio = new Ejercicio();
                    ejercicio.ID = lector.GetInt32(0);
                    ejercicio.Nombre = lector.GetString(1);
                    ejercicio.Descripcion = lector.GetString(2);
                    ejercicio.Dificultad = lector.GetChar(3);

                    ejercicios.Add(ejercicio);
                }
                foreach (var ejer in ejercicios)
                {
                    ejer.Descripcion = ejer.Descripcion.Replace('@', '\n');
                }
            }
            return ejercicios;
        }

        public static bool ExistePlan()
        {
            var retorno = 0;
            try
            {
                var comando = new MySqlCommand(String.Format(
                    $"SELECT * FROM plan " +
                    $"WHERE NinoID = {UsuarioActual.ID}")
                    , Conexion.obtenerConexion());
                var lector = comando.ExecuteReader();
                while (lector.Read()) { retorno++; }
            }
            catch
            {
                throw;
            }
            return retorno == 1;
        }

        public static char ObtenerDificultad()
        {
            var dificultad = ' ';
            try
            {
                var comando = new MySqlCommand(String.Format(
                    $"SELECT Dificultad FROM plan WHERE NinoID = {UsuarioActual.ID}"), Conexion.obtenerConexion());
                var lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    dificultad = lector.GetChar(0);
                }
            }
            catch { throw; }
            return dificultad;
        }

        public static string ObtenerFecha()
        {
            var Fecha = "";
            try
            {
                var comando = new MySqlCommand(String.Format(
                    $"SELECT Fecha FROM plan WHERE NinoID = {UsuarioActual.ID}"), Conexion.obtenerConexion());
                var lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Fecha = lector.GetString(0);
                }
            }
            catch { throw; }
            return Fecha;
        }
    }
}
