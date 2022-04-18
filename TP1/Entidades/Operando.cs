using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        private double numero;

        public Operando()
        {
            this.numero = 0;
        }

        public Operando(double numero)
        {
            this.numero = numero;
        }

   
        public Operando(string strNumero)
        {
             this.Numero = strNumero;
        }

        /// <summary>
        /// Recibe un numero en formato "string" y valida que pueda ser parseado a "double".
        /// </summary>
        /// <param name="strNumero">(string)Numero a validar.</param>
        /// <returns>(double) 0 si tryParse fue "false" y el numero parseado si fue "true"</returns>
        private static double ValidarOperando(string strNumero)
        {
            double retornoAux = 0;

            if (double.TryParse(strNumero, out double numero))
            {
                retornoAux = numero;
            }

            return retornoAux;
        }
        /// <summary>
        /// Propiedad que asigna el valor del atributo (double)numero y instancia a al metodo "ValidarOperando".
        /// </summary>
        private string Numero
        {
            set
            {
                numero = ValidarOperando(value);
            }
        }

        
        /// <summary>
        /// Valida si todos los caracteres de un "string" son solo '0' o '1'.
        /// </summary>
        /// <param name="binario">(string)Numero a validar si es binario.</param>
        /// <returns>(bool)true si lo son y false si no.</returns>
        private static bool EsBinario(string binario)
        {
            foreach (char caracter in binario)
            {
                if (caracter != '0' && caracter != '1')
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Valida que la cadena pasada por parametro es un numero binario y si es posible, lo convierte a decimal.
        /// </summary>
        /// <param name="valorRecibido">(string)Cadena a validar y convertir a decimal si es posible.</param>
        /// <returns>(string)"Valor inválido." si la cadena no es un binario y el numero decimal si la conversion fue correcta.</returns>
        public string BinarioDecimal(string valorRecibido)
        {
            string retornoAux = "Valor inválido.";
            double resultado = 0;

            if (valorRecibido is not null && EsBinario(valorRecibido))
            {
                int cantidadCaracteres = valorRecibido.Length;
                foreach (char caracter in valorRecibido)
                {
                    cantidadCaracteres--;
                    if (caracter == '1')
                    {
                        resultado += (int)Math.Pow(2, cantidadCaracteres);
                    }
                }
                resultado = Math.Abs((double)resultado);
                retornoAux = resultado.ToString();
            }
            return retornoAux;
        }

        /// <summary>
        /// Recibe un (double)numero por parametro y si es posible lo convierte a binario.
        /// </summary>
        /// <param name="numero">(double)Numero a convertir a binario si es posible.</param>
        /// <returns>(string)"Valor inválido." si no se pudo realizar con conversion y el numero binario si la conversion fue correcta.</returns>
        public string DecimalBinario(double numero)
        {
            string retornoAux = "Valor inválido.";
            string valorBinario = string.Empty;
            numero = Math.Abs((double)numero);
            int resultadoDiv = (int)numero;
            int restoDiv;

            if (resultadoDiv >= 0)
            {
                do
                {
                    restoDiv = resultadoDiv % 2;
                    resultadoDiv /= 2;
                    valorBinario = restoDiv.ToString() + valorBinario;
                    retornoAux = valorBinario;
                } while (resultadoDiv > 0);
            }
            return retornoAux;
        }

        /// <summary>
        /// Recibe un (string)numero por parametro y si es posible lo convierte a binario.
        /// </summary>
        /// <param name="numero">(string)Numero a convertir a binario si es posible.</param>
        /// <returns>(string)"Valor inválido." si no se pudo realizar con conversion y el numero binario si la conversion fue correcta.</returns>
        public string DecimalBinario(string numero)
        {
            string retornoAux = "Valor inválido.";
            if (double.TryParse(numero, out double numeroParseado))
            {
                string valorBinario = DecimalBinario(numeroParseado);
                retornoAux = valorBinario;
            }
            return retornoAux;
        }


        /// <summary>
        /// Realiza la suma de los atributos numero de 2 objetos de la clase Operando.
        /// </summary>
        /// <param name="num1">(Operando)Objeto de la clase Operando.</param>
        /// <param name="num2">(Operando)Objeto de la clase Operando.</param>
        /// <returns>(double)Retorna el resultado de la operacion de los dos numeros.</returns>
        public static double operator +(Operando num1, Operando num2)
        {
            return num1.numero + num2.numero;
        }

        /// <summary>
        /// Realiza la resta de los atributos numero de 2 objetos de la clase Operando.
        /// </summary>
        /// <param name="num1">(Operando)Objeto de la clase Operando.</param>
        /// <param name="num2">(Operando)Objeto de la clase Operando.</param>
        /// <returns>(double)Retorna el resultado de la operacion de los dos numeros.</returns>
        public static double operator -(Operando num1, Operando num2)
        {
            return num1.numero - num2.numero;
        }

        /// <summary>
        /// Realiza la multiplicacion de los atributos numero de 2 objetos de la clase Operando.
        /// </summary>
        /// <param name="num1">(Operando)Objeto de la clase Operando.</param>
        /// <param name="num2">(Operando)Objeto de la clase Operando.</param>
        /// <returns>(double)Retorna el resultado de la operacion de los dos numeros.</returns>
        public static double operator *(Operando num1, Operando num2)
        {
            return num1.numero * num2.numero;
        }

        /// <summary>
        /// Realiza la division de los atributos numero de 2 objetos de la clase Operando y valida que el 2do numero no sea '0'.
        /// </summary>
        /// <param name="num1">(Operando)Objeto de la clase Operando.</param>
        /// <param name="num2">(Operando)Objeto de la clase Operando.</param>
        /// <returns>(double)Retorna el resultado de la operacion de los dos numeros si el 2do operando no era 0 y double.MinValue si lo era.</returns>
        public static double operator /(Operando num1, Operando num2)
        {
            if (num2.numero != 0)
            {
                return num1.numero / num2.numero;
            }
            return double.MinValue;
        }
    }
}
