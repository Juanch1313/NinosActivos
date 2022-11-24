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
using NinosActivos.Modelos;

namespace NinosActivos
{
    public partial class Login : Form
    {
        private static Registro _Registro = new Registro();
        private static MenuPrincipal _Principal = new MenuPrincipal();
        private static Mensaje _Mensaje = new Mensaje();
        public Login()  
        {
            InitializeComponent();
        }

        private void BtnCrear_Click(object sender, EventArgs e)
        {
            Hide();
            _Registro.ShowDialog();
            Show();
        }

        private void BtnIngreso_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(TxtUsuario.Text) || String.IsNullOrEmpty(TxtContrasena.Text) ||
                TxtUsuario.Text.Any(Char.IsWhiteSpace) || TxtContrasena.Text.Any(Char.IsWhiteSpace))
            {
                LimpiarTextos();
                _Mensaje.SetMensaje("Las casillas no pueden estar vacias y/o tener espacios. \nPorfavor llena el formulario");
                _Mensaje.ShowDialog();
                return;
            }

            if (Selecciones.ObtenerSesion(TxtUsuario.Text, Encriptado.ObtenerMD5(TxtContrasena.Text)))
            {
                LimpiarTextos();
                Hide();
                _Principal.ShowDialog();
                Show();
            }
            else
            {
                _Mensaje.SetMensaje("Usuario o contraseña erroneos");
                _Mensaje.ShowDialog();
            }
        }

        #region AYUDANTES
        private void LimpiarTextos()
        {
            TxtUsuario.Text = String.Empty;
            TxtContrasena.Text = String.Empty;
        }
        #endregion
    }
}
