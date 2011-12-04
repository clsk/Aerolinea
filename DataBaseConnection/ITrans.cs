using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBaseConnection
{
    internal interface ITrans<T>
    {
        T Persistent
        {
            get;
            set;
        }
    }
}
