using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinosActivos.Modelos
{
    internal class Ejercicio
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public char Dificultad { get; set; }

        public Ejercicio(int ID, string Nombre, string Descripcion, char Dificultad)
        {
            this.ID = ID;
            this.Nombre = Nombre;
            this.Descripcion = Descripcion;
            this.Dificultad = Dificultad;
        }

        public Ejercicio()
        {
        }
    }
}
