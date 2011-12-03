using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBaseConnection
{
    class TransUsuario :IUsuario
    {
         public int IdUsuario
        {
            get;
            set;
        }

        public string Nombre
        {
            get;
            set;
        }

        public string Login
        {
            get;
            set;
        }
        public string Password
        {
            get;
            set;
        }

        public int Nivel
        {
            get;
            set;
        }

        public string NombreNivel
        {
            get;
            set;
        }

        public void Flush()
        {
        }

        public TransUsuario(int idUsuario)
        {
        }

        public TransUsuario(string login, string password)
        {

        }

        public bool IsValid() { return persUser != null; }

        internal TransUsuario(Usuario User, NivelUsuario UserNivel)
        {
            persUser = User;
            persNivel = UserNivel;
        }

        Usuario persUser;
        
        NivelUsuario persNivel;

    }
}
