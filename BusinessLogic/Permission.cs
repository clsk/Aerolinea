using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic
{
    public class Permission
    {
        const int ADMIN_LEVEL_PESO = 500;
        const int SUPERVISOR_LEVEL_PESO = 300;
        const int DIGITADOR_LEVEL_PESO = 100;

        public static bool CheckAdmin()
        {
            return Check(LUser.GetInstance().Nivel, ADMIN_LEVEL_PESO);
        }

        public static bool CheckSupervisor()
        {
            return Check(LUser.GetInstance().Nivel, SUPERVISOR_LEVEL_PESO);
        }

        public static bool CheckDigitador()
        {
            return Check(LUser.GetInstance().Nivel, DIGITADOR_LEVEL_PESO);
        }

        internal static bool Check(int level, int minimum_level)
        {
            return level >= minimum_level;
        }
    }
}
