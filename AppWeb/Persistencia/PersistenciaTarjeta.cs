using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using System.Data;
using System.Data.SqlClient;

namespace Persistencia
{
    class PersistenciaTarjeta
    {
        public static Tarjeta Buscar(int oCI)
        {
            Tarjeta oTarj = null;
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("sp_BuscarTarjeta" + oCI, oConexion);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();




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
    }
}
