using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using IO;

namespace Vista
{
    public partial class FrmClientes : Form
    {
        private SaveFileDialog saveFileDialog;
        private string ultimoArchivo;
        private PuntoTxt puntoTxt = new PuntoTxt();
        Cliente clienteAux;
        private string UltimoArchivo
        {
            get
            {
                return ultimoArchivo;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    ultimoArchivo = value;
                }
            }
        }
        public FrmClientes()
        {
            InitializeComponent();
            puntoTxt = new PuntoTxt();
            saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivo de texto | *.txt";
        }

        /// <summary>
        /// Instancia al frmAgregarCliente en forma modal, si el DialogResult es igual a OK, actualiza el estado de los botones y el DataGridView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                FrmAgregarCliente frmAgregarCliente = new FrmAgregarCliente();

                frmAgregarCliente.ShowDialog();

                if (frmAgregarCliente.DialogResult == DialogResult.OK)
                {
                    EstadoBotones();
                    EntidadesFrm.ActualizarDGV(this.dgvListaClientes);
                    frmAgregarCliente.Close();
                }
            }
            catch (Exception ex)
            {
                EntidadesFrm.MostrarMensajeDeError(ex);
            }
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            EstadoBotones();

            EntidadesFrm.ActualizarDGV(this.dgvListaClientes);
        }

        private void dgvListaClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                EstadoBotones();
            }
            catch (Exception ex)
            {
                EntidadesFrm.MostrarMensajeDeError(ex);
            }

        }

        /// <summary>
        /// Instancia al frmModificarCliente en forma modal, si el DialogResult es igual a OK, actualiza el DataGridView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModificarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                int indexModificar = dgvListaClientes.CurrentRow.Index;

                FrmModificarCliente frmModificarCliente = new FrmModificarCliente(indexModificar);

                frmModificarCliente.ShowDialog();

                if (frmModificarCliente.DialogResult == DialogResult.OK)
                {
                    EntidadesFrm.ActualizarDGV(this.dgvListaClientes);
                }

            }
            catch (Exception ex)
            {
                EntidadesFrm.MostrarMensajeDeError(ex);
            }

        }

        /// <summary>
        /// Consulta al usuario, si esta seguro de eliminar al cliente especificado, si es asi, lo elimina y actualiza el DataGridView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bnEliminarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                int indexEliminar = dgvListaClientes.CurrentRow.Index;

                this.clienteAux = Gimnasio.ListaClientes[indexEliminar];

                if (MessageBox.Show($"Esta seguro de eliminar a: \n{this.clienteAux} ?", "Eliminar Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (Gimnasio.EliminarCliente(this.clienteAux))
                    {
                        EntidadesFrm.ActualizarDGV(this.dgvListaClientes);

                        EstadoBotones();
                    }
                }
            }
            catch (Exception ex)
            {
                EntidadesFrm.MostrarMensajeDeError(ex);
            }
        }

        /// <summary>
        /// Le da al usuario la opcion de elegir donde guardar la credencial del cliente especificado, si tiene extension .txt, escribe el contenido en el archivo y muestra un mensaje.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImprimirCredencial_Click(object sender, EventArgs e)
        {
            try
            {
                UltimoArchivo = SeleccionarUbicacionGuardado();

                int indexCredencial = dgvListaClientes.CurrentRow.Index;

                this.clienteAux = Gimnasio.ListaClientes[indexCredencial];

                if (Path.GetExtension(UltimoArchivo) == ".txt")
                {
                    this.puntoTxt.GuardarComo(ultimoArchivo, Cliente.GenerarCredencialCliente(clienteAux));

                    MessageBox.Show("Credencial guardada satisfactoriamente!", "Credencial", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                EntidadesFrm.MostrarMensajeDeError(ex);
            }
        }

        /// <summary>
        /// Le da la opcion al usuario de elegir la ruta donde guardar los archivos.
        /// </summary>
        /// <returns></returns>
        private string SeleccionarUbicacionGuardado()
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                return saveFileDialog.FileName;
            }

            return string.Empty;
        }

        /// <summary>
        /// Actualiza el estado de los botones btnModificarCliente, btnEliminarCliente y btnImprimirCredencial segun la cantidad de clientes en el gimnasio.
        /// si no hay, los botones se deshabilitan y sino, se habilitan.
        /// </summary>
        private void EstadoBotones()
        {
            if (Gimnasio.ListaClientes.Count > 0)
            {
                this.btnModificarCliente.Enabled = true;
                this.btnImprimirCredencial.Enabled = true;
                this.btnEliminarCliente.Enabled = true;
            }
            else
            {
                this.btnModificarCliente.Enabled = false;
                this.btnImprimirCredencial.Enabled = false;
                this.btnEliminarCliente.Enabled = false;
            }
        }
    }
}
