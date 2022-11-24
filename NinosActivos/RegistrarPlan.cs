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
    public partial class RegistrarPlan : Form
    {
        private PerfilNino _PerfilNino = new PerfilNino();
        public RegistrarPlan()
        {
            InitializeComponent();
            DgvPlan.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        private void PbRegresar_Click(object sender, EventArgs e)
        {
            DgvPlan.DataSource = null;
            Close();
        }

        private void RegistrarPlan_Load(object sender, EventArgs e)
        {
            DgvPlan.DataSource = Floyd.ObtenerPlan('F');
            for (int i = 0; i < DgvPlan.RowCount; i++)
            {
                DgvPlan.AutoResizeRow(i);
            }
            for (int i = 0; i < DgvPlan.ColumnCount; i++)
            {
                DgvPlan.AutoResizeColumn(i);
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
