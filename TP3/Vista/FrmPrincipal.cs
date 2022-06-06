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
    public partial class FrmPrincipal : Form
    {
        private List<Cliente> listaClientesAux;

        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;
        private string ultimoArchivo;
        private PuntoJson<List<Cliente>> puntoJson;
        private PuntoXml<List<Cliente>> puntoXml;

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
        public FrmPrincipal()
        {
            InitializeComponent();
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivo JSON|*.json|Archivo XML|*.xml";
            saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivo JSON|*.json|Archivo XML|*.xml";
            puntoJson = new PuntoJson<List<Cliente>>();
            puntoXml = new PuntoXml<List<Cliente>>();
        }

        /// <summary>
        /// Formulario que contiene la gestion de clientes y las credenciales.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClientes_Click(object sender, EventArgs e)
        {
            try
            {
                FrmClientes frmClientes = new FrmClientes();
                frmClientes.ShowDialog();
                Guardar();
            }
            catch (Exception ex)
            {
                EntidadesFrm.MostrarMensajeDeError(ex);
            }
        }

        /// <summary>
        /// Da la opcion al usuario de elegir la ruta o archivo desde donde se cargara la lista de clientes, luego se verifica cada uno de los clientes y se valida que tengan atributos validos, si es asi, se agregan al gimnasio.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCargarClientes_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                UltimoArchivo = openFileDialog.FileName;

                try
                {
                    CargarClientes(UltimoArchivo);

                    foreach (Cliente item in this.listaClientesAux)
                    {
                        Cliente clienteAux = Cliente.ValidarDatosCliente(item.Nombre, item.Apellido, item.Edad, item.Dni.ToString(), (int)item.PlanGimnasio);
                        
                        if (clienteAux is not null)
                        {
                            if (Gimnasio.AgregarCliente(clienteAux) == false)
                            {
                                MessageBox.Show($"El cliente con DNI: {clienteAux.Dni} ya esta en la lista", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }

                            this.btnCargarClientes.Enabled = false;
                        }
                    }

                    MessageBox.Show("Los clientes se cargaron satisfactoriamente", "Carga", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    EntidadesFrm.MostrarMensajeDeError(ex);
                }
            }
        }

        /// <summary>
        /// Carga lista de clientes deserializados en una lista auxiliar.
        /// </summary>
        /// <param name="ultimoArchivo"></param>
        private void CargarClientes(string ultimoArchivo)
        {
            switch (Path.GetExtension(ultimoArchivo))
            {
                case ".json":
                    this.listaClientesAux = puntoJson.Leer(ultimoArchivo);
                    break;
                case ".xml":
                    this.listaClientesAux = puntoXml.Leer(ultimoArchivo);
                    break;
            }
        }

        /// <summary>
        /// Llama al metodo guardarComo siempre y cuando existan clientes en el gimnasio.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardarClientes_Click(object sender, EventArgs e)
        {
            if (Gimnasio.ListaClientes.Count > 0)
            {
                GuardarComo();
            }
            else
            {
                MessageBox.Show("No es posible guardar si no hay clientes cargados!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
        /// <summary>
        /// Guarda los archivos segun la extension que elegio el usuario y en un archivo ya existente.
        /// </summary>
        private void Guardar()
        {
            try
            {
                switch (Path.GetExtension(UltimoArchivo))
                {
                    case ".json":
                        puntoJson.Guardar(UltimoArchivo, Gimnasio.ListaClientes);
                        break;
                    case ".xml":
                        puntoXml.Guardar(UltimoArchivo, Gimnasio.ListaClientes);
                        break;
                }
            }
            catch (Exception ex)
            {
                EntidadesFrm.MostrarMensajeDeError(ex);
            }
        }

        /// <summary>
        /// Guarda la lista serializada en la ruta y con la extension que eligio el usuario.
        /// </summary>
        private void GuardarComo()
        { 
        
            UltimoArchivo = SeleccionarUbicacionGuardado();

            try
            {
                switch (Path.GetExtension(ultimoArchivo))
                {
                    case ".json":
                        puntoJson.GuardarComo(UltimoArchivo, Gimnasio.ListaClientes);
                        break;
                    case ".xml":
                        puntoXml.GuardarComo(UltimoArchivo, Gimnasio.ListaClientes);
                        break;
                }
            }
            catch (Exception ex)
            {
                EntidadesFrm.MostrarMensajeDeError(ex);
            }
        }

        /// <summary>
        /// Permite al usuario seleccionar que formato y que ruta va a utilizar para guardar/leer contenido.
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
    }
}
