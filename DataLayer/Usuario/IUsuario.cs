using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
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

        NivelUsuario Nivel
        {
            get;
            set;
        }

        void Flush();

        bool IsValid();

    }
}
