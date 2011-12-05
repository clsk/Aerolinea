using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public class AsientoFactory : AbstractFactory<IAsiento, TransAsiento, Asiento>
    {
        AsientoFactory()
            : base(DALAsiento.GetAsientoFromID)
        {
        }
    }
}
