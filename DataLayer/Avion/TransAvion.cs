using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBaseConnection
{
    public class TransAvion: IAvion
    {
        Avion persAvion;
        public TransAvion(Avion persistent)
        {
            persAvion = persistent;
        }

        public SerieAvion Serie
        {
            get { return persAvion.SerieAvion; }
            set { persAvion.SerieAvion = value; }
        }


    }
}
