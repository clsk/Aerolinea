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
            try { Provider.GetProvider().spNewAsiento(unAsiento.idAvion, unAsiento.idTipoClase, unAsiento.Numero, unAsiento.Fila, unAsiento.CordX, unAsiento.CordY, unAsiento.Piso); }
            catch (Exception e) { throw e; }
            return true;
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
            try { Provider.GetProvider().spNewTipoClase(unaClase.NombreClase); }
            catch (Exception e) { throw e; }
            return true;
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
        static public void UpdateAsiento(Asiento unAsiento)
        {
            try { Provider.GetProvider().spUpdateAsiento(unAsiento.idAsiento,unAsiento.idAvion, unAsiento.idTipoClase, unAsiento.Numero, unAsiento.Fila, unAsiento.CordX, unAsiento.CordY, unAsiento.Piso); }
            catch (Exception e) { throw e; }
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
            try { Provider.GetProvider().spUpdateTipoClase(unaClase.idTipoClase, unaClase.NombreClase); }
            catch (Exception e) { throw e; }
            return true;
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
            try { return Provider.GetProvider().spGetAsientoFromID(idAsiento).FirstOrDefault(); }
            catch (Exception e) { throw e; }
        }
        #endregion

        #region Obtener todos los tipos de clases.
        /**
         * @brief Obtiene todos los tipos de clases existentes.
         * 
         * @return Un lista TipoClase si todo salió bien, null caso contrário.
         */
        static public List<TipoClase> GetAllTipoClases()
        {
            try { return Provider.GetProvider().spGetAllTipoClases().ToList(); }
            catch (Exception e) { throw e; }
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
            try { return Provider.GetProvider().spGetAsientosFromAvion(idAvion, Piso).ToList(); }
            catch (Exception e) { throw e; }
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
            try { return Provider.GetProvider().spGetAsientosNoOcupados(idVuelo).ToList(); }
            catch (Exception e) { throw e; }
        }
        #endregion
    }
}
