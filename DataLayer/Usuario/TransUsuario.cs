using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public class TransUsuario : AbstractTrans<Usuario>, IUsuario
    {
        public TransUsuario(Usuario persistent_object)
            : base(persistent_object)
        {
            persistent = persistent_object;
        }

        public int ID
        {
            get { return persistent.idUsuario;}
            set { persistent.idUsuario = value; }
        }

        public string Nombre
        {
            get { return persistent.Nombre; }
            set { persistent.Nombre = value; }
        }

        public string Login
        {
            get { return persistent.Login; }
            set { persistent.Login = value; }
        }
        public string Password
        {
            get { return persistent.Password; }
            set { persistent.Password = value; }
        }

        public NivelUsuario Nivel
        {
            get { return persistent.NivelUsuario; }
            set { persistent.NivelUsuario = value; }
        }

        public bool IsValid() { return persistent != null; }

        public void Flush()
        {
            base.Flush(DALUsuario.UpdateUsuario);
        }
    }
}
