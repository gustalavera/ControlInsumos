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
        Insumo insumo;

        public frmInsumos()
        {
            InitializeComponent();
        }

        private void frmInsumos_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Insumo insumo = ObtenerInsumos();

            Insumo.AgregarInsumos(insumo);

            ActualizarListaInsumos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Insumo insumo = (Insumo)lstInsumos.SelectedItem;
            Insumo.EliminarInsumos(insumo);
            ActualizarListaInsumos();
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            txtCodigo.Text = "";
            txtDescripcion.Text = "";

            cmbMarca.SelectedItem = "";

            cmbTipo.SelectedItem = "";
            cmbMarca.SelectedItem = "";
            txtCantidadDisponible.Text = "";
            txtCantidadMinima.Text = "";
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int index = lstInsumos.SelectedIndex;
            Insumo.listaInsumos[index] = ObtenerInsumos();

            ActualizarListaInsumos();
        }

        private Insumo ObtenerInsumos()
        {
            Insumo insumo = new Insumo();
            insumo.Descripcion = txtDescripcion.Text;
            insumo.Marca = (Marca)cmbMarca.SelectedItem;
            insumo.Tipo = (Tipo)cmbTipo.SelectedItem;
            insumo.Proveedor = (Proveedor)cmbMarca.SelectedItem;
            insumo.Cantidad_Disponible = txtCantidadDisponible.Text;
             insumo.Cantidad_Minima = txtCantidadMinima.Text;
            //verificar


            return insumo;
        }
        private void ActualizarListaInsumos()
        {
            lstInsumos.DataSource = null;
            lstInsumos.DataSource = Insumo.ObtenerInsumo();
        }
    }
}

