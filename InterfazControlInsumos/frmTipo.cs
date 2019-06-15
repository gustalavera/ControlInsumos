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
            Tipo tipo = new Tipo();
            tipo.Descripcion = txtDescripcion.Text;



            Tipo.AgregarTipo(tipo);
            LimpiarFormulario();
            ActualizarListaTipo();

        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            int index = lstTipo.SelectedIndex;
            Tipo m = ObtenerTipoFormulario();
            Tipo.ModificarTipo(index, m);


            LimpiarFormulario();
            ActualizarListaTipo();

           
           
        }
        private Tipo ObtenerTipoFormulario()
        {
            Tipo tipo = new Tipo();
            tipo.Id = Convert.ToInt16(txtId.Text);
            tipo.Descripcion = txtDescripcion.Text;

            return tipo;
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
            lstTipo.DataSource = Tipo.ObtenerTipos();
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
                txtId.Text = Convert.ToString(tipo.Id);
                txtDescripcion.Text = tipo.Descripcion;
            }

        }

        private void lstTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
