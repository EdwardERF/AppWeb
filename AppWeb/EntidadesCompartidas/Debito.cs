using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
    public class Debito : Tarjeta
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
            set {
                if (_Saldo >= 0)
                    _Saldo = value;
                else
                    throw new Exception("El saldo disponible debe ser mayor o igual a 0");
                }
            get { return _Saldo; }
        }

        public int CuentasAsociadas
        {
            get { return _CuentasAsociadas; }
            set { _CuentasAsociadas = value; }
        }

        //Constructor sin Identity para crear
        public Debito(int pNroTarjeta, DateTime pFechaVencimiento, int pPersonalizada, int pSaldo, int pCuentasAsociadas)
            : base(pNroTarjeta, pFechaVencimiento, pPersonalizada)
        {
            Saldo = pSaldo;
            CuentasAsociadas = pCuentasAsociadas;
        }

        //Constructor para consultas
        public Debito(int pCI, int pNroTarjeta, DateTime pFechaVencimiento, int pPersonalizada, int pSaldo, int pCuentasAsociadas)
            : base(pCI, pNroTarjeta, pFechaVencimiento, pPersonalizada)
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
