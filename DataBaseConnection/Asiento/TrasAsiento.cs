using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBaseConnection
{
    class TrasAsiento : IAsiento
    {
        public TrasAsiento(int ID)
        {
        }
        private Asiento asiento;

        private int posX;
        public int PosX { get; set; }

        private int posY;
        public int PosY { get; set; }

        private string numero;
        public string Numero { get; set; }

        private int fila;
        public int Fila { get; set; }

        private TipoClase clase;

        public TipoClase Clase { get; set; }
    }
}
