using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
    public class Credito : Tarjeta
    {
        //De credito se conoce:
        //Categoria (son 4)
        //Credito disponible

        //Atributos
        private int _Categoria;
        private int _CreditoDisponible;

        //Propiedades
        public int Categoria
        {
            get { return _Categoria; }
            set { _Categoria = value; }
        }

        public int CreditoDisponible
        {
            get { return _CreditoDisponible; }
            set { _CreditoDisponible = value; }
        }

        //Constructor sin Identity para crear
        public Credito(int pNroTarjeta, DateTime pFechaVencimiento, int pPersonalizada, int pCategoria, int pCreditoDisponible)
            : base(pNroTarjeta, pFechaVencimiento, pPersonalizada)
        {
            Categoria = pCategoria;
            CreditoDisponible = pCreditoDisponible;
        }

        //Constructor para consultas
        public Credito(int pCI, int pNroTarjeta, DateTime pFechaVencimiento, int pPersonalizada, int pCategoria, int pCreditoDisponible)
            : base(pCI, pNroTarjeta, pFechaVencimiento, pPersonalizada)
        {
            Categoria = pCategoria;
            CreditoDisponible = pCreditoDisponible;
        }

        //Operaciones
        public override string ToString()
        {
            return "Credito: " + base.ToString() + " - Categoria: " + Categoria + " - Credito Disponible: " + CreditoDisponible;
        }
    }
}
