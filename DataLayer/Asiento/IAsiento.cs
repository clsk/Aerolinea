using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public interface IAsiento
    {
        TipoClase Clase { get; set; }

        int PosX { get; set; }

        int PosY { get; set; }

        string Numero { get; set; }

        int Fila { get; set; }

        int IdAsiento { get; set; }
    }
}
