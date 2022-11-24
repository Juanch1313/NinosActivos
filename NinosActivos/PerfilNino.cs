using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NinosActivos.Mysql;

namespace NinosActivos
{
    public partial class PerfilNino : Form
    {
        public PerfilNino()
        {
            InitializeComponent();
        }

        private void PbRegresar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PerfilNino_Load(object sender, EventArgs e)
        {
            var UsuarioA = Selecciones.ObtenerUsuario();
            LIMC.Text = "IMC: " + Convert.ToInt32(UsuarioA.Peso / Math.Pow(UsuarioA.Estatura, 2)).ToString();
            if((UsuarioA.Peso / Math.Pow((UsuarioA.Estatura), 2)) < 17)
            {
                LEstado.Text = "Estado Actual: Delgadez";
            }
            if ((UsuarioA.Peso / Math.Pow((UsuarioA.Estatura), 2)) > 17 &&
                (UsuarioA.Peso / Math.Pow((UsuarioA.Estatura), 2)) < 25)
            {
                LEstado.Text = "Estado Actual: Normal";
            }
            if ((UsuarioA.Peso / Math.Pow((UsuarioA.Estatura), 2)) > 25 &&
                (UsuarioA.Peso / Math.Pow((UsuarioA.Estatura), 2)) < 30)
            {
                LEstado.Text = "Estado Actual: Sobrepeso";
            }
            if ((UsuarioA.Peso / Math.Pow((UsuarioA.Estatura), 2)) > 30)
            {
                LEstado.Text = "Estado Actual: Obesidad";
            }

            LCalorias.Text = "Calorias Quemadas: 0";
            LDificultad.Text = "Nivel del plan: " + Selecciones.ObtenerDificultad().ToString();

            LNombre.Text = "Nombre: " + UsuarioA.Nombre + " " + UsuarioA.Apellidos;
            LEstatura.Text = "Estatura: " + UsuarioA.Estatura.ToString();
            LPeso.Text = "Peso: " + UsuarioA.Peso.ToString();
            LUsuario.Text = "Usuario: " + UsuarioA.Usuario.ToString();
        }
    }
}
