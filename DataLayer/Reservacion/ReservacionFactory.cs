using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public class ReservacionFactory : AbstractFactory<IReservacion, TransReservacion, Reservacion>
    {
        ReservacionFactory()
            : base(DALCliente.GetReservacionFromID)
        { }
    }
}
