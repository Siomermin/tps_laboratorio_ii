using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Gimnasio
    {
        private static List<Cliente> listaClientes;

        static Gimnasio()
        {
            listaClientes = new List<Cliente>();
        }

        public static List<Cliente> ListaClientes { get => listaClientes; set => listaClientes = value; }

        
        /// <summary>
        /// Valida si el cliente ya se encuentra en el gimnasio, si no esta, se lo agrega a la lista de clientes.
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns>(bool)false si el cliente ya estaba en el gimnasio o (bool)true si se lo agrego correctamente.</returns>
        public static bool AgregarCliente(Cliente cliente)
        {
            if (Gimnasio.ValidarClienteExistente(cliente) == false)
            {
                Gimnasio.ListaClientes.Add(cliente);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Valida si el cliente se encuentra en el gimnasio, si esta, se lo elimina de la lista.
        /// </summary>
        /// <param name="cliente"></param>
        public static bool EliminarCliente(Cliente cliente)
        {
            if (Gimnasio.ValidarClienteExistente(cliente))
            {
                Gimnasio.ListaClientes.Remove(cliente);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Valida si el cliente se encuentra en el gimnasio.
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns>(bool)true si se encuentra o (bool)false si no se encuentra.</returns>
        public static bool ValidarClienteExistente(Cliente cliente)
        {
            if (Gimnasio.ListaClientes.Count > 0 && cliente is not null)
            {
                foreach (Cliente item in Gimnasio.ListaClientes)
                {
                    if (item.Equals(cliente))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

    }
}
