using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using Entidades;

namespace DAO
{
    public static class ClienteDAO
    {
        static string cadenaConexion;
        static SqlCommand comando;
        static SqlConnection conexion;
        static SqlDataReader lector;

        static ClienteDAO()
        {
            cadenaConexion = @"Server = DESKTOP-32NSFFC; Database = GIMNASIO; Trusted_Connection = True;";
            comando = new SqlCommand();
            conexion = new SqlConnection(cadenaConexion);
            comando.Connection = conexion;
            comando.CommandType = System.Data.CommandType.Text;
        }
        /// <summary>
        /// Guarda el cliente en la base de datos especificada en la cadena de conexion.
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns>(bool)true si funciono o (bool)false si no.</returns>
        public static bool GuardarCliente(Cliente cliente)
        {
            bool rta = true;

            try
            {
                comando.Parameters.Clear();
                conexion.Open();
                comando.CommandText = "INSERT INTO Clientes (NOMBRE,APELLIDO,EDAD,DNI,PLAN_GIMNASIO) VALUES (@nombre,@apellido,@edad,@dni,@plan_gimnasio)";
                comando.Parameters.AddWithValue("@nombre", cliente.Nombre);
                comando.Parameters.AddWithValue("@apellido", cliente.Apellido);
                comando.Parameters.AddWithValue("@edad", cliente.Edad);
                comando.Parameters.AddWithValue("@dni", cliente.Dni);
                comando.Parameters.AddWithValue("@plan_gimnasio", cliente.PlanGimnasio);

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                rta = false;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            return rta;
        }

        /// <summary>
        /// Invoca al metodo Leer para leer los clientes de la database de forma asincronica.
        /// </summary>
        /// <returns>(ask<List<Cliente>>) una operacion asincronica con una lista de clientes.</returns>
        public static async Task<List<Cliente>> LeerClientesAsync()
        {
            try
            {
                List<Cliente> listaClientes = await Task.Run(LeerClientes);

                if (listaClientes.Count < 0)
                {
                    throw new Exception("No se encontraron clientes en la base de datos!");
                }

                return listaClientes;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Lee todos los clientes desde la base de datos especificada.
        /// </summary>
        /// <returns>List<Cliente> lista con los clientes cargados. </returns>
        public static List<Cliente> LeerClientes()
        {
            List<Cliente> listaClientes = new List<Cliente>();

            try
            {
                comando.CommandText = "SELECT * FROM Clientes";

                conexion.Open();

                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Cliente cliente = Cliente.ValidarDatosCliente(lector.GetString(0), lector.GetString(1), lector.GetInt32(2), lector.GetInt32(3).ToString(), lector.GetInt32(4));

                    listaClientes.Add(cliente);
                }

                lector.Close();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            return listaClientes;
        }

        /// <summary>
        /// Modifica datos de un cliente en la base de datos utilizando como llave primaria al DNI.
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns>(bool)true si funciono o (bool)false si no.</returns>
        public static bool ModificarCliente(Cliente cliente)
        {
            bool rta = true;

            try
            {
                comando = new SqlCommand();

                comando.Parameters.AddWithValue("@nombre", cliente.Nombre);
                comando.Parameters.AddWithValue("@apellido", cliente.Apellido);
                comando.Parameters.AddWithValue("@edad", cliente.Edad);
                comando.Parameters.AddWithValue("@dni", cliente.Dni);
                comando.Parameters.AddWithValue("@plan_gimnasio", cliente.PlanGimnasio);


                string sql = "UPDATE Clientes ";
                sql += "SET NOMBRE = @nombre, APELLIDO = @apellido, EDAD = @edad, PLAN_GIMNASIO = @plan_gimnasio ";
                sql += "WHERE DNI = @dni";

                comando.CommandText = sql;
                comando.CommandType = CommandType.Text;
                comando.Connection = conexion;

                conexion.Open();

                int filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    rta = false;
                }

            }
            catch (Exception)
            {
                rta = false;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            return rta;
        }

        /// <summary>
        /// Elimina a un cliente de la base de datos utlizando su DNI como clave primaria.
        /// </summary>
        /// <param name="dni"></param>
        /// <returns>(bool)true si funciono o (bool)false si no.</returns>
        public static bool EliminarCliente(int dni)
        {
            bool rta = true;

            try
            {
                comando = new SqlCommand();

                comando.Parameters.AddWithValue("@dni", dni);

                string sql = "DELETE FROM Clientes ";
                sql += "WHERE DNI = @dni";

                comando.CommandText = sql;
                comando.CommandType = CommandType.Text;
                comando.Connection = conexion;

                conexion.Open();

                int filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    rta = false;
                }

            }
            catch (Exception)
            {
                rta = false;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            return rta;
        }
    }
}
