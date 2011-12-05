using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBaseConnection
{
    public class VueloFactory : AbstractFactory<IVuelo, TransVuelo, Vuelo, int>
    {
        public VueloFactory()
            : base(DALVuelo.GetVueloFromID)
        {
        }
    }
     
}
