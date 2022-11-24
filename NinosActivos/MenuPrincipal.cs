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
    public partial class MenuPrincipal : Form
    {
        private RegistrarPlan _RegistrarPlan = new RegistrarPlan();
        private ElegirDificultad _ElegirDificultad = new ElegirDificultad();
        private PerfilNino _PerfilNino = new PerfilNino();
        private Mensaje _Mensaje = new Mensaje();
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void BtnCrearPlan_Click(object sender, EventArgs e)
        {
            if (!Selecciones.ExistePlan())
            {
                Hide();
                Insercciones.InsertarPlan(Selecciones.ObtenerUsuario().ID, 'F');
                _RegistrarPlan.ShowDialog();
                Show();
            }
            else
            {
                _Mensaje.SetMensaje("Ya cuentas con un plan\n" +
                    "Si deseas modificarlo presiona la opcion:\n" +
                    "'Modificar plan actual'\n" +
                    "En el menu principal");
                _Mensaje.ShowDialog();
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            string Fecha = DateTime.Parse(Selecciones.ObtenerFecha()).ToString("dd-MM-yyyy");
            string FechaActual = DateTime.Now.ToString("dd-MM-yyyy");
            if(FechaActual == Fecha)
            {
                _Mensaje.SetMensaje("Ya realizaste un cambio hoy\n" +
                    "Espera almenos un dia para poder hacer otro cambio");
                _Mensaje.ShowDialog();
                return;
            }
            if (Selecciones.ExistePlan())
            {
                Hide();
                _ElegirDificultad.ShowDialog();
                Show();
            }
            else
            {
                _Mensaje.SetMensaje("No cuentas con un plan\n" +
                    "Para conseguir uno presione la opcion:\n" +
                    "'Crear plan de ejercicios'\n" +
                    "En el menu principal");
                _Mensaje.ShowDialog();
            }
        }

        private void BtnPerfil_Click(object sender, EventArgs e)
        {
            Hide();
            _PerfilNino.ShowDialog();
            Show();
        }
    }
}
