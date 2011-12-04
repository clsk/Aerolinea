using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBaseConnection
{
    public class Provider
    {
        private ReservaVuelosEntities _provider;
        private static Provider _unique = null;
        private Provider()
        {
            if (_unique == null)
            {
                _provider = new ReservaVuelosEntities();
                _unique = this;
            }
        }

        public static ReservaVuelosEntities GetProvider()
        {
            if (_unique == null)
                _unique = new Provider();
            return _unique._provider;
        }
    }
}
