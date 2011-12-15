using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public class DALCliente
    {
        #region Agregar reserva.
        /**
         * @brief Agrega una reservación.
         * 
         * @param unaReserva        reservación que se desea agregar.
         * 
         * @return true si se pudo crear la nueva reserva, false caso contrário.
         */
        static public void Create(Reservacion unaReserva)
        {
            try { Provider.GetProvider().spNewReservacion(unaReserva.idPersona, unaReserva.idVuelo, unaReserva.idAsiento, unaReserva.idUsuario); }
            catch (Exception e) { throw e; }
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
        static public void CreatePersona(Persona unaPersona)
        {
            try { Provider.GetProvider().spNewPersona(unaPersona.NombrePersona, unaPersona.ApellidosPersona, unaPersona.Pasaporte); }
            catch (Exception e) { throw e; }
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
        static public void UpdateReserva(Reservacion unaReserva)
        {
            try { Provider.GetProvider().spUpdateReservacion(unaReserva.idReservacion, unaReserva.idPersona, unaReserva.idVuelo, unaReserva.idAsiento, unaReserva.idUsuario); }
            catch (Exception e) { throw e; }
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
            try { Provider.GetProvider().spUpdatePersona(unaPersona.idPersona, unaPersona.NombrePersona, unaPersona.ApellidosPersona, unaPersona.Pasaporte); }
            catch (Exception e) { throw e; }
            return true;
        }
        #endregion

        #region Obtener reservación dado un ID
        /**
         * @brief Obtiene una reservación dado un ID
         * 
         * @param ID        El ID de la reservación que se desea buscar.
         * 
         * @return  La reservación si se encontró, null caso contrário.
         */
        static public Reservacion GetReservacionFromID(int ID)
        {
            try { return Provider.GetProvider().spGetReservaFromID(ID).FirstOrDefault(); }
            catch (Exception e) { throw e; }
        }
        #endregion

        #region Obtener persona dado un pasaporte
        /**
         * @brief Obtiene una persona dado su pasaporte
         * 
         * @param pasaporte         El pasaporte de la persona que se desea encontrar.
         * 
         * @return La persona si se pudo encontrar, null caso contrário.
         */
        public static Persona GetPersonaFromPasaporte(string pasaporte)
        {
            try { return Provider.GetProvider().spGetPersonaFromPasaporte(pasaporte).FirstOrDefault(); }
            catch (Exception e) { throw e; }
        }
        #endregion

        #region Obtener persona dado un Apellido y un nombre
        /**
         * @brief Obtiene una persona dado su apellido y opcionalmente el nombre.
         * 
         * @param nombre            El nombre de la persona.
         * @param apellido          El apellido de la persona.
         * 
         * @warning El apellido SIEMPRE debe estar presente, el nombre es opcional.
         * 
         * @return Una lista de persona si se pudo encontrar, null caso contrário.
         */
        public static List<Persona> GetPersonasFromApellidoAndNombre(string nombre, string apellido)
        {
            try { return Provider.GetProvider().spGetPersonaLikeApellido(nombre, apellido).ToList(); }
            catch (Exception e) { throw e; }
        }
        #endregion

        #region Borrar reservacion
        /**
         * @brief Borra una reservacion
         * 
         * @param ID          El ID de la reservacion que se desea borrar.
         * 
         */
        public static void DeleteReservacion(int ID)
        {
            try { Provider.GetProvider().spDeleteReservacion(ID); }
            catch (Exception e) { throw e; }
        }
        #endregion
    }
}
