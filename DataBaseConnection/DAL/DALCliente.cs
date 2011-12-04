using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBaseConnection
{
    class DALCliente
    {
        #region Agregar reserva.
        /**
         * @brief Agrega una reservación.
         * 
         * @param unaReserva        reservación que se desea agregar.
         * 
         * @return true si se pudo crear la nueva reserva, false caso contrário.
         */
        static public bool Create(Reservacion unaReserva)
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
        static public bool CreatePersona(Persona unaPersona)
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
        static public bool UpdateReserva(Reservacion unaReserva)
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
        static public bool UpdatePersona(Persona unaPersona)
        {
            return false;
        }
        #endregion

        #region Obtener reservación dado un ID
        static Reservacion GetReservacionFromID(int ID)
        {
            return null;
        }
        #endregion

        #region Obtener persona dado un pasaporte
        static Persona GetPersonaFromPasaporte(string pasaporte)
        {
            return null;
        }
        #endregion

        #region Obtener persona dado un Apellido y un nombre
        static List<Persona> GetPersonasFromApellidoAndNombre(string nombre, string apellido)
        {
            return null;
        }
        #endregion
    }
}
