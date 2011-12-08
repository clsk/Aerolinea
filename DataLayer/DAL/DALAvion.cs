using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{

    class DALAvion
    {
        #region Crear una marca de avión
        /**
         * @brief Crea una marca de avión.
         * 
         * @param unaMarca          La marca de avión que será creada.
         * 
         * @return true si se pudo crear y false caso contrário.
         * 
         * @remarks el idMarcaAvion no tiene que estár inicializado.
         */
        static public bool CreateMarcaAvion(MarcaAvion unaMarca)
        {
            try { Provider.GetProvider().spNewMarcaAvion(unaMarca.NombreMarca); }
            catch {return false; }
            return true;
        }
        #endregion

        #region Crear una serie de avión.
        /**
         * @brief Crea una serie de avión.
         * 
         * @param unaSerie         La serie de avión que será creada.
         * 
         * @return true si se pudo crear y false caso contrário.
         * 
         * @remarks el idSerieAvion no tiene que estár inicializado.
         */
        static public bool CreateSerieAvion(SerieAvion unaSerie)
        {
            try { Provider.GetProvider().spNewSerieAvion(unaSerie.NombreSerie, unaSerie.idMarca); }
            catch {return false; }
            return true;
        }
        #endregion

        #region Crear un avión.
        /**
         * @brief Crea un avión.
         * 
         * @param unAvion         El avión que será creado,
         * 
         * @return true si se pudo crear y false caso contrário.
         * 
         * @remarks el idAvion no tiene que estár inicializado.
         */
        static public bool Create(Avion unAvion)
        {
            try { Provider.GetProvider().spNewAvion(unAvion.idSerie); }
            catch {return false; }
            return true;
        }
        #endregion

        #region Crear planta de avión
        /**
         * @brief Crea una planta de avión.
         * 
         * @param unaPlanta        La planta de avión que será creada.
         * 
         * @return true si se pudo crear y false caso contrário.
         * 
         * @remarks el idPlantaAvion no tiene que estár inicializado.
         */
        static public bool CreatePlantaAvion(PlantaAvion unaPlanta)
        {
            try { Provider.GetProvider().spNewPlanta(unaPlanta.idAvion, unaPlanta.ImagenPlanta, unaPlanta.Piso); }
            catch {return false; }
            return true;
        }
        #endregion

        #region Actualizar una marca de avión.
        /**
         * @brief Actualiza una marca de avión.
         * 
         * @param unaMarca       La marca de avión que será actualizada.
         * 
         * @return true si se pudo actualizar y false caso contrário.
         * 
         * @warning el idMarcaAvion DEBE estár inicializado.
         */
        static public bool UpdateMarcaAvion(MarcaAvion unaMarca)
        {
            try { Provider.GetProvider().spUpdateMarcaAvion(unaMarca.idMarca, unaMarca.NombreMarca); }
            catch {return false; }
            return true;
        }
        #endregion

        #region Actualizar una serie de avión.
        /**
         * @brief Actualiza una serie de avión.
         * 
         * @param unaSerie       La serie de avión que será actualizada.
         * 
         * @return true si se pudo actualizar y false caso contrário.
         * 
         * @warning el idSerieAvion DEBE estár inicializado.
         */
        static public bool UpdateSerieAvion(SerieAvion unaSerie)
        {
            try { Provider.GetProvider().spUpdateSerieAvion(unaSerie.idMarca, unaSerie.NombreSerie, unaSerie.idMarca); }
            catch {return false; }
            return true;
        }
        #endregion

        #region Actualizar un avión.
        /**
         * @brief Actualiza una marca de avión.
         * 
         * @param unaMarca       La marca de avión que será actualizada.
         * 
         * @return true si se pudo actualizar y false caso contrário.
         * 
         * @warning el idMarcaAvion DEBE estár inicializado.
         */
        static public bool UpdateAvion(Avion unAvion)
        {
            try { Provider.GetProvider().spUpdateAvion(unAvion.idAvion, unAvion.idSerie); }
            catch {return false; }
            return true;
        }
        #endregion

        #region Actualizar una planta de avión.
        /**
         * @brief Actualiza una plnta de avión.
         * 
         * @param unaPlanta       La planta de avión que será actualizada.
         * 
         * @return true si se pudo actualizar y false caso contrário.
         * 
         * @warning el idPlantaAvion DEBE estár inicializado.
         */
        static public bool UpdatePlantaAvion(PlantaAvion unaPlanta)
        {
            try { Provider.GetProvider().spUpdatePlanta(unaPlanta.idPlanta, unaPlanta.idAvion, unaPlanta.ImagenPlanta, unaPlanta.Piso); }
            catch {return false; }
            return true;
        }
        #endregion

        #region Obtener todas las marcas de avión.
        /**
         * @brief Obtiene todas las marcas de avión.
         * 
         * @return Una lista de marca de avión si todo salió bien y null caso contrário.
         */
        static public List<MarcaAvion> GetAllMarcaAvion()
        {
            try { return Provider.GetProvider().spGetAllMarcaAvion().ToList(); }
            catch { return null; }
        }
        #endregion

        #region Obtener todas las series de avión dado una marca.
        /**
         * @brief Obtiene todas las series de avión dado una marca de avión.
         * 
         * @param idMarca               el ID dado para la marca del avión.
         * 
         * @return Una lista de serie de avión si todo salió bien y null caso contrário.
         */
        static public List<SerieAvion> GetSerieAvionFromMarcaAvion(int idMarca)
        {
            try { return Provider.GetProvider().spGetSerieAvionFromMarca(idMarca).ToList(); }
            catch { return null; }
        }
        #endregion

        #region Obtener todos los aviones dado una serie.
        /**
         * @brief Obtiene todas los aviones dado una serie de avión.
         * 
         * @param idSerie               el ID dado para la serie del avión.
         * 
         * @return Una lista de avión si todo salió bien y null caso contrário.
         */
        static public List<Avion> GetAvionFromSerieAvion(int idSerie)
        {
            try { return Provider.GetProvider().spGetAvionesFromSerie(idSerie).ToList(); }
            catch { return null; }
        }
        #endregion

        #region Obtener un avión dado un ID
        /**
         * @brief Obtiene un avión dado un idAvion.
         * 
         * @param idAvion               el ID del avión.
         * 
         * @return Un avión si todo salió bien y null caso contrário.
         */
        static public Avion GetAvionFromID(int idAvion)
        {
            try { return Provider.GetProvider().spGetAvionFromID(idAvion).FirstOrDefault(); }
            catch { return null; }
        }
        #endregion

        #region Obtener las plantas de avión, dado un avión.
        /**
         * @brief Obtiene todas las plantas de un avión, dado un avión.
         * 
         * @param idAvion               el ID del avión.
         * 
         * @return Una lista de plantas de avión si todo salió bien y null caso contrário.
         */
        static public List<PlantaAvion> GetPlantaAvionFromAvion(int idAvion)
        {
            try { return Provider.GetProvider().spGetPlantasFromAvion(idAvion).ToList(); }
            catch { return null; }
        }
        #endregion
    }
}
