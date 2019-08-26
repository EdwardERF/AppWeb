using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
    public class Cliente
    {
        //De los clientes se conoce: 
        //CI
        //nombre
        //apellido
        //sus telefonos
        //no se si va aca, pero tiene tarjeta/s a su nombre

        //Atributos
        private int _ci;
        private string _nombre;
        private string _apellido;
        private int _telefono;

        private Cliente _cli;

        //Propiedades
        public int CI
        {
            set {
                if ((value > 9999999) && (value < 100000000))
                    _ci = value;
                else
                    throw new Exception("Rango de CI Invalido - Debe tener 8 digitos");
                }
            get { return _ci; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }

        public int Telefono
        {
            set {
                if ((value > 5) && (value < 20))
                    _telefono = value;
                else
                    throw new Exception("Telefono debe tener entre 5-20 numeros");
                }
            get { return _telefono; }
        }

        public Cliente Cli
        {
            get { return _cli; }
            set { _cli = value; }
        }

        //Constructor
        public Cliente(int pCI, string pNombre, string pApellido, int pTelefono, Cliente pCli)
        {
            CI = pCI;
            Nombre = pNombre;
            Apellido = pApellido;
            Telefono = pTelefono;
            Cli = pCli;
        }

        public Cliente(int pCI, string pNombre, string pApellido, int pTelefono)
        {
            CI = pCI;
            Nombre = pNombre;
            Apellido = pApellido;
            Telefono = pTelefono;
        }

        //Operaciones
        public override string ToString()
        {
            return "CI: " + CI + " - Nombre: " + Nombre + " - Apellido: " + Apellido + " - Telefono: " + Telefono;
        }
    }
}
