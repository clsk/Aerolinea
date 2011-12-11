using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public class TransVuelo : AbstractTrans<Vuelo>, IVuelo
    {
        internal TransVuelo(Vuelo persistent_object) : base(persistent_object)
        {
        }

        public DateTime FechaLlegada
        {
            get { return persistent.FechaLlegada; }
            set { persistent.FechaLlegada = value; }
        }

        public DateTime FechaSalida
        {
            get { return persistent.FechaSalida; }
            set { persistent.FechaSalida = value; }
        }

        public TimeSpan HoraLlegada
        {
            get { return persistent.HoraLlegada; }
            set { persistent.HoraLlegada = value; }
        }

        public TimeSpan HoraSalida
        {
            get { return persistent.HoraSalida; }
            set { persistent.HoraSalida = value; }
        }

        public string Comentario
        {
            get { return persistent.Comentario; }
            set { persistent.Comentario = value; }
        }

        public void Flush()
        {
            base.Flush(DALVuelo.UpdateVuelo);
        }
    }
}
