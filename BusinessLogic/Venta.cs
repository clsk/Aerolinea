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

        public Venta(TransReservacion reserva_ida, TransReservacion reserva_vuelta)
        {
            reservacion_ida = reserva_ida;
            VueloIda = reservacion_ida.Vuelo;
            AsientoIda = reservacion_ida.Asiento;
            if (reserva_vuelta != null)
            {
                reservacion_vuelta = reserva_vuelta;
                VueloVuelta = reservacion_vuelta.Vuelo;
                AsientoVuelta = reservacion_vuelta.Asiento;
            }

            persona = reservacion_ida.Persona;
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

        /// <summary>
        /// Modifica las reservaciones
        /// </summary>
        public void UpdateReservacion()
        {
            CreateReservacion(true);
        }

        /// <summary>
        /// Crea las reservaciones de Ida y Vuelta (si esta definida)
        /// </summary>
        /// <param name="modificando">Especifica si se esta modificando una reservacion, o es una nueva reservacion</param>
        public void CreateReservacion(bool modificando = false)
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
                if (modificando)
                {
                    reservacion_ida.Persona = persona;
                    reservacion_ida.Vuelo = vuelo_ida;
                    reservacion_ida.Asiento = asiento_ida;
                    reservacion_ida.Flush();
                }
                else
                {
                    reservacion_ida = new TransReservacion(Persona, vuelo_ida, asiento_ida, (TransUsuario)LUser.GetInstance().d_usuario);
                    reservacion_ida.Create();
                }

                if (reservar_vuelta)
                {
                    if (reservacion_vuelta == null)
                    {
                        reservacion_vuelta = new TransReservacion(Persona, vuelo_vuelta, asiento_vuelta, (TransUsuario)LUser.GetInstance().d_usuario);
                        reservacion_vuelta.Create();
                    }
                    else
                    {
                        reservacion_vuelta.Persona = persona;
                        reservacion_vuelta.Vuelo = vuelo_vuelta;
                        reservacion_vuelta.Asiento = asiento_vuelta;
                        reservacion_vuelta.Flush();
                    }
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
