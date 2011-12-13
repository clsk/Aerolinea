using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public class TransVuelo : AbstractTrans<Vuelo>, IVuelo
    {
        public TransVuelo(Vuelo persistent_object) : base(persistent_object)
        {
        }

        public int ID
        {
            get
            {
                return persistent.idVuelo;
            }
        }

        public DateTime FechaLlegada
        {
            get { return persistent.FechaLlegada; }
            set { persistent.FechaLlegada = value; }
        }

        public DateTime FechaSalida
        {
            get { return persistent.FechaSalida; }
            set { persistent.FechaSalida = value; }
        }

        public TimeSpan HoraLlegada
        {
            get { return persistent.HoraLlegada; }
            set { persistent.HoraLlegada = value; }
        }

        public TimeSpan HoraSalida
        {
            get { return persistent.HoraSalida; }
            set { persistent.HoraSalida = value; }
        }

        public string Comentario
        {
            get { return persistent.Comentario; }
            set { persistent.Comentario = value; }
        }

        public TransAeropuerto PuertoLlegada
        {
            get 
            {
                if (puerto_llegada == null)
                {
                    AeropuertoFactory factory = new AeropuertoFactory();
                    factory.BuildProduct(persistent.idPuertoLlegada);
                    puerto_llegada = (TransAeropuerto)factory.GetProduct();
                }

                return puerto_llegada;
            }

            set
            {
                puerto_llegada = value;
                persistent.idPuertoLlegada = value.ID;
            }
        }

        public TransAeropuerto PuertoSalida
        {
            get
            {
                if (puerto_salida == null)
                {
                    AeropuertoFactory factory = new AeropuertoFactory();
                    factory.BuildProduct(persistent.idPuertoSalida);
                    puerto_salida = (TransAeropuerto)factory.GetProduct();
                }

                return puerto_salida;
            }

            set
            {
                puerto_salida = value;
                persistent.idPuertoSalida = value.ID;
            }
        }

        public void Flush()
        {
            base.Flush(DALVuelo.UpdateVuelo);
        }

        private TransAeropuerto puerto_llegada;
        private TransAeropuerto puerto_salida;
    }
}
