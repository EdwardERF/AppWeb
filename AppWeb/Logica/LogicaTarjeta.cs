using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    class LogicaTarjeta
    {
        public static Tarjeta Buscar(int oCI)
        {
            return (PersistenciaTarjeta.Buscar(oCI));
        }
    }
}
