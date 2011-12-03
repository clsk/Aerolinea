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

        public int PosX { get; set; }

        public int PosY { get; set; }

        public string Numero { get; set; }

        public int Fila { get; set; }

        public int IdAsiento { get; set; }

        private TipoClase clase;

        public TipoClase Clase { get; set; }

    }
}
