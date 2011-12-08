using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    class DALDestino
    {

        #region Crear pais
        /**
        * @brief Crea un país
        * 
        * @param unPais       el País que se desea crear.
        * 
        * @return true si se pudo crear, false caso contrário
        *
        * @remark el idPais NO necesita ser inicializado.
        */
        static public bool CreatePais(Pais unPais)
        {
            try { Provider.GetProvider().spNewPais(unPais.NombrePais); }
            catch (Exception e) { throw e; }
            return true;
        }
        #endregion

        #region Crear ciudad
        /**
        * @brief Crea una ciudad
        * 
        * @param unaCiudad      Ciudad que se desea crear.
        * 
        * @return true si se pudo crear, false caso contrário
        *
        * @remark el idCiudad NO necesita ser inicializado.
        */
        static public bool CreateCiudad(Ciudad UnaCiudad)
        {
            try { Provider.GetProvider().spNewCiudad(UnaCiudad.NombreCiudad, UnaCiudad.idPais); }
            catch (Exception e) { throw e; }
            return true;
        }
        #endregion

        #region Crear aeropuerto
        /**
        * @brief Crea un aeropuerto
        * 
        * @param unAeropuerto       Aeropuerto que se desea crear.
        * 
        * @return true si se pudo crear, false caso contrário
        *
        * @remark el idAeropuerto NO necesita ser inicializado.
        */
        static public bool Create(Aeropuerto UnAeropuerto)
        {
            try { Provider.GetProvider().spNewAeropuerto(UnAeropuerto.NombreAeropuerto, UnAeropuerto.idCiudad, UnAeropuerto.Siglas); }
            catch (Exception e) { throw e; }
            return true;
        }
        #endregion

        #region Actualizar pais
        /**
        * @brief Actualiza un país
        * 
        * @param unPais         Pais que se desea actualizar.
        * 
        * @return true si se pudo actualizar, false caso contrário.
        *
        * @warning el idAeropuerto DEBE estar inicializado.
        */
        static public bool UpdatePais(Pais unPais)
        {
            try { Provider.GetProvider().spUpdatePais(unPais.idPais, unPais.NombrePais); }
            catch (Exception e) { throw e; }
            return true;
        }
        #endregion

        #region Actualizar ciudad
        /**
        * @brief Actualiza una ciudad
        * 
        * @param unaCiudad          Ciudad que se desea actualizar.
        * 
        * @return true si se pudo actualizar, false caso contrário.
        *
        * @warning el idCiudad DEBE estar inicializado.
        */
        static public bool UpdateCiudad(Ciudad unaCiudad)
        {
            try { Provider.GetProvider().spUpdateCiudad(unaCiudad.idCiudad, unaCiudad.NombreCiudad, unaCiudad.idPais); }
            catch (Exception e) { throw e; }
            return true;
        }
        #endregion

        #region Actualizar aeropuerto
        /**
        * @brief Actualiza un Aeropuerto
        * 
        * @param unAeropuerto       Aeropuerto que se desea actualizar.
        * 
        * @return true si se pudo actualizar, false caso contrário.
        *
        * @warning el idAeropuerto DEBE estar inicializado.
        */
        static public bool UpdatePais(Aeropuerto unAeropuerto)
        {
            try { Provider.GetProvider().spUdateAeropuerto(unAeropuerto.idAeropuerto, unAeropuerto.NombreAeropuerto, unAeropuerto.idCiudad, unAeropuerto.Siglas); }
            catch (Exception e) { throw e; }
            return true;
        }
        #endregion

        #region Obtener todos los paises
        /**
        * @brief Obtiene todos los paises disponibles.
        * 
        * @return Una lista de paises si todo salió bien, NULL caso contrário.
        */
        static public List<Pais> GetAllPaises()
        {
            try { return Provider.GetProvider().spGetAllPaises().ToList(); }
            catch (Exception e) { throw e; }
        }
        #endregion

        #region Obtener ciudades en un pais
        /**
        * @brief Obtiene todas las ciudades que están en un pais dado.
        * 
        * @param idPais        ID del pais en el que se desea buscar.
        * 
        * @return Una lista de ciudades si todo salió bien, NULL caso contrário.
        */
        static public List<Ciudad> GetCiudadesFromPais(int idPais)
        {
            try { return Provider.GetProvider().spGetCiudadesFromPais(idPais).ToList(); }
            catch (Exception e) { throw e; }
        }
        #endregion

        #region Obtener aeropuertos en una ciudad
        /**
        * @brief Obtiene todos los aeropuertos que están en una ciudad.
        * 
        * @param idPais        ID de la ciudad en la que se desea buscar.
        * 
        * @return Una lista de aeropuertos si todo salió bien, NULL caso contrário
        */
        static public List<Aeropuerto> GetAeropuertosFromCiudad(int idCiudad)
        {
            try { return Provider.GetProvider().spGetAeropuertoFromCiudad(idCiudad).ToList(); }
            catch (Exception e) { throw e; }
        }
        #endregion

        #region Obtener un aeropuerto dado un ID
        /**
        * @brief Obtiene un aeropuerto dado un ID.
        * 
        * @param idAeropuerto        ID del aeropuerto que se desea buscar
        * 
        * @return Una aeropuerto si todo salió bien, NULL caso contrário
        */
        static public Aeropuerto GetAeropuertoFromID(int idAeropuerto)
        {
            try { return Provider.GetProvider().spGetAeropuertoFromID(idAeropuerto).FirstOrDefault(); }
            catch (Exception e) { throw e; }
        }
        #endregion
    }
}
