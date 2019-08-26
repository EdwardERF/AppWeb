using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using System.Data;
using System.Data.SqlClient;

namespace Persistencia
{
    public class PersistenciaCredito
    {
        public static void Alta(Credito oCredito)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("sp_AgregarTarjetaCredito", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@ci", oCredito.CI);
            oComando.Parameters.AddWithValue("@fechaVencimiento", oCredito.FechaVencimiento);
            oComando.Parameters.AddWithValue("@pers", oCredito.Personalizada);
            oComando.Parameters.AddWithValue("@cat", oCredito.Categoria);
            oComando.Parameters.AddWithValue("@credito", oCredito.CreditoDisponible);

            SqlParameter oParametro = new SqlParameter("@Retorno", SqlDbType.Int);
            oParametro.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oParametro);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int ValReturn = (int)oComando.Parameters["@Retorno"].Value;

                if (ValReturn == -1)
                    throw new Exception("No existe el cliente");
                else if (ValReturn == -2)
                    throw new Exception("Error SQL");
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

        public static List<Credito> ListarXCliente(int oCI)
        {
            List<Credito> oLista = new List<Credito>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("sp_CreditoXCliente", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@ci", oCI);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        Credito oCredito = new Credito(Convert.ToInt32(oReader["NroTarj"]), Convert.ToDateTime(oReader["fechaVencimiento"]),
                            Convert.ToInt32(oReader["pers"]), Convert.ToInt32(oReader["cat"]), Convert.ToInt32(oReader["credito"]));

                        oLista.Add(oCredito);
                    }
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

            return oLista;
        }

        public static List<Credito> ListarVencidas()
        {
            List<Credito> oLista = new List<Credito>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("sp_CreditoVencidas", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        Credito oCredito = new Credito(Convert.ToInt32(oReader["NroTarj"]), Convert.ToDateTime(oReader["fechaVencimiento"]),
                            Convert.ToInt32(oReader["pers"]), Convert.ToInt32(oReader["cat"]), Convert.ToInt32(oReader["credito"]));

                        oLista.Add(oCredito);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }

            return oLista;
        }
    }
}
