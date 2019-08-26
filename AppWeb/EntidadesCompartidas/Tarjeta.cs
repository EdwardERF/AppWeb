using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
    public abstract class Tarjeta
    {
        //De las Tarjetas se conoce:
        //Cedula de la cual dependen
        //NroTarjeta (pero es PK en la BD) esto hay que verlo bien -- Deducción: no se pregunta al cliente, se crea automáticamente.
        //--Aca igual hay un tema. Por ejemplo, para agregar una tarjeta, esta bien, no se pide NroTarjeta, porque se crea automático en la BD. 
        //--Pero luego, al modificar una Tarjeta, se tiene que saber el NroTarjeta, lo mismo para eliminarla. Cómo se accede a ella?
        //--En un principio, haré el atributo NroTarjeta, pero luego tengo que reverlo a ver si esta bien. 
        //FechaVencimiento
        //Personalizada (si o no)

        //Atributos
        private int _ci;
        private int _NroTarjeta;
        private DateTime _FechaVencimiento;
        private int _Personalizada;

        //Propiedades
        public int CI
        {
            get { return _ci; }
            set { _ci = value; }
        }

        public int NroTarjeta
        {
            get { return _NroTarjeta; }
            set { _NroTarjeta = value; }
        }

        public DateTime FechaVencimiento
        {
            get { return _FechaVencimiento; }
            set { _FechaVencimiento = value; }
        }

        public int Personalizada
        {
            get { return _Personalizada; }
            set { _Personalizada = value; }
        }

        //Constructores
        public Tarjeta(int pCI, int pNroTarjeta, DateTime pFechaVencimiento, int pPersonalizada)
        {
            CI = pCI;
            NroTarjeta = pNroTarjeta;
            FechaVencimiento = pFechaVencimiento;
            Personalizada = pPersonalizada;
        }

        //Constructor sin Identity
        public Tarjeta(int pCI, DateTime pFechaVencimiento, int pPersonalizada)
        {
            CI = pCI;
            FechaVencimiento = pFechaVencimiento;
            Personalizada = pPersonalizada;
        }

        //Operaciones
        public override string ToString()
        {
            return "CI: " + CI + " - Numero Tarjeta: " + NroTarjeta + " - Fecha de Vencimiento: " + FechaVencimiento + " - Personalizada: " + Personalizada;
        }
    }
}
