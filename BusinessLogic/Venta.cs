using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer;

namespace BusinessLogic
{
    public class Venta
    {
        public Venta()
        {
        }

        Persona persona;
        private TransReservacion reservacion_ida;
        private TransReservacion reservacion_vuelta;
        private TransVuelo vuelo_ida;
        private TransVuelo vuelo_vuelta;

        public TransReservacion ReservacionIda
        {
            get { return reservacion_ida; }
        }

        public TransReservacion ReservacionVuelta
        {
            get { return reservacion_vuelta; }
        }

        public TransVuelo VueloIda
        {
            get { return vuelo_ida; }
            set { vuelo_ida = value; }
        }

        public TransVuelo VueloVuelta
        {
            get { return vuelo_vuelta; }
            set { vuelo_vuelta = value; }
        }

        public Persona Persona
        {
            get { return persona; }
            set { persona = value; }
        }

        public bool SetPersona(string pasaporte)
        {
            persona = DALCliente.GetPersonaFromPasaporte(pasaporte);
            
            if (persona != null)
                return true;
            else
                return false;
        }

        public List<Persona> FindPersona(string nombre, string apellido)
        {
            return DALCliente.GetPersonasFromApellidoAndNombre(nombre, apellido);
        }
    }
}
