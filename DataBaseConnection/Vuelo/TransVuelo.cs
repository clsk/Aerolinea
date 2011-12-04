using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBaseConnection
{
    public class TransVuelo : ITrans<Vuelo>
    {
        private Vuelo pers_vuelo;

        public Vuelo Persistent
        {
            get { return pers_vuelo; }
            set { pers_vuelo = value; }
        }

        public DateTime FechaLlegada
        {
            get { return pers_vuelo.FechaLlegada; }
            set { pers_vuelo.FechaLlegada = value; }
        }

        public DateTime FechaSalida
        {
            get { return pers_vuelo.FechaSalida; }
            set { pers_vuelo.FechaSalida = value; }
        }

        public TimeSpan HoraLlegada
        {
            get { return pers_vuelo.HoraLlegada; }
            set { pers_vuelo.HoraLlegada = value; }
        }

        public TimeSpan HoraSalida
        {
            get { return pers_vuelo.HoraSalida; }
            set { pers_vuelo.HoraSalida = value; }
        }

        public string Comentario
        {
            get { return pers_vuelo.Comentario; }
            set { pers_vuelo.Comentario = value; }
        }

        
    }
}
