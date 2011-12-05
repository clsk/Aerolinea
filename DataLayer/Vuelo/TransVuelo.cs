using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public class TransVuelo : IVuelo
    {
        private Vuelo persVuelo;

        internal TransVuelo(Vuelo persistent)
        {
            persVuelo = persistent;
        }

        public DateTime FechaLlegada
        {
            get { return persVuelo.FechaLlegada; }
            set { persVuelo.FechaLlegada = value; }
        }

        public DateTime FechaSalida
        {
            get { return persVuelo.FechaSalida; }
            set { persVuelo.FechaSalida = value; }
        }

        public TimeSpan HoraLlegada
        {
            get { return persVuelo.HoraLlegada; }
            set { persVuelo.HoraLlegada = value; }
        }

        public TimeSpan HoraSalida
        {
            get { return persVuelo.HoraSalida; }
            set { persVuelo.HoraSalida = value; }
        }

        public string Comentario
        {
            get { return persVuelo.Comentario; }
            set { persVuelo.Comentario = value; }
        }
    }
}
