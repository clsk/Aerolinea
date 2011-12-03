using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBaseConnection
{
    class TransReservacion
    {
        public string NombrePersona
        {
            get;
            set;
        }

        public string ApellidosPersona
        {
            get;
            set;
        }

        public string PasaportePersona
        {
            get;
            set;
        }

        // TransVuelo vuelo;
        TransAsiento asiento;
        Persona persona;
        TransUsuario usuario_registrador;
    }
}
