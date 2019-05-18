using BibliotecaClases;
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
    public partial class frmTipo : Form
    {
        public frmTipo()
        {
            InitializeComponent();
        }

        private void frmTipo_Load(object sender, EventArgs e)
        {
            ActualizarListaTipo();
        }
         private void btnAgregar_Click(object sender, EventArgs e)
        {
            Tipo tipo = ObtenerTipo();

            Tipo.AgregarTipo(tipo);

            ActualizarListaTipo();


        }
        private void btnModificar_Click(object sender, EventArgs e)
        {

            int index = lstTipo.SelectedIndex;
            Tipo.listaTipo[index] = ObtenerTipo();

            ActualizarListaTipo();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Tipo tipo = (Tipo)lstTipo.SelectedItem;
            Tipo.EliminarTipo(tipo);
            ActualizarListaTipo();
            LimpiarFormulario();

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ActualizarListaTipo()
        {
            lstTipo.DataSource = null;
            lstTipo.DataSource = Tipo.ObtenerTipo();
        }
        private Tipo ObtenerTipo()
        {
            Tipo tipo = new Tipo();
            tipo.Descripcion = txtDescripcion.Text;

            return tipo;
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }
        
        private void LimpiarFormulario()
        {
            txtDescripcion.Text = "";

        }
        private void lstTipo_Click(object sender, EventArgs e)
        {
            Tipo tipo = (Tipo)lstTipo.SelectedItem;

            if (tipo != null)
            {
                txtDescripcion.Text = tipo.Descripcion;
            }

        }

       
    }
}
