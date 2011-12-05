using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBaseConnection
{
    public class TransReservacion : IReservacion
    {
        Reservacion persReservacion;

        internal TransReservacion(Reservacion persistent)
        {
            persReservacion = persistent;
        }

        public string NombrePersona
        {
            get { return persReservacion.Persona.NombrePersona; }
            set { persReservacion.Persona.NombrePersona = value; }
        }

        public string ApellidosPersona
        {
            get { return persReservacion.Persona.ApellidosPersona; }
            set { persReservacion.Persona.ApellidosPersona = value; }
        }

        public string PasaportePersona
        {
            get { return persReservacion.Persona.Pasaporte; }
            set { persReservacion.Persona.Pasaporte = value; } 
        }

        public IVuelo Vuelo
        {
            get { return (IVuelo)new TransVuelo(persReservacion.Vuelo); }
            set { persReservacion.Vuelo = (Vuelo)value; }
        }

        public IUsuario Usuario
        {
            get { return (IUsuario)new TransUsuario(persReservacion.Usuario); }
            set { persReservacion.Usuario = (Usuario)value; }
        }
    }
}
