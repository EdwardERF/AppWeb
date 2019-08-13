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
        public static void ListarCliente()
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


        }
    }
}
