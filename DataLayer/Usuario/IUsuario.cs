using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBaseConnection
{
    public interface IUsuario
    {
        int ID
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

        int NivelAcceso
        {
            get;
            set;
        }

        string NombreNivel
        {
            get;
        }

        void Flush();

        bool IsValid();

    }
}
