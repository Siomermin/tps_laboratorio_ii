using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Vista
{
    public static class EntidadesFrm
    {
        /// <summary>
        /// Muestra el mensaje de error de la excepcion que llega por parametro y los detalles del StackTrace.
        /// </summary>
        /// <param name="ex"></param>
        public static void MostrarMensajeDeError(Exception ex)
        {
            MessageBox.Show($"Se produjo un error.\n\nMensaje de error: {ex.Message}\n\n" +
                    $"Detalles:\n\n{ex.StackTrace}");
        }

        /// <summary>
        /// Actualiza el DataGridView con los clientes del gimnasio.
        /// </summary>
        /// <param name="dgv"></param>
        public static void ActualizarDGV(DataGridView dgv)
        {
            dgv.DataSource = null;
            dgv.DataSource = Gimnasio.ListaClientes;
        }

        public static void ValidarSoloLetrasTxt(KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo letras!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
        }

        public static void ValidarSoloNumerosTxt(KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo numeros!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
        }
    }

    
}
