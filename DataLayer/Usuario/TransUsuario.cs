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

        public TransUsuario(string nombre, string login, string password, NivelUsuario nivel, bool is_active) : base(null)
        {
            persistent = new Usuario();
            persistent.idUsuario = -1;
            Nombre = nombre;
            Login = login;
            Password = password;
            Nivel = nivel;
            IsActive = is_active;
        }

        public int ID
        {
            get { return persistent.idUsuario;}
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

        public bool IsActive
        {
            get { return persistent.isActive; }
            set { persistent.isActive = value; }
        }

        public bool IsValid() { return persistent != null; }

        public void Flush()
        {
            base.Flush(DALUsuario.UpdateUsuario);
        }

        public void Create()
        {
            base.Flush(DALUsuario.Create);
        }

        public static List<TransUsuario> FromNombre(string nombre)
        {
            return DALUsuario.GetUsuarioFromNombre(nombre).ConvertAll<TransUsuario>(pers => new TransUsuario(pers));
        }
        public static TransUsuario FromLogin(string login)
        {
            return new TransUsuario(DALUsuario.GetUsuarioFromLogin(login));
        }

    }
}
