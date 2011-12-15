using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer;

namespace UI
{
    public class AeropuertoView : TransAeropuerto
    {
        public AeropuertoView(Aeropuerto persistent_object) : base(persistent_object)
        {
        }

        public string DisplayName
        {
            get { return Nombre + " (" + Siglas + "), " + Ciudad.NombreCiudad + ", " + Ciudad.Pai.NombrePais; }
        }
    }
}
