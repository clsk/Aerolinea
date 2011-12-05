using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBaseConnection
{
    public class TransAsiento : IAsiento
    {
        public TransAsiento(int ID)
        {

        }
        private Asiento asiento;

        private TipoClase clase;

        public int PosX { get { return asiento.CordX; } set { asiento.CordX = value;} }

        public int PosY { get { return asiento.CordY; } set { asiento.CordY = value; } }

        public string Numero { get { return asiento.Numero; } set { asiento.Numero = value; } }

        public int Fila { get { return asiento.Fila; } set { asiento.Fila = value; } }

        public int IdAsiento { get { return asiento.idAsiento; } set { asiento.idAsiento = value; } }

        public string NombreClase { get { return clase.NombreClase; } set { clase.NombreClase = value; } }

    }
}
