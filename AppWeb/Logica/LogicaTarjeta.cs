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
            else
                PersistenciaDebito.Alta((Debito)oTarjeta);
        }
    }
}
