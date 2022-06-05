using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Cliente
    {
        private string nombre;
        private string apellido;
        private int edad;
        private int dni;
        private ETipoPlanGimnasio planGimnasio;

        public Cliente()
        {
        }

        public Cliente(string nombre, string apellido, int edad, int dni, ETipoPlanGimnasio planGimnasio)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Edad = edad;
            this.Dni = dni;
            this.PlanGimnasio = planGimnasio;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public int Edad { get => edad; set => edad = value; }
        public int Dni { get => dni; set => dni = value; }
        public ETipoPlanGimnasio PlanGimnasio { get => planGimnasio; set => planGimnasio = value; } 

        /// <summary>
        /// Compara si dos clientes son iguales por dni.
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns>(bool)resultado de la comparacion de los dni o (bool)false si los parametros son null</returns>
        public static bool operator ==(Cliente c1, Cliente c2)
        {
            if (c1 is not null && c2 is not null)
            {
                return c1.Dni == c2.Dni;
            }

            return false;
        }

        /// <summary>
        /// Compara si dos clientes son distintos por dni.
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns>(bool)true si son distintos o (bool)false si son iguales.</returns>
        public static bool operator !=(Cliente c1, Cliente c2)
        {
            return !(c1 == c2);
        }

        /// <summary>
        /// Genera un string que muestra todos los atributos de un cliente.
        /// </summary>
        /// <returns>(string)datos del cliente.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Nombre: {this.nombre}");
            sb.AppendLine($"Apellido: {this.apellido}");
            sb.AppendLine($"DNI: {this.dni}");
            sb.AppendLine($"Edad: {this.edad}");
            sb.AppendLine($"Plan Gimnasio: {this.planGimnasio}");

            return sb.ToString();
        }

        /// <summary>
        /// Genera un string con formato de una credencial que otorga el gimnasio por ser miembro.
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns>(string)la credencial.</returns>
        public static string GenerarCredencialCliente(Cliente cliente)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Credencial Gimnasio");
            sb.AppendLine("---------------------");
            sb.AppendLine($"{cliente.Nombre + " " + cliente.Apellido}");
            sb.AppendLine($"DNI: {cliente.Dni}");
            sb.AppendLine($"Plan: {cliente.PlanGimnasio}");
            sb.AppendLine($"---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Compara dos clientes y verifica que sea del tipo (Cliente).
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>(bool)true si son iguales o (bool)false si son distintos.</returns>
        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(Cliente))
            {
                return this == (Cliente)obj;
            }

            return false;
        }

        /// <summary>
        /// Valida los atributos del cliente.
        /// </summary>
        /// <param name="nombreStr"></param>
        /// <param name="apellidoStr"></param>
        /// <param name="edad"></param>
        /// <param name="dniStr"></param>
        /// <param name="planGimnasio"></param>
        /// <returns>(Cliente)cliente instanciado con los atributos validados.</returns>
        public static Cliente ValidarDatosCliente(string nombreStr, string apellidoStr, decimal edad, string dniStr, int planGimnasio)
        {
            if (Validaciones.ValidarDni(dniStr, out int dni) && Validaciones.ValidarString(nombreStr, out string nombre) && Validaciones.ValidarString(apellidoStr, out string apellido) && edad >= 11 && edad <= 125 && planGimnasio >= 0 && planGimnasio <= 2)
            {
                ETipoPlanGimnasio plan = (ETipoPlanGimnasio)planGimnasio;

                return new Cliente(nombre, apellido, (int)edad, dni, plan);
            }

            return null;
        }

    }
}
