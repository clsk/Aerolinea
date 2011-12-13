using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public interface ITrans<PersistentType>
    {
        int ID
        {
            get;
        }

        PersistentType PersistentObject
        {
            get;
        }

        void Flush();
        void Create();
    }
}
