using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public class AeropuertoFactory : AbstractFactory<IAeropuerto, TransAeropuerto, Aeropuerto>
    {
        public AeropuertoFactory()
            : base(DALDestino.GetAeropuertoFromID)
        {
        }

    }
}
