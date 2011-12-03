using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBaseConnection
{
    class DALCliente
    {
        ReservaVuelosEntities context;
        public DALCliente()
        {
            context = new ReservaVuelosEntities();
        }

        #region Agregar reserva.
        /**
         * @brief Agrega una reservación.
         * 
         * @param unaReserva        reservación que se desea agregar.
         * 
         * @return true si se pudo crear la nueva reserva, false caso contrário.
         */
        public bool CreateReserva(Reservacion unaReserva)
        {
            return false;
        }
        #endregion

        #region Agregar persona.
        /**
         * @brief Agrega una persona.
         * 
         * @param unaPersona        persona que se desea agregar.
         * 
         * @return true si se pudo crear la nueva persona, false caso contrário.
         */
        public bool CreatePersona(Persona unaPersona)
        {
            return false;
        }
        #endregion
        
        #region Actualizar reserva.
        /**
         * @brief actualiza una reservación.
         * 
         * @param unaReserva        reservación que se desea actualizar.
         * 
         * @return true si se pudo actualizar la nueva reserva, false caso contrário.
         */
        public bool UpdateReserva(Reservacion unaReserva)
        {
            return false;
        }
        #endregion
        
        #region Actualizar persona.
        /**
         * @brief actualiza una persona.
         * 
         * @param unaPersona        persona que se desea actualizar.
         * 
         * @return true si se pudo actualizar la nueva persona, false caso contrário.
         */
        public bool UpdatePersona(Persona unaPersona)
        {
            return false;
        }
        #endregion

    }
}
