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
        string modo;
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
            modo = "I";
            LimpiarFormulario();
            DesbloquearFormulario();

        }

        private void DesbloquearFormulario()
        {
            txtRazonSocial.Enabled = true;
            txtRuc.Enabled = true;
            txtDireccion.Enabled = true;
            txtEmail.Enabled = true;  
            chkDias.Enabled = true;
      
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnLimpiar.Enabled = true;

        }
        private void BloquearFormulario()
        {
            txtRazonSocial.Enabled = true;
            txtRuc.Enabled = true;
            txtDireccion.Enabled = true;
            txtEmail.Enabled = true;
            chkDias.Enabled = true;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnLimpiar.Enabled = false;

        }
        private void ActualizarListaProveedores()
        {
            lstProveedores.DataSource = null;
            lstProveedores.DataSource = Proveedor.ObtenerProveedores();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Proveedor proveedor = (Proveedor)lstProveedores.SelectedItem;
            if (proveedor != null)
            {
                Proveedor.EliminarProveedor(proveedor);
                ActualizarListaProveedores();
                LimpiarFormulario();
            }
            else
            {
                MessageBox.Show("Por favor, Seleccione un item de la lista");
            }

        }
        private void LimpiarFormulario()
        {
            txtId.Text = "";
            txtRazonSocial.Text = "";
            txtRazonSocial.Text = "";
            txtRuc.Text = "";
            txtDireccion.Text = "";
            txtContacto.Text = "";
            txtEmail.Text = "";
            ResetearCheckedListBox();

        }
        private void ResetearCheckedListBox()
        {
            chkDias.SetItemChecked(0, false);
            chkDias.SetItemChecked(1, false);
            chkDias.SetItemChecked(2, false);
            chkDias.SetItemChecked(3, false);
            chkDias.SetItemChecked(4, false);
            chkDias.SetItemChecked(5, false);
        
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void frmProveedor_Load(object sender, EventArgs e)
        {

            Proveedor p = new Proveedor();


            ActualizarListaProveedores();
            
            BloquearFormulario();
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
       
        private void ActualizarListaProveedor()
        {
            lstProveedores.DataSource = null;
            lstProveedores.DataSource = Proveedor.ObtenerProveedores();
        }
   
        private void btnModificar_Click(object sender, EventArgs e)
        {
            Proveedor proveedor = (Proveedor)lstProveedores.SelectedItem;

            if (proveedor != null)
            {
                modo = "E";
                DesbloquearFormulario();
            }
            else
            {
                MessageBox.Show("Seleccione un item de la lista");
            }
        }

        private Proveedor ObtenerProveedorFormulario()
        {
            Proveedor proveedor = new Proveedor();
            if (!string.IsNullOrWhiteSpace(txtId.Text))
            {
                proveedor.Id = Convert.ToInt32(txtId.Text);
            }

          
            proveedor.Razon_Social = txtRazonSocial.Text;
            proveedor.RUC = txtRuc.Text;
            proveedor.Direccion = txtDireccion.Text;
            proveedor.Contacto = txtContacto.Text;
            proveedor.Email = txtEmail.Text;
           
            proveedor.Dias_Visita = chkDias.CheckedItems.Cast<String>().ToList();
            return proveedor;
        }
        private void lstProveedores_Click(object sender, EventArgs e)
        {
            Proveedor proveedor = (Proveedor)lstProveedores.SelectedItem;

            if (proveedor != null)
            {
                    txtId.Text = Convert.ToString(proveedor.Id);
              txtRazonSocial.Text = proveedor.Razon_Social;
                 txtRuc.Text = proveedor.RUC;
                    txtDireccion.Text = proveedor.Direccion;
                    txtContacto.Text = proveedor.Contacto;
                    txtEmail.Text = proveedor.Email;

                    ResetearCheckedListBox();
                    foreach (string dia in proveedor.Dias_Visita)
                    {
                        if (dia == "L") chkDias.SetItemChecked(0, true);
                        else if (dia == "M") chkDias.SetItemChecked(1, true);
                        else if (dia == "X") chkDias.SetItemChecked(2, true);
                        else if (dia == "J") chkDias.SetItemChecked(3, true);
                        else if (dia == "V") chkDias.SetItemChecked(4, true);
                        else if (dia == "S") chkDias.SetItemChecked(5, true);
                        else if (dia == "D") chkDias.SetItemChecked(6, true);


                    }
                    if (true)
                    {

                    }

                }

            }
        

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            BloquearFormulario();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (modo == "I")
            {
                Proveedor proveedor = ObtenerProveedorFormulario();

                Proveedor.AgregarProveedor(proveedor);


            }
            else if (modo == "E")
            {
                int index = lstProveedores.SelectedIndex;

                Proveedor proveedor = ObtenerProveedorFormulario();
                Proveedor.EditarProveedor(index, proveedor);

            }

            ActualizarListaProveedores();
            LimpiarFormulario();
            BloquearFormulario();

        }

        private void lstProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
