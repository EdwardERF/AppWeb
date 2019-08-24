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
        public static List<Compra> ListarCompras()
        {
            return PersistenciaCompra.ListarCompras();
        }

        public static List<Compra> ListarComprasXCliente(int oCI)
        {
            return PersistenciaCompra.ListarComprasXCliente(oCI);
        }

        public static void Alta(Compra oCompra)
        {
            PersistenciaCompra.Alta(oCompra);
        }
    }
}
