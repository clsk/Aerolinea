using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public interface IVuelo : ITrans<Vuelo>
    {
        int ID
        {
            get;
        }

        DateTime FechaLlegada
        {
            get;
            set;
        }

        DateTime FechaSalida
        {
            get;
            set;
        }

        TimeSpan HoraLlegada
        {
            get;
            set;
        }

        TimeSpan HoraSalida
        {
            get;
            set;
        }

        string Comentario
        {
            get;
            set;
        }

        TransAeropuerto PuertoLlegada
        {
            get;
            set;
        }

        TransAeropuerto PuertoSalida
        {
            get;
            set;
        }
    }
}
