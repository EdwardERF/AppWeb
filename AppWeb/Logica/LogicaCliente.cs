using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaCliente
    {
        public static void Alta(Cliente oCli)
        {
            PersistenciaCliente.Alta(oCli);
        }

        public static void Modificar(Cliente oCli)
        {
            PersistenciaCliente.Modificar(oCli);
        }

        public static List<Cliente> ListarClientes()
        {
            return PersistenciaCliente.ListarCliente();
        }

        public static List<Cliente> ListarComprasXCliente()
        {
            return PersistenciaCliente.ListarComprasXCliente();
        }

        public static Cliente BuscarCliente(int pCI)
        {
            Cliente oCli = PersistenciaCliente.BuscarCliente(pCI);
            return oCli;
        }
    }
}
