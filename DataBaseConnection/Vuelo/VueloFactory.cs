using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBaseConnection
{
    class VueloFactory : AbstractFactory<TransVuelo, Vuelo>
    {
        VueloFactory()
            : base(DALVuelo.GetVueloFromID)
        {
        }
    }
     
}
