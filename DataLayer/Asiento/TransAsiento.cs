using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBaseConnection
{
    public class TransAsiento : IAsiento
    {
        public TransAsiento(Asiento persistent)
        {
            persAsiento = persistent;
        }

        private Asiento persAsiento;

        public TipoClase Clase
        {
            get { return persAsiento.TipoClase; }
            set { persAsiento.TipoClase = value; }
        }

        public int PosX { get { return persAsiento.CordX; } set { persAsiento.CordX = value; } }

        public int PosY { get { return persAsiento.CordY; } set { persAsiento.CordY = value; } }

        public string Numero { get { return persAsiento.Numero; } set { persAsiento.Numero = value; } }

        public int Fila { get { return persAsiento.Fila; } set { persAsiento.Fila = value; } }

        public int IdAsiento { get { return persAsiento.idAsiento; } set { persAsiento.idAsiento = value; } }
    }
}
