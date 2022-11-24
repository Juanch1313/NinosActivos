using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NinosActivos.Algoritmo;
using NinosActivos.Mysql;

namespace NinosActivos
{
    public partial class ModificarPlan : Form
    {
        private PerfilNino _PerfilNino = new PerfilNino();
        public ModificarPlan()
        {
            InitializeComponent();
        }

        private void PbRegresar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ModificarPlan_Load(object sender, EventArgs e)
        {
            DgvPlan.DataSource = Floyd.ObtenerPlan(Selecciones.ObtenerDificultad());
            DgvPlan.AutoResizeRows();
            DgvPlan.AutoResizeColumns();
            Modificaciones.ModificarFecha();
        }

        private void BtnPerfil_Click(object sender, EventArgs e)
        {
            Hide();
            _PerfilNino.ShowDialog();
            Show();
        }
    }
}
