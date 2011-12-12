using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public interface IReservacion
    {
        string NombrePersona
        {
            get;
            set;
        }

        string ApellidosPersona
        {
            get;
            set;
        }

        string PasaportePersona
        {
            get;
            set;
        }

        IVuelo Vuelo
        {
            get;
        }
    }
}
