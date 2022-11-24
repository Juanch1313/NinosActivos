using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using NinosActivos.Mysql;

namespace NinosActivos
{
    public partial class Registro : Form
    {
        private static Mensaje _Mensaje = new Mensaje();
        public Registro()
        {
            InitializeComponent();
            BtnRegistrar.Visible = true;
        }

        private async void BtnRegistrar_Click(object sender, EventArgs e)
        {
            if (ChecarTextosVacios()) 
            {
                _Mensaje.SetMensaje("Algunas casillas se dejaron en blanco. \nPorfavor asegurese de rellenar todo");
                _Mensaje.ShowDialog();
            }
            else
            {
                if (ChecarNombreYApellidos())
                {
                    _Mensaje.SetMensaje("El nombre o el apellido no pueden contener numeros");
                    _Mensaje.ShowDialog();
                }
                else
                {
                    if (ChecarEdadPesoYEstatura()) 
                    { 
                        _Mensaje.SetMensaje("La edad, peso y/o estatura contienen valores invalidos");
                        _Mensaje.ShowDialog();
                    }
                    else
                    {
                        if (ChecarContraseña()) 
                        { 
                            _Mensaje.SetMensaje("La contraseña tiene que tener almenos 8 caracteres");
                            _Mensaje.ShowDialog();
                        } 
                        else
                        {
                            bool registro = Insercciones.InsertarNino(TxtNombre.Text, TxtApellidos.Text, Convert.ToInt32(TxtEdad.Text), Convert.ToInt32(TxtPeso.Text)
                            , Convert.ToDouble(TxtEstatura.Text), TxtUsuario.Text, TxtContrasena.Text);
                            if (registro) 
                            {
                                BtnRegistrar.Visible = false;
                                LbResultado.Text = "Registro exitoso"; 
                                Refresh();
                                await Task.Delay(3000);
                                Close(); 
                            }
                            else { LbResultado.Text = "No se pudo realizar el registro"; LimpiarTextos(); }
                        }
                    }
                }
            }
        }

        private void PbVer_Click(object sender, EventArgs e)
        {
            PbVer.Visible = false;
            PbOcultar.Visible = true;
            TxtContrasena.PasswordChar = '\0';
        }

        private void PbOcultar_Click(object sender, EventArgs e)
        {
            PbVer.Visible = true;
            PbOcultar.Visible = false;
            TxtContrasena.PasswordChar = '*';
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            LimpiarTextos();
            Close();
        }

        #region AYUDANTES
        private void LimpiarTextos()
        {
            TxtApellidos.Text = String.Empty;
            TxtContrasena.Text = String.Empty;
            TxtEdad.Text = String.Empty;
            TxtEstatura.Text = String.Empty;
            TxtNombre.Text = String.Empty;
            TxtPeso.Text = String.Empty;
            TxtUsuario.Text = String.Empty;
            LbResultado.Text = String.Empty;
        }

        private bool ChecarTextosVacios()
        {
            return (String.IsNullOrEmpty(TxtNombre.Text) || String.IsNullOrEmpty(TxtApellidos.Text) ||
                String.IsNullOrEmpty(TxtContrasena.Text) || String.IsNullOrEmpty(TxtEdad.Text) ||
                String.IsNullOrEmpty(TxtEstatura.Text) || String.IsNullOrEmpty(TxtPeso.Text) ||
                String.IsNullOrEmpty(TxtUsuario.Text));
        }

        private bool ChecarNombreYApellidos()
        {
            return (TxtApellidos.Text.Any(Char.IsDigit) || TxtNombre.Text.Any(Char.IsDigit));
        }

        private bool ChecarEdadPesoYEstatura()
        {
            return !(TxtEdad.Text.All(Char.IsDigit) && (TxtEstatura.Text.Any(Char.IsDigit) && TxtEstatura.Text.Any(Char.IsPunctuation)) 
                && TxtPeso.Text.All(Char.IsDigit));
        }

        private bool ChecarContraseña()
        {
            return (TxtContrasena.Text.Length < 8);
        }
        #endregion
    }
}
