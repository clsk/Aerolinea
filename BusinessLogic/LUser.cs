using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer;

namespace BusinessLogic
{
    public class LUser
    {
        public IUsuario d_usuario;

        public bool Login(string username, string password)
        {

            UsuarioLoginFactory factory = new UsuarioLoginFactory();
            factory.BuildProduct(username);

            d_usuario = factory.GetProduct();

            if (d_usuario.IsValid())
                return d_usuario.Password == password;
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

        public int Nivel
        {
            get
            {
                return d_usuario.Nivel.PesoNivel;
            }
        }

        public string NombreNivel
        {
            get
            {
                return d_usuario.Nivel.NombreNivel;
            }
        }

        public bool IsActive
        {
            get
            {
                return d_usuario.IsActive;
            }
        }

        private static LUser instance;

        public static LUser GetInstance()
        {
            if (instance == null)
                instance = new LUser();

            return instance;
        }

        private LUser() { }
    }
}
