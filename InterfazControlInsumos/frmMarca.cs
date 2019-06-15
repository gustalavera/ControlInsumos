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
    public partial class frmMarca : Form
    {
        public frmMarca()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Marca marca = new Marca();
            marca.Descripcion = txtDescripcion.Text;



            Marca.AgregarMarca(marca);
            LimpiarFormulario();
            ActualizarListaMarcas();
        }
        private void LimpiarFormulario()
        {
            txtDescripcion.Text = "";

        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            int index = lstMarca.SelectedIndex;
            Marca m = ObtenerMarcaFormulario();
            Marca.ModificarMarca(index, m);


            LimpiarFormulario();
            ActualizarListaMarcas();
        }
        private Marca ObtenerMarcaFormulario()
        {
            Marca marca = new Marca();
            marca.Id = Convert.ToInt32(txtId.Text);
            marca.Descripcion = txtDescripcion.Text;
          
            return marca;
        }

        private void ActualizarListaMarcas()
        {
            lstMarca.DataSource = null;
            lstMarca.DataSource = Marca.ObtenerMarcas();
        }

        private void frmMarca_Load(object sender, EventArgs e)
        {
            ActualizarListaMarcas();
        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }
        private void lstMarca_Click(object sender, EventArgs e)
        {
            Marca marca = (Marca)lstMarca.SelectedItem;

            if (marca != null)
            {
                txtId.Text = Convert.ToString(marca.Id);
            
                txtDescripcion.Text = marca.Descripcion;
            }

        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.lstMarca.SelectedItems.Count == 0)
            {
                MessageBox.Show("Favor seleccione una fila");
            }
            else
            {
                Marca m = (Marca)lstMarca.SelectedItem;
                Marca.EliminarMarca(m);
                ActualizarListaMarcas();
                LimpiarFormulario();
            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void lstMarca_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblDescripcion_Click(object sender, EventArgs e)
        {

        }

        private void lblCodigo_Click(object sender, EventArgs e)
        {

        }
    }
}
