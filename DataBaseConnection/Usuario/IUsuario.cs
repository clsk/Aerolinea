using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBaseConnection
{
    interface IUsuario
    {
        int IdUsuario
        {
            get;
            set;
        }

        string Nombre
        {
            get;
            set;
        }

        string Login
        {
            get;
            set;
        }
        string Password
        {
            get;
            set;
        }

        int Nivel
        {
            get;
            set;
        }

        string NombreNivel
        {
            get;
        }

        void Flush();

    }
}
