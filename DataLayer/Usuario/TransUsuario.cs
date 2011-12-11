using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public class TransUsuario : IUsuario
    {
        Usuario persUser;

        public TransUsuario(Usuario persistent)
        {
            persUser = persistent;
        }

        public int ID
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

        public NivelUsuario Nivel
        {
            get { return persUser.NivelUsuario; }
            set { persUser.NivelUsuario = value; }
        }

        public void Flush()
        {

        }

        public bool IsValid() { return persUser != null; }
    }
}
