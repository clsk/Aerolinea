using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBaseConnection
{
    public class ReservacionFactory : AbstractFactory<IReservacion, TransReservacion, Reservacion, int>
    {
        ReservacionFactory()
            : base(DALReservacion.GetReservacionByID)
        { }
    }
}
