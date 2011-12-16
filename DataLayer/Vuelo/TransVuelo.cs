using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    /// <summary>
    /// Representa un Vuelo
    /// </summary>
    public class TransVuelo : AbstractTrans<Vuelo>, IVuelo
    {
        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="persistent_object"></param>
        public TransVuelo(Vuelo persistent_object) : base(persistent_object)
        {
            puerto_salida = null;
            puerto_llegada = null;
        }

        public TransVuelo(TransAvion avion, DateTime fecha_salida, DateTime fecha_llegada, 
            TimeSpan hora_salida, TimeSpan hora_llegada, TransAeropuerto puerto_salida, TransAeropuerto puerto_llegada, string comentario) : base(null)
        {
            persistent = new Vuelo();
            persistent.idVuelo = -1;
            Avion = avion;
            FechaLlegada = fecha_llegada;
            FechaSalida = fecha_salida;
            HoraLlegada = hora_llegada;
            HoraSalida = hora_salida;
            Comentario = comentario;
            PuertoLlegada = puerto_llegada;
            PuertoSalida = puerto_salida;
        }

        public int ID
        {
            get { return persistent.idVuelo; }
        }

        public TransAvion Avion
        {
            get { return new TransAvion(persistent.Avion); }
            set { persistent.Avion = value.PersistentObject; }
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

        public void Create()
        {
            base.Flush(DALVuelo.Create);
        }

        public static List<TransVuelo> FromFechaAndPuerto(DateTime desde_fecha, DateTime hasta_fecha, TransAeropuerto desde_aeropuerto, TransAeropuerto hacia_aeropuerto)
        {
            return DALVuelo.GetVueloFromFechaAndPuerto(desde_fecha, hasta_fecha, desde_aeropuerto.PersistentObject, hacia_aeropuerto.PersistentObject).ConvertAll<TransVuelo>(pers => new TransVuelo(pers));
        }

        private TransAeropuerto puerto_llegada;
        private TransAeropuerto puerto_salida;
    }
}
