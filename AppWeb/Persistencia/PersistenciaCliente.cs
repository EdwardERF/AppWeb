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
        public static List<Cliente> ListarCliente()
        {
            int oCI, oTelefono;
            string oNombre, oApellido;

            Cliente oCliente;

            List<Cliente> oListaClientes = new List<Cliente>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);

            SqlCommand oComando = new SqlCommand("SPListarClientes", oConexion);
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

        public static Cliente BuscarCliente(int pCI)
        {
            int oTelefono;
            string oNombre, oApellido;

            Cliente oCli = null;
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("exec BuscarCliente " + pCI, oConexion);

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
