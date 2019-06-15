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
    public partial class frmInsumos : Form
    {
      

        public frmInsumos()
        {
            InitializeComponent();
        }

       

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Insumo insumo = ObtenerInsumoFormulario();

            Insumo.AgregarInsumo(insumo);

        }

     
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Insumo insumo = (Insumo)lstInsumos.SelectedItem;
           Insumo.EliminarInsumo(insumo);
            ActualizarListaInsumos();
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            txtId.Text = "";
            txtDescripcion.Text = "";

            cmbMarca.SelectedItem = "";

            cmbTipo.SelectedItem = "";
            cmbMarca.SelectedItem = "";
            txtCantidadDisponible.Text = "";
            txtCantidadMinima.Text = "";
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private Insumo ObtenerInsumoFormulario()
        {
            Insumo insumo = new Insumo();
           
            if (!string.IsNullOrWhiteSpace(txtId.Text))
            {
                insumo.Id = Convert.ToInt32(txtId.Text);
            }
            
            insumo.Descripcion = txtDescripcion.Text;
            insumo.Marca = (Marca)cmbMarca.SelectedItem;
            insumo.Tipo = (Tipo)cmbTipo.SelectedItem;
            insumo.Proveedor = (Proveedor)cmbProveedor.SelectedItem;
            insumo.Cantidad_Disponible = Convert.ToInt32(txtCantidadDisponible.Text);
            insumo.Cantidad_Minima = Convert.ToInt32(txtCantidadMinima.Text);
            return insumo;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int index = lstInsumos.SelectedIndex;
             Insumo i = ObtenerInsumoFormulario();
            Insumo.ModificarInsumo(index, i);


            LimpiarFormulario();
            ActualizarListaInsumos();

           
        }
        private void ActualizarListaInsumos()
        {
            lstInsumos.DataSource = null;
            lstInsumos.DataSource = Insumo.ObtenerInsumos();
        }

        

        private void lstInsumos_Click(object sender, EventArgs e)
        {
            Insumo insumo = (Insumo)lstInsumos.SelectedItem;

            if (insumo != null)
            {
                txtId.Text = Convert.ToString(insumo.Id);

                txtDescripcion.Text = insumo.Descripcion;
                cmbMarca.SelectedItem = (Marca)Marca.ObtenerMarca(insumo.Marca.Id);
                cmbTipo.SelectedItem = (Tipo)Tipo.ObtenerTipo(insumo.Tipo.Id);
                cmbProveedor.SelectedItem = (Proveedor)Proveedor.ObtenerProveedor(insumo.Proveedor.Id);
                txtCantidadDisponible.Text = Convert.ToString(insumo.Cantidad_Disponible);
                txtCantidadMinima.Text = Convert.ToString(insumo.Cantidad_Minima);

            }
        }

        private void frmInsumos_Load(object sender, EventArgs e)
        {
            Insumo pi = new Insumo();
            ActualizarListaInsumos();
            cmbMarca.DataSource = Marca.ObtenerMarcas();
            cmbTipo.DataSource = Tipo.ObtenerTipos();
            cmbProveedor.DataSource = Proveedor.ObtenerProveedores();

            cmbMarca.SelectedItem = null;
            cmbTipo.SelectedItem = null;
            cmbProveedor.SelectedItem = null;
        }
    }
}

