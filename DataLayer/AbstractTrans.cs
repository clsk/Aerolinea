using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{

    public class AbstractTrans<PersistentType>
    {
        public AbstractTrans(PersistentType persistent_object)
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
                if (persistent != null)
                    update_delegate(persistent);
                else
                {
                    Exception ex = new Exception("persistent object is null");
                    throw ex;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
