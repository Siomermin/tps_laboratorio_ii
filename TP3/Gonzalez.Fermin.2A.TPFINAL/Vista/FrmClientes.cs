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
        int index;
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

        private void btnAgregarCliente_Click(object sender, EventArgs e)
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

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            EstadoBotones();

            EntidadesFrm.ActualizarDGV(this.dgvListaClientes);
        }

        private void dgvListaClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.index = dgvListaClientes.CurrentRow.Index;

                EstadoBotones();
            }
            catch (Exception ex)
            {
                EntidadesFrm.MostrarMensajeDeError(ex);
            }

        }

        private void btnModificarCliente_Click(object sender, EventArgs e)
        {
            FrmModificarCliente frmModificarCliente = new FrmModificarCliente(index);

            frmModificarCliente.ShowDialog();

            if (frmModificarCliente.DialogResult == DialogResult.OK)
            {
                EntidadesFrm.ActualizarDGV(this.dgvListaClientes);
            }

        }

        private void bnEliminarCliente_Click(object sender, EventArgs e)
        {

            this.clienteAux = Gimnasio.ListaClientes[index];

            if (MessageBox.Show($"Esta seguro de eliminar a: \n{this.clienteAux} ?", "Eliminar Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (Gimnasio.EliminarCliente(this.clienteAux))
                {
                    EntidadesFrm.ActualizarDGV(this.dgvListaClientes);

                    EstadoBotones();
                }
            }
        }

        private void btnImprimirCredencial_Click(object sender, EventArgs e)
        {
            try
            {
                UltimoArchivo = SeleccionarUbicacionGuardado();

                this.clienteAux = Gimnasio.ListaClientes[index];

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

        private string SeleccionarUbicacionGuardado()
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                return saveFileDialog.FileName;
            }

            return string.Empty;
        }

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
