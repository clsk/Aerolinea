using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Objects;

namespace DataBaseConnection
{
    class DALUsuario
    {
        ReservaVuelosEntities context;
        public DALUsuario()
        {
            context = new ReservaVuelosEntities();
        }
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
        public bool CreateUsuario(Usuario user)
        {
            try
            {
                context.spNewUsuario(user.idNivel, user.Nombre, user.Login, user.Password, user.isActive);
            }
            catch
            {
                return false;
            }
            return true;
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
        public bool UpdateUsuario(Usuario user)
        {  
            try
            {
                context.spUpdateUsuario(user.idUsuario, user.idNivel, user.Nombre, user.Login, user.Password, user.isActive);
            }
            catch
            {
                return false;
            }
            return true;
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
        public Usuario GetUsuarioFromID(int idUsuario)
        {
            try
            {
                return context.spGetUsuarioFromID(idUsuario).FirstOrDefault();
            }
            catch
            {
                return null;
            }
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

        public Usuario GetUsuarioFromLogin(string login)
        {
            try
            {
                return context.spGetUsuarioFromLogin(login).FirstOrDefault();
            }
            catch
            {
                return null;
            }
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
            ReservaVuelosEntities whatever = new ReservaVuelosEntities();
            try
            {
                return whatever.spGetAllNivelUsuario().ToList();
            }
            catch
            {
                return null;
            }
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
        public NivelUsuario GetNivelUsuarioFromID(int idNivel)
        {
            try
            {
                return context.spGetNivelUsuarioFromID(idNivel).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }
        #endregion
    }
}
