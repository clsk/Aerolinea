using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public interface ITrans<PersistentType>
    {
        PersistentType PersistentObject
        {
            get;
        }

        void Flush();
    }
}
