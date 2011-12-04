using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBaseConnection
{
    public class UsuarioFactory : AbstractFactory<TransUsuario, Usuario>
    {
        public UsuarioFactory()
            : base(DALUsuario.GetUsuarioFromID)
        {
        }
    }

    public class UsuarioLoginFactory : AbstractFactory<TransUsuario, Usuario, string>
    {
        public UsuarioLoginFactory()
            : base(DALUsuario.GetUsuarioFromLogin)
        {
        }
    }
}
