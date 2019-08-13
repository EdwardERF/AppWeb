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
    }
}
