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
    public partial class frmProveedor : Form
    {
        public frmProveedor()
        {
            InitializeComponent();
            chkDias.Items.Add("Lunes");
            chkDias.Items.Add("Martes");
            chkDias.Items.Add("Miércoles");
            chkDias.Items.Add("Jueves");
            chkDias.Items.Add("Viernes");
            chkDias.Items.Add("Sábado");


        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Proveedor proveedor = ObtenerProveedor();

            Proveedor.AgregarProveedor(proveedor);

            ActualizarListaProveedor();

          //  Proveedor proveedor = new Proveedor();
           // proveedor.Cod_Proveedor = txtCodigo.Text;
           // proveedor.RazonSocial = txtRazonSocial.Text;
           // proveedor.RUC = txtRuc.Text;
           // proveedor.Direccion = txtDireccion.Text;
           // proveedor.Contacto = txtContacto.Text;
           // proveedor.Email = txtEmail.Text;            

           // Proveedor.AgregarProveedor(proveedor);
           // lstProveedores.Items.Add(proveedor.ToString());

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Proveedor proveedor = (Proveedor)lstProveedores.SelectedItem;
            Proveedor.EliminarProveedor(proveedor);
            ActualizarListaProveedor();
            LimpiarFormulario();

        }
        private void LimpiarFormulario()
        {
            txtCodigo.Text = "";
            txtRazonSocial.Text = "";
            txtRazonSocial.Text = "";
            txtRuc.Text = "";
            txtDireccion.Text = "";
            txtContacto.Text = "";
            txtEmail.Text = "";
            
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void frmProveedor_Load(object sender, EventArgs e)
        {
              
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            lstSeleccion.Items.Clear();
            foreach (String d in chkDias.CheckedItems)
            {
                lstSeleccion.Items.Add(d);
            }
        }

        private void chkDias_SelectedIndexChanged(object sender, EventArgs e)

        {

        }
        private Proveedor ObtenerProveedor()
        {
            Proveedor proveedor = new Proveedor();
            proveedor.RazonSocial = txtRazonSocial.Text;
            proveedor.RUC = txtRuc.Text;
            proveedor.Direccion = txtRazonSocial.Text;
            proveedor.Contacto = txtRazonSocial.Text;
            proveedor.Email = txtRazonSocial.Text;
            



            return proveedor;
        }
        private void ActualizarListaProveedor()
        {
            lstProveedores.DataSource = null;
            lstProveedores.DataSource = Proveedor.ObtenerProveedor();
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            int index = lstProveedores.SelectedIndex;
            Proveedor.listaProveedores[index] = ObtenerProveedor();

            ActualizarListaProveedor();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
