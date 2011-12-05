using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    class DALVuelo
    {
        #region Crear un vuelo
        bool Create(Vuelo unVuelo)
        {
            return false;
        }
        #endregion
        #region Crear un precio
        bool CreatePrecio(Precio unPrecio)
        {
            return false;
        }
        #endregion

        #region Actualizar un vuelo
        bool UpdateVuelo(Vuelo unVuelo)
        {
            return false;
        }
        #endregion

        #region Actualizar precio
        bool ActualizarPrecio(Precio unPrecio)
        {
            return true;
        }
        #endregion

        #region GetVueloFromID
        public static Vuelo GetVueloFromID(int ID)
        {
            return null;
        }
        #endregion

        #region Obtener un vuelo dado 2 fechas y un origen y un destino.
        List<Vuelo> GetVueloFromFechaAndPuerto(Vuelo unVuelo)
        {
            return null;
        }
        #endregion
    }
}
