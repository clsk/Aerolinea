using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBaseConnection
{
    class UsuarioFactory : AbstractFactory<TransUsuario, Usuario>
    {
        public UsuarioFactory()
            : base(DALUsuario.GetUsuarioFromID)
        {
        }
    }

    class UsuarioLoginFactory : AbstractFactory<TransUsuario, Usuario, string>
    {
        public UsuarioLoginFactory()
            : base(DALUsuario.GetUsuarioFromLogin)
        {
        }
    }
}
