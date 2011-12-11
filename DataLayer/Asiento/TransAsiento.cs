using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public class TransAsiento : AbstractTrans<Asiento>, IAsiento
    {
        internal TransAsiento(Asiento persistent_object)
            : base(persistent_object)

        {
        }

        public TipoClase Clase
        {
            get { return persistent.TipoClase; }
            set { persistent.TipoClase = value; }
        }

        public int PosX { get { return persistent.CordX; } set { persistent.CordX = value; } }

        public int PosY { get { return persistent.CordY; } set { persistent.CordY = value; } }

        public string Numero { get { return persistent.Numero; } set { persistent.Numero = value; } }

        public int Fila { get { return persistent.Fila; } set { persistent.Fila = value; } }

        public int IdAsiento { get { return persistent.idAsiento; } set { persistent.idAsiento = value; } }

        public void Flush()
        {
            base.Flush(DALAsiento.UpdateAsiento);
        }
    }
}
