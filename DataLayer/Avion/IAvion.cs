using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public interface IAvion
    {
        int ID
        {
            get;
        }

        SerieAvion Serie
        {
            get;
        }
    }
}
