using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer;

namespace BusinessLogic
{
    class VueloView : TransVuelo
    {
        public VueloView(Vuelo persistent_object) : base(persistent_object)
        {
        }

        public string DisplayPuertos
        {
            get { return  ; }
        }
    }
}
