using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    class TransAeropuerto : IAeropuerto
    {
        private Aeropuerto persAeropuerto;
        public TransAeropuerto(Aeropuerto aeropuerto)
        {
            persAeropuerto = aeropuerto;
        }


        #region IAeropuerto Members

        public string NombreAero
        {
            get
            {
                return persAeropuerto.NombreAeropuerto;
            }
            set
            {
                persAeropuerto.NombreAeropuerto = value;
            }
        }

        public string Siglas
        {
            get
            {
                return persAeropuerto.Siglas;
            }
            set
            {
                persAeropuerto.Siglas = value;
            }
        }

        public Ciudad ciudad
        {
            get
            {
                return persAeropuerto.Ciudad;
            }
            set
            {
                persAeropuerto.Ciudad = value;
            }
        }

        public void flush()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
