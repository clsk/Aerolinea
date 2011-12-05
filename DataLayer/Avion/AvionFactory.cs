using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBaseConnection
{
    class AvionFactory : AbstractFactory<IAvion, TransAvion, Avion>
    {
        AvionFactory()
            : base(DALAvion.GetAvionFromID)
        { }
    }
}
