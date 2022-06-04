using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Validaciones
    {
        /// <summary>
        /// Valida que el dni del cliente tenga 8 numeros y sea parseable al tipo int.
        /// </summary>
        /// <param name="numeroTexto"></param>
        /// <param name="dni"></param>
        /// <returns>(bool)resultado del TryParse o false si no es de 8 digitos.</returns>
        public static bool ValidarDni(string numeroTexto, out int dni)
        {
            dni = 0;

            if (numeroTexto.Length == 8)
            {
                return int.TryParse(numeroTexto, out dni);
            }

            return false;
        }

        /// <summary>
        /// Valida que los textos sean solo letras y que no sean nulos o vacios.
        /// </summary>
        /// <param name="textoString"></param>
        /// <param name="textoValidado"></param>
        /// <returns></returns>
        public static bool ValidarString(string textoString, out string textoValidado)
        {
            textoValidado = string.Empty;

            if (string.IsNullOrEmpty(textoString.Trim()))
            {
                return false;
            }

            foreach (char caracter in textoString)
            {
                if (char.IsLetter(caracter) == false)
                {
                    return false;
                }
            }

            textoValidado = textoString;
            return true;
        }
    }
}
