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
            set {
                if ((_Categoria > 0) && (_Categoria < 5))
                    _Categoria = value;
                else
                    throw new Exception("Las categorias disponibles son: 1, 2, 3 o 4");
                }
            get { return _Categoria; }
        }

        public int CreditoDisponible
        {
            set {
                if (_CreditoDisponible >= 0)
                    _CreditoDisponible = value;
                else
                    throw new Exception("El credito disponible debe ser mayor o igual a 0");
                }
            get { return _CreditoDisponible; }
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
