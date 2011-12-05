using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBaseConnection
{
    public interface IVuelo
    {
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
    }
}
