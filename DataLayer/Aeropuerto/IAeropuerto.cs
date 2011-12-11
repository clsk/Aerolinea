using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public interface IAeropuerto
    {
        string NombreAero { get; set; }
        string Siglas { get; set; }
        Ciudad ciudad { get; set; }
        void flush();
    }
}
