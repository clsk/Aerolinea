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
        private TransAsiento asiento_ida;
        private TransAsiento asiento_vuelta;



        public bool CreateReservacion()
        {
            try
            {
                TransReservacion reservacion_ida = new TransReservacion(Persona, vuelo_ida, asiento_ida, (TransUsuario)LUser.GetInstance().d_usuario);
                DALCliente.Create(reservacion_ida.PersistentObject);



                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public TransAsiento AsientoIda
        {
            get { return asiento_ida; }
            set { asiento_ida = value; }
        }

        public TransAsiento AsientoVuelta
        {
            get { return asiento_vuelta; }
            set { asiento_vuelta = value; }
        }


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
