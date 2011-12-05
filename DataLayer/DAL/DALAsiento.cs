using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    class DALAsiento
    {
        #region Crear asiento.
        /**
         * @brief Crea un nuevo asiento
         * 
         * @param unAsiento         Asiento que se desea crear.
         * 
         * @return true si fue posible crear el asiento, false caso contrário.
         */
        static public bool Create(Asiento unAsiento)
        {
            return false;
        }
        #endregion

        #region Crear clase.
        /**
         * @brief Crea una nueva TipoClase
         * 
         * @param unaClase         Clase que se desea crear.
         * 
         * @return true si fue posible crear la clase, false caso contrário.
         */
        static public bool CreateTipoClase(TipoClase unaClase)
        {
       
            return false;
        }
        #endregion

        #region Actualizar asiento.
        /**
         * @brief Actualizar un nuevo asiento
         * 
         * @param unAsiento         Asiento que se desea actualizar.
         * 
         * @return true si fue posible actualizar el asiento, false caso contrário.
         */
        static public bool UpdateAsiento(Asiento unAsiento)
        {
            return false;
        }
        #endregion

        #region Actualizar clase.
        /**
         * @brief Actualizar una nueva TipoClase
         * 
         * @param unaClase         Clase que se desea actualizar.
         * 
         * @return true si fue posible actualizar la clase, false caso contrário.
         */
        static public bool UpdateTipoClase(TipoClase unaClase)
        {
            return false;
        }
        #endregion

        #region Obtener asiento dado un ID.
        /**
         * @brief Obtiene un asiento dado su ID
         * 
         * @param idAsiento         ID del asiento que se desea buscar.
         * 
         * @return Un asiento si se pudo encontrar, null caso contrário.
         */
        static public Asiento GetAsientoFromID(int idAsiento)
        {
            return null;
        }
        #endregion

        #region Obtener TipoClase dado un ID.
        /**
         * @brief Obtiene un TipoClase dado su ID
         * 
         * @param idClase         ID del asiento que se desea buscar.
         * 
         * @return Un TipoClase si se pudo encontrar, null caso contrário.
         */
        static public TipoClase GetTipoClaseFromID(int idClase)
        {
            return null;
        }
        #endregion

        #region Obtener asientos de un avión.
        /**
         * @brief Obtiene los asientos de un avión dado su ID y el piso
         * 
         * @param idAvión         ID del avión.
         * @param Piso            Piso en que se encuentra el asiento.
         * 
         * @return Una lista de asiento si se pudo encontrar, null caso contrário.
         */
        static public List<Asiento> GetAsientoFromPisoAvion(int idAvion, int Piso)
        {
            return null;
        }
        #endregion

        #region Obtener asientos no ocupados
        /**
         * @brief Obtiene los asientos que no están ocupados en un vuelo
         * 
         * @param idVuelo         ID del vuelo que se desea hacer la búsqueda.
         * 
         * @return Una lista de asientos NO ocupados si se pudo encontrar, null caso contrário.
         */
        static public List<Asiento> GetAsientosNoOcupados(int idVuelo)
        {
            return null;
        }
        #endregion
    }
}
