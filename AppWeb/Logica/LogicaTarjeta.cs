using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaTarjeta
    {
        public static void Alta(Tarjeta oTarjeta)
        {
            if (oTarjeta is Credito)
                PersistenciaCredito.Alta((Credito)oTarjeta);
            else if (oTarjeta is Debito)
                PersistenciaDebito.Alta((Debito)oTarjeta);
        }

        public static List<Tarjeta> TarjetasXCliente(int oCI)
        {
            List<Tarjeta> oLista = new List<Tarjeta>();

            oLista.AddRange(PersistenciaCredito.ListarXCliente(oCI));
            oLista.AddRange(PersistenciaDebito.ListarXCliente(oCI));

            return oLista;
        }

        public static List<Tarjeta> ListarVencidas()
        {
            List<Tarjeta> oLista = new List<Tarjeta>();

            oLista.AddRange(PersistenciaCredito.ListarVencidas());
            oLista.AddRange(PersistenciaDebito.ListarVencidas());

            return oLista;
        }

        public static List<Credito> ListarVencidasCredito()
        {
            List<Credito> oLista = new List<Credito>();

            oLista.AddRange(PersistenciaCredito.ListarVencidas());

            return oLista;
        }

        public static List<Debito> ListarVencidasDebito()
        {
            List<Debito> oLista = new List<Debito>();

            oLista.AddRange(PersistenciaDebito.ListarVencidas());

            return oLista;
        }
    }
}
