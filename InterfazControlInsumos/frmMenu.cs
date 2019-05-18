using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfazControlInsumos
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void marcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMarca form = new frmMarca();
            form.Show();
        }

        private void tipoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTipo form = new frmTipo();
            form.Show();
        }

        private void proveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProveedor form = new frmProveedor();
            form.Show();
        }

        private void insumosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInsumos form = new frmInsumos();
            form.Show();
        }
    }
}
