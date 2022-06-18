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
            cadenaConexion = @"Server = DESKTOP-32NSFFC; Database = GIMNASIO_DB; Trusted_Connection = True;";
            comando = new SqlCommand();
            conexion = new SqlConnection(cadenaConexion);
            comando.Connection = conexion;
            comando.CommandType = System.Data.CommandType.Text;
        }
        public static bool Guardar(Cliente cliente)
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

        public static async Task<List<Cliente>> LeerAsync()
        {
            List<Cliente> listaClientes = await Task.Run(Leer);

            if (listaClientes.Count < 0)
            {
                throw new Exception("No se encontraron clientes en la base de datos!");
            }

            return listaClientes;
        }

        public static List<Cliente> Leer()
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
            catch (Exception ex)
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

        public static bool Modificar(Cliente cliente)
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

        public static bool Eliminar(int dni)
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
