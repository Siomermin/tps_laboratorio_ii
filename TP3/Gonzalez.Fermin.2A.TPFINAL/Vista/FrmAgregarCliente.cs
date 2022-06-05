using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Vista
{
    public partial class FrmAgregarCliente : Form
    {
        Cliente clienteAux;
        public FrmAgregarCliente()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarCliente();

        }

        /// <summary>
        /// Agrega un cliente al gimnasio siempre que tenga atributos validos y cumpla las condiciones , si no se cumplen, se muestra el mensaje de error correspondiente.
        /// </summary>
        private void AgregarCliente()
        {
            try
            {

                this.clienteAux = Cliente.ValidarDatosCliente(this.txtNombre.Text, this.txtApellido.Text, this.nudEdad.Value, this.txtDNI.Text, this.cmbPlan.SelectedIndex);

                if (this.clienteAux is not null)    
                {
                    if (Gimnasio.AgregarCliente(clienteAux))
                    {
                        MessageBox.Show("El cliente se cargo satisfactoriamente!", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show($"El cliente con DNI: {clienteAux.Dni} ya se encuentra registrado!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }
                else
                {
                    MessageBox.Show("Datos invalidos, Vuelva a intentarlo!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
               
            }
            catch(Exception ex)
            {
                EntidadesFrm.MostrarMensajeDeError(ex);
            }
        }

        private void FrmAgregarCliente_Load(object sender, EventArgs e)
        {
            this.cmbPlan.DataSource = Enum.GetNames(typeof(ETipoPlanGimnasio));
            this.nudEdad.Maximum = 125;
            this.nudEdad.Minimum = 11;
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            EntidadesFrm.ValidarSoloLetrasTxt(e);
        }

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            EntidadesFrm.ValidarSoloNumerosTxt(e);
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            EntidadesFrm.ValidarSoloLetrasTxt(e);
        }
    }
}
