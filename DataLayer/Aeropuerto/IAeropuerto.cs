using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public interface IAeropuerto
    {
        int ID { get; }
        string Nombre { get; set; }
        string Siglas { get; set; }
        Ciudad Ciudad { get; set; }
    }
}
