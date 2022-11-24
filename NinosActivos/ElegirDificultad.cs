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
    public partial class ElegirDificultad : Form
    {
        private static Mensaje _Mensaje = new Mensaje();
        private static ModificarPlan _ModificarPlan = new ModificarPlan();
        public ElegirDificultad()
        {
            InitializeComponent();
        }

        private void ElegirDificultad_Load(object sender, EventArgs e)
        {
            BtnFacil.Visible = true;
            BtnMedio.Visible = true;
            BtnDificil.Visible = true;
            switch (Selecciones.ObtenerDificultad())
            {
                case 'F':
                    BtnFacil.Visible = false;
                    break;
                case 'M':
                    BtnMedio.Visible = false;
                    break;
                case 'D':
                    BtnDificil.Visible = false;
                    break;
            }
        }

        private void BtnFacil_Click(object sender, EventArgs e)
        {
            if (Modificaciones.ModificarDificultad('F'))
            {
                Hide();
                _ModificarPlan.ShowDialog();
                Close();
            }
        }

        private void BtnMedio_Click(object sender, EventArgs e)
        {
            if (Modificaciones.ModificarDificultad('M'))
            {
                Hide();
                _ModificarPlan.ShowDialog();
                Close();
            }
        }

        private void BtnDificil_Click(object sender, EventArgs e)
        {
            if (Modificaciones.ModificarDificultad('D'))
            {
                Hide();
                _ModificarPlan.ShowDialog();
                Close();
            }
        }
    }
}
