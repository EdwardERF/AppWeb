﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using System.Data;
using System.Data.SqlClient;

namespace Persistencia
{
    public class PersistenciaDebito
    {
        public static void Alta(Debito oDebito)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("sp_AgregarTarjetaDebito", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@ci", oDebito.CI);
            oComando.Parameters.AddWithValue("@fechaVencimiento", oDebito.FechaVencimiento);
            oComando.Parameters.AddWithValue("@pers", oDebito.Personalizada);
            oComando.Parameters.AddWithValue("@CantCuentAsoc", oDebito.CuentasAsociadas);
            oComando.Parameters.AddWithValue("@saldo", oDebito.Saldo);

            SqlParameter oParametro = new SqlParameter("@Retorno", SqlDbType.Int);
            oParametro.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oParametro);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int ValReturn = (int)oComando.Parameters["@Retorno"].Value;

                if (ValReturn == -1)
                    throw new Exception("No existe cliente");
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
    }
}
