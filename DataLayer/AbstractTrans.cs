using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{

    public class AbstractTrans<PersistentType>
    {
        internal AbstractTrans(PersistentType persistent_object)
        {
            persistent = persistent_object;
        }
        protected PersistentType persistent;

        public PersistentType PersistentObject
        {
            get { return persistent; }
        }

        public void Flush(Action<PersistentType> update_delegate)
        {
            try
            {
                update_delegate(persistent);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
