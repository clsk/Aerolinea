using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public class TransAsiento : AbstractTrans<Asiento>, IAsiento
    {
        public TransAsiento(Asiento persistent_object)
            : base(persistent_object)
        {
        }

        public TransAsiento(TransAvion avion, TipoClase clase, string numero, int fila, int posX, int posY, int piso) : base(null)
        {
            persistent = new Asiento();
            Avion = avion;
            Clase = clase;
            Numero = numero;
            Fila  = fila;
            PosX = posX;
            PosX = posX;
            Piso = piso;
        }

        public TransAvion Avion
        {
            get { return new TransAvion(persistent.Avion); }
            set { persistent.Avion = value.PersistentObject; }
        }

        public int Piso
        {
            get { return persistent.Piso; }
            set { persistent.Piso = value; }
        }

        public TipoClase Clase
        {
            get { return persistent.TipoClase;  }
            set { persistent.TipoClase = value; }
        }

        public int PosX { get { return persistent.CordX; } set { persistent.CordX = value; } }

        public int PosY { get { return persistent.CordY; } set { persistent.CordY = value; } }

        public string Numero { get { return persistent.Numero; } set { persistent.Numero = value; } }

        public int Fila { get { return persistent.Fila; } set { persistent.Fila = value; } }

        public int ID { get { return persistent.idAsiento; } }

        public void Flush()
        {
            base.Flush(DALAsiento.UpdateAsiento);
        }

        public void Create()
        {
            base.Flush(DALAsiento.Create);
        }

        static public List<TransAsiento> AllClases()
        {
            //Debería usar DALAsiento.GetAllTipoClases();
            return null;
        }
    }
}
