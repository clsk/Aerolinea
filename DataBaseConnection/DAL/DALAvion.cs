using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBaseConnection
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
            return false;
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
            return false;
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
            return false;
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
            return false;
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
            return false;
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
            return false;
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
            return false;
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
            return false;
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
            return null;
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
            return null;
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
            return null;
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
            return null;
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
            return null;
        }
        #endregion

    }
}
