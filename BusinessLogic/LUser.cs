using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataBaseConnection;

namespace BusinessLogic
{
    public class LUser
    {
        public TransUsuario d_usuario;

        public bool Login(string username, string password)
        {
            UsuarioFactory user_factory = new UsuarioFactory();

            if (d_usuario.IsValid())
                return true;
            else
                return false;
        }

        public void Logout()
        {
            d_usuario = null;
        }

        public string Nombre
        {
            get
            {
                return d_usuario.Nombre;
            }
            set
            {
                d_usuario.Nombre = value;
            }
        }

        public int nivel
        {
            get
            {
                return d_usuario.NivelAcceso;
            }
        }

        private static LUser instance;

        static LUser GetInstance()
        {
            if (instance == null)
                instance = new LUser();

            return instance;
        }

        private LUser() { }
    }
}
