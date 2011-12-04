using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBaseConnection
{
    abstract class AbstractBuilder<ProductType, DBType, DAL>
    {
        virtual public void BuildProduct(int id)
        {
            DBType db_type = DAL.Create(id);
            product = new ProductType(db_type);
        }

        public ProductType GetProduct()
        {
            return product;
        }

        protected ProductType product;
    }
}
