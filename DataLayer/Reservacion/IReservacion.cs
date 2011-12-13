﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public interface IReservacion
    {
        Persona Persona
        {
            get;
            set;
        }

        TransVuelo Vuelo
        {
            get;
            set;
        }

        TransAsiento Asiento
        {
            get;
            set;
        }

        TransUsuario Usuario
        {
            get;
            set;
        }
    }
}
