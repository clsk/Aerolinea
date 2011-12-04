using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBaseConnection
{
    abstract class AbstractBuilder<ProductType, DBType> where ProductType : ITrans<DBType>, new()
    {
        public AbstractBuilder(Func<int, DBType> create_delegate)
        {
            create_function = create_delegate;
        }
    
  
        virtual public void BuildProduct(int id) 
        {
            DBType db_type = create_function(id);
            product = new ProductType();
            product.Persistent = db_type;
        }

        public ProductType GetProduct()
        {
            return product;
        }

        protected ProductType product;
        protected Func<int, DBType> create_function;
    }
}
