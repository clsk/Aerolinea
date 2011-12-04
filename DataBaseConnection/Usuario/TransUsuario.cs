using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBaseConnection
{
    public class TransUsuario
    {
        Usuario persUser;

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

        public int NivelAcceso
        {
            get { return persUser.NivelUsuario.PesoNivel; }
            set { persUser.NivelUsuario.PesoNivel = value; }
        }

        public string NombreNivel
        {
            get { return persUser.NivelUsuario.NombreNivel; }
            set { persUser.NivelUsuario.NombreNivel = value; }
        }

        public void Flush()
        {
        }

        public bool IsValid() { return persUser != null; }
    }
}
