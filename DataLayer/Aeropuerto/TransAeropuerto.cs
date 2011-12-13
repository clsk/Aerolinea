using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public class TransAeropuerto : AbstractTrans<Aeropuerto>, IAeropuerto
    {
        public TransAeropuerto(Aeropuerto persistent_object) : base(persistent_object)
        {
        }

        public TransAeropuerto(string nombre, Ciudad ciudad, string siglas)
            : base(null)
        {
            Nombre = nombre;
            Ciudad = ciudad;
            Siglas = siglas;
        }
        public int ID
        {
            get { return persistent.idAeropuerto; }
        }


        #region IAeropuerto Members

        public string Nombre
        {
            get
            {
                return persistent.NombreAeropuerto;
            }
            set
            {
                persistent.NombreAeropuerto = value;
            }
        }

        public string Siglas
        {
            get
            {
                return persistent.Siglas;
            }
            set
            {
                persistent.Siglas = value;
            }
        }

        public Ciudad Ciudad
        {
            get
            {
                return persistent.Ciudad;
            }
            set
            {
                persistent.Ciudad = value;
            }
        }

        public void Flush()
        {
            base.Flush(DALDestino.UpdateAeropuerto);
        }

        public void Create()
        {
            base.Flush(DALDestino.Create);
        }

        public static List<TransAeropuerto> GetAll()
        {
            return DataLayer.DALDestino.GetAllAeropuerto().ConvertAll<TransAeropuerto>(pers => new TransAeropuerto(pers));
        }

        #endregion
    }
}
