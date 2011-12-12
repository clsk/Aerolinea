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

        public string NombrePersona
        {
            get { return persistent.Persona.NombrePersona; }
            set { persistent.Persona.NombrePersona = value; }
        }

        public string ApellidosPersona
        {
            get { return persistent.Persona.ApellidosPersona; }
            set { persistent.Persona.ApellidosPersona = value; }
        }

        public string PasaportePersona
        {
            get { return persistent.Persona.Pasaporte; }
            set { persistent.Persona.Pasaporte = value; } 
        }

        public IVuelo Vuelo
        {
            get { return (IVuelo)new TransVuelo(persistent.Vuelo); }
            set { persistent.Vuelo = (Vuelo)value; }
        }

        public IUsuario Usuario
        {
            get { return (IUsuario)new TransUsuario(persistent.Usuario); }
            set { persistent.Usuario = (Usuario)value; }
        }

        public void Flush()
        {
            base.Flush(DALCliente.UpdateReserva);
        }
    }
}
