using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBaseConnection
{
    class UsuarioBuilder : AbstractBuilder<TransUsuario, Usuario>
    {
        public UsuarioBuilder()
            : base(DALUsuario.GetUsuarioFromID)
        {
        }
    }

    class UsuarioLoginBuilder : AbstractBuilder<TransUsuario, Usuario, string>
    {
        public UsuarioLoginBuilder()
            : base(DALUsuario.GetUsuarioFromLogin)
        {
        }
    }
}
