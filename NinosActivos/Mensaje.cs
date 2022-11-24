using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NinosActivos
{
    public partial class Mensaje : Form
    {
        public Mensaje()
        {
            InitializeComponent();
            MinimizeBox = false;
        }

        public void SetMensaje(string _Mensaje)
        {
            LMensaje.Text = _Mensaje;
            SetSize();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            LMensaje.Text = String.Empty;
            Close();
        }

        private void SetSize()
        {
            this.Size = new Size(LMensaje.Size.Width + 50, LMensaje.Size.Height + 180);
        }
    }
}
