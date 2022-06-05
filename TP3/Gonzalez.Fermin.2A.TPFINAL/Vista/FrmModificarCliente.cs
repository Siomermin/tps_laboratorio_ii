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
    public partial class FrmModificarCliente : Form
    {
        Cliente clienteAModificar;
        int index;
        public FrmModificarCliente(int index)
        {
            InitializeComponent();
            this.index = index;
            this.clienteAModificar = Gimnasio.ListaClientes[index];
        }

        /// <summary>
        /// Carga los atributos del cliente seleccionado para que el usuario puede ver claramente que se va a modificar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmModificarCliente_Load(object sender, EventArgs e)
        {
            this.cmbPlan.DataSource = Enum.GetNames(typeof(ETipoPlanGimnasio));
            this.nudEdad.Maximum = 125;
            this.nudEdad.Minimum = 11;
            this.txtNombre.Text = clienteAModificar.Nombre;
            this.txtApellido.Text = clienteAModificar.Apellido;
            this.txtDNI.Text = clienteAModificar.Dni.ToString();
            this.nudEdad.Value = clienteAModificar.Edad;
            this.cmbPlan.SelectedIndex = (int)clienteAModificar.PlanGimnasio;
        }

        /// <summary>
        /// Valida que los atributos modificados del cliente sean validos, si es asi, lo agrega a la lista en la misma posicion que se encontraba.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                this.clienteAModificar = Cliente.ValidarDatosCliente(this.txtNombre.Text, this.txtApellido.Text, this.nudEdad.Value, this.txtDNI.Text, this.cmbPlan.SelectedIndex);

                if (this.clienteAModificar is not null)
                {
                    Gimnasio.ListaClientes[index] = clienteAModificar;

                    MessageBox.Show($"El cliente {this.clienteAModificar} fue modificado satisfactoriamente!", "Modificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Datos invalidos, Vuelva a intentarlo!");
                }
            }
            catch (Exception ex)
            {
                EntidadesFrm.MostrarMensajeDeError(ex);
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            EntidadesFrm.ValidarSoloLetrasTxt(e);
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            EntidadesFrm.ValidarSoloLetrasTxt(e);
        }
    }
}
