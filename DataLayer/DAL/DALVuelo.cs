using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    class DALVuelo
    {
        #region Crear un vuelo
        /**
         * @brief Crea un nuevo nuelo
         * 
         * @param unVuelo           el vuelo que será creado.
         * 
         * @return true si se pudo crear, false caso contrário
         */
        bool Create(Vuelo unVuelo)
        {
            try
            {
                Provider.GetProvider().spNewVuelo(unVuelo.idAvion, unVuelo.idPuertoSalida, unVuelo.FechaSalida, unVuelo.HoraSalida,
                                                  unVuelo.FechaLlegada, unVuelo.HoraLlegada, unVuelo.Comentario, unVuelo.idPuertoSalida);
            }
            catch { return false; }
            return true;
        }
        #endregion

        #region Crear un precio
        /**
         * @brief Crea un nuevo precio
         * 
         * @param unPrecio           el precio que será creado.
         * 
         * @return true si se pudo crear, false caso contrário
         */
        bool CreatePrecio(Precio unPrecio)
        {
            try { Provider.GetProvider().spNewPrecio(unPrecio.idTipoClase, unPrecio.idVuelo, unPrecio.Precio1); }
            catch { return false; }
            return true;
        }
        #endregion

        #region Actualizar un vuelo
        /**
         * @brief Actualiza un vuelo
         * 
         * @param unVuelo           el vuelo que será actualizado.
         * 
         * @return true si se pudo actualizar, false caso contrário
         */
        bool UpdateVuelo(Vuelo unVuelo)
        {
            try
            {
                Provider.GetProvider().spUpdateVuelo(unVuelo.idVuelo, unVuelo.idAvion, unVuelo.idPuertoSalida, unVuelo.FechaSalida, unVuelo.HoraSalida,
                                                  unVuelo.FechaLlegada, unVuelo.HoraLlegada, unVuelo.Comentario, unVuelo.idPuertoSalida);
            }
            catch { return false; }
            return true;
        }
        #endregion

        #region Actualizar precio
        /**
         * @brief Actualiza un precio
         * 
         * @param unPrecio           el precio que será actualizado.
         * 
         * @return true si se pudo actualizar, false caso contrário
         */
        bool ActualizarPrecio(Precio unPrecio)
        {
            try { Provider.GetProvider().spUpdatePrecio(unPrecio.idPrecio, unPrecio.idTipoClase, unPrecio.idVuelo, unPrecio.Precio1); }
            catch { return false; }
            return true;
        }
        #endregion

        #region Obtener un vuelo dado un ID
        /**
         * @brief Obtiene el vuelo dado el ID.
         * 
         * @param ID            el ID del vuelo que se desea buscar.
         * 
         * @return el vuelo si se pudo encontrar, NULL caso contrário.
         */
        public static Vuelo GetVueloFromID(int ID)
        {
            try { return Provider.GetProvider().spGetVueloFromID(ID).FirstOrDefault(); }
            catch { return null; }
        }
        #endregion

        #region Obtener vuelos dado 2 fechas y un origen y un destino.
        /**
         * @brief Obtiene los vuelos entre 2 fechas y desde un origen hasta un destino.
         * 
         * @param Fecha1            La primera fecha
         * @param Fecha2            La segunda fecha
         * @param Origen            Aeropuerto de origen del vuelo.
         * @param Destino           Aeropuerto de destino del vuelo.
         * 
         * @return la lista de vuelo si se pudo encontrar, NULL caso contrário.
         */
        List<Vuelo> GetVueloFromFechaAndPuerto(DateTime Fecha1, DateTime Fecha2, Aeropuerto Origen, Aeropuerto Destino)
        {
            try { return Provider.GetProvider().spGetVueloFromFechaAndPuerto(Fecha1, Fecha2, Origen.idAeropuerto, Destino.idAeropuerto).ToList(); }
            catch { return null; }
        }
        #endregion
    }
}
