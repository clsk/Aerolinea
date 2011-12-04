using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBaseConnection
{
    public class TransUsuario :IUsuario
    {
        NivelUsuario persNivel;
        Usuario persUser;
        public int IdUsuario
        {
            get { return persUser.idUsuario;}
            set { persUser.idUsuario = value; }
        }

        public string Nombre
        {
            get { return persUser.Nombre; }
            set { persUser.Nombre = value; }
        }

        public string Login
        {
            get { return persUser.Login; }
            set { persUser.Login = value; }
        }
        public string Password
        {
            get { return persUser.Password; }
            set { persUser.Password = value; }
        }

        public int Nivel
        {
            get { return persUser.idNivel; }
            set { persUser.idNivel = value; }
        }

        public string NombreNivel
        {
            get { return persNivel.NombreNivel; }
            set { persNivel.NombreNivel = value; }
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
    }
}
