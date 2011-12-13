using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Objects;

namespace DataLayer
{
    class DALUsuario
    {
        #region Agregar Usuario
        /**
         * @brief Agrega un nuevo usuario a la base de datos
         * 
         * @param Usuario        Un usuario que se desea agregar
         * 
         * @return True si se pudo insertar, y false si no se pudo insertar.
         * 
         * @remark el idUsuario NO necesita estar inicializado, este se genera automáticamenta.
         */
        static public void Create(Usuario user)
        {
            try
            {
                Provider.GetProvider().spNewUsuario(user.idNivel, user.Nombre, user.Login, user.Password, user.isActive);
            }
            catch (Exception e) { throw e; }
        }
        #endregion

        #region Actualizar usuario
        /**
         * @brief Actualiza un nuevo usuario de la base de datos
         * 
         * @param user          Usuarios con sus datos inicializados
         * 
         * @return True si se pudo actualizar, y false si no se pudo actualizar.
         * 
         * @warning El idUsuario DEBE estar incializado
         */
        static public void UpdateUsuario(Usuario user)
        {  
            try
            {
                Provider.GetProvider().spUpdateUsuario(user.idUsuario, user.idNivel, user.Nombre, user.Login, user.Password, user.isActive);
            }
            catch (Exception e) { throw e; }
        }
        #endregion

        #region Obtener un usuario dado un ID
        /**
         * @brief Obtiene un usuario dado un ID
         * 
         * @param idUsuario     ID del usuario que se desea obtener
         * 
         * @return Un usuario si se encontró y NULL si no se encontró
         */
        static public Usuario GetUsuarioFromID(int idUsuario)
        {
            try
            {
                return Provider.GetProvider().spGetUsuarioFromID(idUsuario).FirstOrDefault();
            }
            catch (Exception e) { throw e; }
        }
        #endregion

        #region Obtener usuario dado login
        /**
         * @brief Obtiene un usuario dado un login
         * 
         * @param login     login del usuario
         * 
         * @return Un usuario si se encontró y NULL si no se encontró
         */
        static public Usuario GetUsuarioFromLogin(string login)
        {
            try { return Provider.GetProvider().spGetUsuarioFromLogin(login).FirstOrDefault(); }
            catch (Exception e) { throw e; }
        }
        #endregion

        #region Obtener todos niveles de usuario
        /**
        * @brief Obtiene todos los niveles de usuarios disponibles
        *
        * @return Lista con todos los niveles de usuario si todo salió bien, NULL en caso contrário.
        */
       static  public List<NivelUsuario> GetAllNivelUsuario()
        {
            try { return Provider.GetProvider().spGetAllNivelUsuario().ToList(); }
            catch (Exception e) { throw e; }
        }
        #endregion

        #region Obtener un Nivel de usuario dado un ID
        /**
         * @brief Obtiene el nombre de un nivel de usuario dado un ID
         * 
         * @param idNivel       el ID del nivel de usuario
         * 
         * @return Tabla NivelUsuario si se encontró o NULL caso contrário.
         */
        static NivelUsuario GetNivelUsuarioFromID(int idNivel)
        {
            try { return Provider.GetProvider().spGetNivelUsuarioFromID(idNivel).FirstOrDefault(); }
            catch (Exception e) { throw e; }
        }
        #endregion
    }
}
