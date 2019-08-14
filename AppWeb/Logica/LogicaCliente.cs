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
        public static List<Cliente> ListarClientes()
        {
            return PersistenciaCliente.ListarCliente();
        }

        public static Cliente BuscarCliente(int pCI)
        {
            Cliente oCli = PersistenciaCliente.BuscarCliente(pCI);
            return oCli;
        }
    }
}
