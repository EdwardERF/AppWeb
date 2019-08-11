using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
    class Debito : Tarjeta
    {
        //De debito se conoce:
        //Saldo
        //CantidadCuentasAsociadas?? No lo pide en la letra, pero lo dejo aca, porque si esta en la BD (MER)

        //Atributos
        private int _Saldo;
        private int _CuentasAsociadas;

        //Propiedades
        public int Saldo
        {
            get { return _Saldo; }
            set { _Saldo = value; }
        }

        public int CuentasAsociadas
        {
            get { return _CuentasAsociadas; }
            set { _CuentasAsociadas = value; }
        }

        //Constructor
        public Debito(int pNroTarjeta, DateTime pFechaVencimiento, bool pPersonalizada, int pSaldo, int pCuentasAsociadas)
            : base(pNroTarjeta, pFechaVencimiento, pPersonalizada)
        {
            Saldo = pSaldo;
            CuentasAsociadas = pCuentasAsociadas;
        }

        //Operaciones
        public override string ToString()
        {
            return "Debito: " + base.ToString() + " - Saldo: " + Saldo + " - Cuentas Asociadas: " + CuentasAsociadas;
        }
    }
}
