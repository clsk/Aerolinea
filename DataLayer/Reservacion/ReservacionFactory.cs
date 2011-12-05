using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBaseConnection
{
    public class ReservacionFactory : AbstractFactory<IReservacion, TransReservacion, Reservacion>
    {
        ReservacionFactory()
            : base(DALReservacion.GetReservacionByID)
        { }
    }
}
