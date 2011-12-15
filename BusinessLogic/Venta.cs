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

        public Persona CreatePersona(string pasaporte, string nombre, string apellidos)
        {
            // Check if person already exist
            if (FindPersona(pasaporte) != null)
                return null;

            Persona _persona = new Persona();
            _persona.Pasaporte = pasaporte;
            _persona.NombrePersona = nombre;
            _persona.ApellidosPersona = apellidos;
            DALCliente.CreatePersona(_persona);
            Persona = _persona;
            return _persona;
        }

        public void CreateReservacion()
        {
            if (vuelo_ida == null)
            {
                throw new Exception("Debe seleccionar un vuelo de ida");
            }
            else
            {
                if (asiento_ida == null)
                    throw new Exception("Debe seleccionar un vuelo de ida");
            }

            // Determinar si se va a reservar un vuelo de vuelta
            bool reservar_vuelta = false;
            if (vuelo_vuelta != null)
            {
                reservar_vuelta = true;
                // Si hay un vuelo seleccionado, pero no hay asiento seleccionado, tirar un error
                if (asiento_vuelta == null)
                    throw new Exception("Si hay un vuelo de vuelta seleccionado, un asiento debe ser asignado para este vuelo");
            }

            try
            {
                reservacion_ida = new TransReservacion(Persona, vuelo_ida, asiento_ida, (TransUsuario)LUser.GetInstance().d_usuario);
                DALCliente.Create(reservacion_ida.PersistentObject);

                if (reservar_vuelta)
                {
                    reservacion_vuelta = new TransReservacion(Persona, vuelo_vuelta, asiento_vuelta, (TransUsuario)LUser.GetInstance().d_usuario);
                    DALCliente.Create(reservacion_ida.PersistentObject);
                }
            }
            catch (Exception e)
            {
                throw e;
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


        public List<Persona> FindPersona(string nombre, string apellido)
        {
            return DALCliente.GetPersonasFromApellidoAndNombre(nombre, apellido);
        }

        public Persona FindPersona(string pasaporte)
        {
            return DALCliente.GetPersonaFromPasaporte(pasaporte);
        }
    }
}
