using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBaseConnection
{
    interface IAsiento
    {
        int PosX { get; set; }

        int PosY { get; set; }

        string Numero { get; set; }

        int Fila { get; set; }
    }
}
