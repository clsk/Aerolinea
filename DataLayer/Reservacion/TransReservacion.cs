using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public class TransReservacion : AbstractTrans<Reservacion>, IReservacion
    {
        public TransReservacion(Reservacion persistent_object) : base(persistent_object)
        {
        }

        public int ID
        {
            get { return persistent.idReservacion; }
        }

        public TransReservacion(Persona persona, TransVuelo vuelo, TransAsiento asiento, TransUsuario usuario) : base(null)
        {
            persistent = new Reservacion();
            Persona = persona;
            Vuelo = vuelo;
            Asiento = asiento;
            Usuario = usuario;
        }

        public TransAsiento Asiento
        {
            get { return new TransAsiento(persistent.Asiento); }
            set { persistent.Asiento = value.PersistentObject; }
        }

        public TransUsuario Usuario
        {
            get { return new TransUsuario(persistent.Usuario); }
            set { persistent.Usuario = value.PersistentObject; }
        }

        public Persona Persona
        {
            get { return persistent.Persona; }
            set { persistent.Persona = value; }
        }

        public TransVuelo Vuelo
        {
            get { return new TransVuelo(persistent.Vuelo); }
            set { persistent.Vuelo = value.PersistentObject; }
        }

        public void Flush()
        {
            base.Flush(DALCliente.UpdateReserva);
        }

        public void Create()
        {
            persistent = DALCliente.Create(persistent);
        }
    }
}
