using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public class UsuarioFactory : AbstractFactory<IUsuario, TransUsuario, Usuario>
    {
        public UsuarioFactory()
            : base(DALUsuario.GetUsuarioFromID)
        {
        }

        public UsuarioFactory(Func<int, Usuario> create_delegate)
            : base(create_delegate)
        {
        }
    }

    public class UsuarioLoginFactory : AbstractFactory<IUsuario, TransUsuario, Usuario, string>
    {
        public UsuarioLoginFactory()
            : base(DALUsuario.GetUsuarioFromLogin)
        {
        }

        public UsuarioLoginFactory(Func<string, Usuario> create_delegate)
            : base(create_delegate)
        {
        }
    }
}
