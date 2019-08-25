using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using System.Data;
using System.Data.SqlClient;

namespace Persistencia
{
    public class PersistenciaCliente
    {
        public static void Alta(Cliente oCli)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("sp_AgregarCliente", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@ci", oCli.CI);
            oComando.Parameters.AddWithValue("@nombre", oCli.Nombre);
            oComando.Parameters.AddWithValue("@apellido", oCli.Apellido);

            SqlParameter oParametro = new SqlParameter("@Retorno", SqlDbType.Int);
            oParametro.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oParametro);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int oAfectados = (int)oComando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("Error SQL");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }
        }

        public static void Modificar(Cliente oCli)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("sp_ModificarCliente", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@ci", oCli.CI);
            oComando.Parameters.AddWithValue("@nombre", oCli.Nombre);
            oComando.Parameters.AddWithValue("@apellido", oCli.Apellido);
            oComando.Parameters.AddWithValue("@numTel", oCli.Telefono);

            SqlParameter oParametro = new SqlParameter("@Retorno", SqlDbType.Int);
            oParametro.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oParametro);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int ValReturn = (int)oComando.Parameters["@Retorno"].Value;

                if (ValReturn == -1)
                    throw new Exception("No existe cliente con esa CI");
                else if (ValReturn == -2)
                    throw new Exception("Error de transacción");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }
        }

        public static void Baja(Cliente oCli)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("sp_EliminarCliente", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@ci", oCli.CI);

            SqlParameter oParametro = new SqlParameter("@Retorno", SqlDbType.Int);
            oParametro.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oParametro);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int ValReturn = (int)oComando.Parameters["@Retorno"].Value;

                if (ValReturn == -3)
                    throw new Exception("Error de transacción");
                else if (ValReturn == -9)
                    throw new Exception("Error en transacción");
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }
        }

        public static List<Cliente> ListarCliente()
        {
            int oCI, oTelefono;
            string oNombre, oApellido;

            Cliente oCliente;

            List<Cliente> oListaClientes = new List<Cliente>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);

            SqlCommand oComando = new SqlCommand("sp_ListarClientes", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                while (oReader.Read())
                {
                    oCI = (int)oReader["ci"];
                    oNombre = (string)oReader["nombre"];
                    oApellido = (string)oReader["apellido"];
                    oTelefono = (int)oReader["numTel"];

                    oCliente = new Cliente(oCI, oNombre, oApellido, oTelefono);

                    oListaClientes.Add(oCliente);
                }

                oReader.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }

            return oListaClientes;
        }

        public static List<Cliente> ListarComprasXCliente()
        {
            Cliente oCli;
            List<Cliente> oListaCxC = new List<Cliente>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("sp_TotalComprasXCliente", oConexion);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        int CI = (int)oReader["ci"];
                        oCli = PersistenciaCliente.BuscarCliente(CI);

                        Cliente _Cli = new Cliente(CI, (string)oReader["nombre"], (string)oReader["apellido"], (int)oReader["numTel"]);

                        oListaCxC.Add(_Cli);
                    }

                    oReader.Close();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }

            return oListaCxC;
        }

        public static Cliente BuscarCliente(int pCI)
        {
            int oTelefono;
            string oNombre, oApellido;

            Cliente oCli = null;
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("sp_BuscarCliente", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@ci", pCI);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if(oReader.Read())
                {
                    oTelefono = (int)oReader["numTel"];
                    oNombre = (string)oReader["nombre"];
                    oApellido = (string)oReader["apellido"];
                    oCli = new Cliente(pCI, oNombre, oApellido, oTelefono);
                }

                oReader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }

            return oCli;
        }
    }
}
