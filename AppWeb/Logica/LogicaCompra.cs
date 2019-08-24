using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaCompra
    {
        public static List<Compra> ListarCompras(int pCI)
        {
            return PersistenciaCompra.ListarCompras(pCI);
        }

        public static void Alta(Compra oCompra)
        {
            PersistenciaCompra.Alta(oCompra);
        }
    }
}
