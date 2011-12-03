using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBaseConnection
{
    interface IAvion
    {
        
        string NombreMarca { get; set; }

        string NombreSerie { get; set; }

        int ID { get; set; }
    }
}
