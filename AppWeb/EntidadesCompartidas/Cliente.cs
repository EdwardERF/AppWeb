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
            get { return _ci; }
            set { _ci = value; }
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
            get { return _telefono; }
            set { _telefono = value; }
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
    }
}
