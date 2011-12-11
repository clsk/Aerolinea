﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    class AvionFactory : AbstractFactory<IAvion, TransAvion, Avion>
    {
        AvionFactory()
            : base(DALAvion.GetAvionFromID)
        {
        }
    }
}
