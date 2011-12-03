using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBaseConnection
{
    class DALDestino
    {
        ReservaVuelosEntities context;
        public DALDestino()
        {
            context = new ReservaVuelosEntities();
        }
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
        public bool CreatePais(Pais unPais)
        {
            try { context.spNewPais(unPais.NombrePais); }
            catch { return false; }
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
        public bool CreateCiudad(Ciudad UnaCiudad)
        {
            try { context.spNewCiudad(UnaCiudad.NombreCiudad, UnaCiudad.idPais); }
            catch { return false; }
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
        public bool CreateCiudad(Aeropuerto UnAeropuerto)
        {
            try { context.spNewAeropuerto(UnAeropuerto.NombreAeropuerto, UnAeropuerto.idCiudad, UnAeropuerto.Siglas); }
            catch { return false; }
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
        public bool UpdatePais(Pais unPais)
        {
            try { context.spUpdatePais(unPais.idPais, unPais.NombrePais); }
            catch { return false; }
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
        public bool UpdateCiudad(Ciudad unaCiudad)
        {
            try { context.spUpdateCiudad(unaCiudad.idCiudad, unaCiudad.NombreCiudad, unaCiudad.idPais); }
            catch { return false; }
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
        public bool UpdatePais(Aeropuerto unAeropuerto)
        {
            try { context.spUdateAeropuerto(unAeropuerto.idAeropuerto, unAeropuerto.NombreAeropuerto, unAeropuerto.idCiudad, unAeropuerto.Siglas); }
            catch { return false; }
            return true;
        }
        #endregion

        #region Obtener todos los paises
        /**
        * @brief Obtiene todos los paises disponibles.
        * 
        * @return Una lista de paises si todo salió bien, NULL caso contrário.
        */
        public List<Pais> GetAllPaises()
        {
            try { return context.spGetAllPaises().ToList(); }
            catch { return null; }
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
        public List<Ciudad> GetCiudadesFromPais(int idPais)
        {
            try { return context.spGetCiudadesFromPais(idPais).ToList();}
            catch { return null; }
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
        public List<Aeropuerto> GetAeropuertosFromCiudad(int idCiudad)
        {
            try { return context.spGetAeropuertoFromCiudad(idCiudad).ToList(); }
            catch { return null; }
        }
        #endregion

        #region Obtener un aeropuerto dado
        /**
        * @brief Obtiene un aeropuerto dado.
        * 
        * @param idAeropuerto        ID del aeropuerto que se desea buscar
        * 
        * @return Una aeropuerto si todo salió bien, NULL caso contrário
        */
        public Aeropuerto GetAeropuertoFromID(int idAeropuerto)
        {
            try { return context.spGetAeropuertoFromID(idAeropuerto).FirstOrDefault(); }
            catch { return null; }
        }
        #endregion
    }
}
