using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinosActivos.Modelos
{
    internal class Nino
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public byte Edad { get; set; }
        public byte Peso { get; set; }
        public double Estatura { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }

        public Nino(int iD, string nombre, string apellidos, byte edad, byte peso, double estatura)
        {
            ID = iD;
            Nombre = nombre;
            Apellidos = apellidos;
            Edad = edad;
            Peso = peso;
            Estatura = estatura;
        }

        public Nino()
        {
        }
    }
}
