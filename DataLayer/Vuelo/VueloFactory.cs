using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public class VueloFactory : AbstractFactory<IVuelo, TransVuelo, Vuelo>
    {
        public VueloFactory()
            : base(DALVuelo.GetVueloFromID)
        {
        }

    }
     
}
