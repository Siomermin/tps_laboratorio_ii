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

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Instancia el metodo "Limpiar".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Cuando se intenta cerrar el formulario, le pregunta al usuario si esta "¿seguro de querer salir?" , si es asi se cierra y si no vuelve a el formulario principal,
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult resultado = MessageBox.Show("¿Seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
                else
                {
                    e.Cancel = false;
                }
            }
        }

        /// <summary>
        /// Al apretar el boton se intenta cerrar el formulario y le pregunta al usuario si esta "¿seguro de querer salir?" , si es asi se cierra y si no vuelve a el formulario principal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Al apretar el boton, instancia el metodo "Limpiar".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        ///  borra los datos de los TextBox, ComboBox y Label de la pantalla.
        /// </summary>
        private void Limpiar()
        {
            txtNumero1.Text = string.Empty;
            txtNumero2.Text = string.Empty;
            cmbOperador.Text = string.Empty;
            lblResultado.Text = string.Empty;
        }

        /// <summary>
        /// Al apretar el boton, valida que los campos "txtNumero1", "txtNumero2" y "cmbOperador" hayan sido ingresados, si es asi, instancia al metodo "Operar" y muestra resultado por pantalla. 
        /// Si los valores son incorrectos o el resultado de la operacion fue erronea, mostrara un mensaje segun el tipo de error que se cometio.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            if (cmbOperador.SelectedItem is null || string.IsNullOrWhiteSpace(txtNumero1.Text) || string.IsNullOrWhiteSpace(txtNumero2.Text))
            {
                lblResultado.Text = "Syntax ERROR";
                btnLimpiar.Focus();
            }
            else
            {
                double resultado = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.SelectedItem.ToString());
                if (resultado is not double.NaN && resultado is not double.MinValue)
                {
                    lblResultado.Text = resultado.ToString().Trim();

                    StringBuilder strResultado = new StringBuilder();
                    strResultado.Append($"{txtNumero1.Text.Trim()} {cmbOperador.SelectedItem} {txtNumero2.Text.Trim()} = {lblResultado.Text}");
                    lstOperaciones.Items.Add(strResultado.ToString());
                }
                else
                {
                    lblResultado.Text = "Math ERROR";
                    btnLimpiar.Focus();
                }
            }
        }

        /// <summary>
        /// Valida y modifica que los operadores ingresados sean validos para poder hacer la operacion correspondiente, si es asi, llama al metodo de clase "Operar" y retorna el resultado recibido.
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns>(double)double.NaN si algun numero o el operador ingresado no superaron la validacion, y el resultado de "Operar" si todo estuvo correcto.</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            double resultado = double.NaN;

            numero1 = numero1.Replace('.', ',');
            numero2 = numero2.Replace('.', ',');

            if (double.TryParse(numero1, out double numero1Final) && double.TryParse(numero2, out double numero2Final) && char.TryParse(operador, out char operadorFinal))
            {
                Operando num1 = new Operando(numero1Final);
                Operando num2 = new Operando(numero2Final);

                resultado = Calculadora.Operar(num1, num2, operadorFinal);
            }
            return resultado;
        }

        /// <summary>
        /// Valida que "lblResultado" sea un valor valido, si es asi, llama al metodo de clase "DecimalBinario" y convierte el resultado a binario. Si no fue posible realizar la operacion, el resultado sera "Valor inválido."
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblResultado.Text) || lblResultado.Text.Equals("Valor inválido."))
            {
                lblResultado.Text = "Valor inválido.";
                btnLimpiar.Focus();
            }
            else
            {
                lblResultado.Text = lblResultado.Text.Replace('-', ' ');

                Operando operando = new Operando(lblResultado.Text);

                StringBuilder resultadoBin = new StringBuilder();
                resultadoBin.Append($"{lblResultado.Text} = ");

                lblResultado.Text = operando.DecimalBinario(lblResultado.Text);

                resultadoBin.Append($"{lblResultado.Text} (binario)");
                if (!(lblResultado.Text.Equals("Valor inválido.")))
                {
                    lstOperaciones.Items.Add(resultadoBin.ToString().Trim());
                }
            }
        }

        /// <summary>
        /// Valida que "lblResultado" sea un valor valido, si es asi, llama al metodo de clase "BinarioDecimal" y convierte el resultado a decimal. Si no fue posible realizar la operacion, el resultado sera "Valor inválido."
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblResultado.Text) || lblResultado.Text.Equals("Valor inválido."))
            {
                lblResultado.Text = "Valor inválido.";
                btnLimpiar.Focus();
            }
            else
            {
                lblResultado.Text = lblResultado.Text.Replace('-', ' ');

                Operando operando = new Operando(lblResultado.Text);

                StringBuilder resultadoDec = new StringBuilder();
                resultadoDec.Append($"{lblResultado.Text} = ");

                lblResultado.Text = operando.BinarioDecimal(lblResultado.Text);

                resultadoDec.Append($"{lblResultado.Text} (decimal)");
                if  (!(lblResultado.Text.Equals("Valor inválido.")))
                {
                    lstOperaciones.Items.Add(resultadoDec.ToString().Trim());
                }
            }
        }
    }
}
