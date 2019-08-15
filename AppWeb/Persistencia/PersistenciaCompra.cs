using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using System.Data;
using System.Data.SqlClient;

namespace Persistencia
{
    public class PersistenciaCompra
    {
        public static Compra BuscarCompra(int pCI)
        {
            int oNroCompra, oNroTarjeta, oImporteCompra;
            DateTime oFechaCompra;

            Compra oCom = null;
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ex SPBuscarCompra" + pCI, oConexion);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if(oReader.Read())
                {
                    oNroCompra = (int)oReader["NroCompra"];
                    oNroTarjeta = (int)oReader["NroTarj"];
                    oImporteCompra = (int)oReader["ImporteCompra"];
                    oFechaCompra = (DateTime)oReader["FechaCompra"];
                    oCom = new Compra(oNroCompra, oNroTarjeta, oImporteCompra, oFechaCompra); 
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

            return oCom;
        }

        public static List<Compra> ListarCompras(int pCI)
        {
            Compra oCom;
            List<Compra> oListaCompras = new List<Compra>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("SP ListarCompras " + pCI, oConexion);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if(oReader.HasRows)
                {
                    while(oReader.Read())
                    {
                        oCom = new Compra((int)oReader["NroCompra"], (int)oReader["NroTarj"], (int)oReader["ImporteCompra"], (DateTime)oReader["FechaCompra"]);

                        oListaCompras.Add(oCom);
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

            return oListaCompras;
        }
    }
}
