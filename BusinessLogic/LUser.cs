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
            d_usuario = new TransUsuario(username, password);
            if (d_usuario.IsValid())
                return true;
            else
                return false;
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
                return d_usuario.Nivel;
            }
        }
    }
}
