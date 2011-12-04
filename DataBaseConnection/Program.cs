using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBaseConnection
{
    class Program
    {
        static void Main(string[] args)
        {
            DALUsuario UserConnect = new DALUsuario() ;
            Usuario unUsuario = UserConnect.GetUsuarioFromLogin("jmoreno");
        }
    }
}