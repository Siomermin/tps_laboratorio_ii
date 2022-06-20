using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using System.Diagnostics;

namespace Vista
{
    public partial class FrmEntrenamiento : Form
    {
        private Stopwatch stopWatch;
        private TemporizadorEntrenamiento temporizadorEntrenamiento;
        private Cliente clienteEntrenando;
        public FrmEntrenamiento(Cliente clienteEntrenando)
        {
            InitializeComponent();

            stopWatch = new Stopwatch();
            temporizadorEntrenamiento = new TemporizadorEntrenamiento(1000);
            temporizadorEntrenamiento.TiempoCumplido += AsignarHora;

            this.clienteEntrenando = clienteEntrenando;
        }

        /// <summary>
        /// Inicia la sesion de entrenamiento, empieza a corre el tiempo del reloj y el cronometro.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            stopWatch.Start();
            temporizadorEntrenamiento.IniciarTemporizadorEntrenamiento();

            this.lblEstadoCliente.Text = "Entrenando";
            this.btnIniciar.Enabled = false;
            this.btnDetener.Enabled = true;
        }

        /// <summary>
        /// Se detiene la sesion de entrenamiento, deja de correr el tiempo del reloj y el cronometro.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDetener_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro de terminar la sesion de entrenamiento?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                this.stopWatch.Stop();
                temporizadorEntrenamiento.DetenerTemporizadorEntrenamiento();
                this.lblEstadoCliente.Text = "Inactivo";
                this.btnIniciar.Enabled = true;
            }
        }

        /// <summary>
        /// Hace una llamada recursiva del metodo mediante un delegado para que lblTiempoArranqueEntrenamiento pueda ser modificado desde el hilo que lo creo.
        /// </summary>
        public void AsignarHora() //MANEJADOR
        {
            if (lblHorarioEntrenamiento.InvokeRequired)
            {
                
                Action asignarHora = AsignarHora;
                lblHorarioEntrenamiento.Invoke(asignarHora);
            }
            else
            {
                lblHorarioEntrenamiento.Text = DateTime.Now.ToString("h:mm:ss");
            }

        }

        private void FrmEntrenamiento_Load(object sender, EventArgs e)
        {
            this.btnDetener.Enabled = false;
            this.lblEstadoCliente.Text = "Inactivo";
            this.lblEstadoCliente.ForeColor = Color.Red;
            this.lblNombreCliente.Text = clienteEntrenando.Nombre;
            this.lblApellidoCliente.Text = clienteEntrenando.Apellido;
        }

        private void TimerEntrenamiento_Tick(object sender, EventArgs e)
        {
            this.lblCronometroStopWatch.Text = string.Format("{0:hh\\:mm\\:ss\\.ff}", stopWatch.Elapsed);
        }

        private void btnReiniciarCronometro_Click(object sender, EventArgs e)
        {
            this.stopWatch.Reset();
            this.btnIniciar.Enabled = true;
        }

        private void FrmEntrenamiento_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmClientes.ListaClientesEntrenando.Remove(clienteEntrenando);
        }
    }
}
