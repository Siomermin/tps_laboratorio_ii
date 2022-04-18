using System;

namespace Entidades
{
    public static class Calculadora
    {

        /// <summary>
        /// Valida que el operador ingresado sea '-', '/' , '*'. Caso contrario retorna '+'.
        /// </summary>
        /// <param name="operador">(char)Operador a validar.</param>
        /// <returns>(char)el operador ingresado.</returns>
        private static char ValidarOperador(char operador)
        {
            switch (operador)
            {
                case '-':
                    return '-';

                case '*':
                    return '*';

                case '/':
                    return '/';

                default:
                    return '+';
            }
        }

        /// <summary>
        /// Segun el operador que el usuario haya ingresado, se realizara la operacion correspondiente.
        /// </summary>
        /// <param name="num1">(Operando)Objeto de la clase Operando.</param>
        /// <param name="num2">(Operando)Objeto de la clase Operando.</param>
        /// <param name="operador">(char)Operador a validar con el que se va a realizar la operacion.</param>
        /// <returns>(double) 0 si los parametros fueron "null" o el resultado de la operacion si funciono.</returns>
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            double resultado = 0;
            if (num1 is not null && num2 is not null)
            {
                operador = ValidarOperador(operador);
                switch (operador)
                {
                    case '+':
                        resultado = num1 + num2;
                        break;

                    case '-':
                        resultado = num1 - num2;
                        break;

                    case '/':
                        resultado = num1 / num2;
                        break;

                    case '*':
                        resultado = num1 * num2;
                        break;
                }
            }
            return resultado;
        }
    }
}
