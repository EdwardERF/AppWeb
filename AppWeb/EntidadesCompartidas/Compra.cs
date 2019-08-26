﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
    public class Compra
    {
        //De compra se conoce:
        //NroCompra autogenerado
        //NroTarjeta
        //ImporteCompra
        //FechaCompra

        //Atributos
        private int _NroCompra;
        private int _NroTarjeta;
        private int _ImporteCompra;
        private DateTime _FechaCompra;

        //Propiedades
        public int NroCompra
        {
            get { return _NroCompra; }
            set { _NroCompra = value; }
        }

        public int NroTarjeta
        {
            get { return _NroTarjeta; }
            set { _NroTarjeta = value; }
        }

        public int ImporteCompra
        {
            set {
                if (_ImporteCompra > 0)
                    _ImporteCompra = value;
                else
                    throw new Exception("La compra debe tener un valor");
                   
                }
            get { return _ImporteCompra; }
        }

        public DateTime FechaCompra
        {
            set {
                if (_FechaCompra != null)
                    _FechaCompra = value;
                else
                    throw new Exception("Le ha faltado ingresar una fecha");
                }
            get { return _FechaCompra; }
        }

        //Constructor
        public Compra(int pNroCompra, int pNroTarjeta, int pImporteCompra, DateTime pFechaCompra)
        {
            NroCompra = pNroCompra;
            NroTarjeta = pNroTarjeta;
            ImporteCompra = pImporteCompra;
            FechaCompra = pFechaCompra;
        }

        //Constructor sin Identity
        public Compra(int pNroTarjeta, int pImporteCompra, DateTime pFechaCompra)
        {
            NroTarjeta = pNroTarjeta;
            ImporteCompra = pImporteCompra;
            FechaCompra = pFechaCompra;
        }

        //Operaciones
        public override string ToString()
        {
            return "Numero de Compra: " + NroCompra + " - Numero de Tarjeta utilizada: " + NroTarjeta + " - Importe de la Compra: " + ImporteCompra + " - Fecha de la Compra: " + FechaCompra;
        }
    }
}
