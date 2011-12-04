using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBaseConnection
{
    abstract class AbstractBuilder<ProductType, DBType, ParameterType>
    {
        public AbstractBuilder(Func<ParameterType, DBType> create_delegate)
        {
            create_function = create_delegate;
        }
  
        virtual public void BuildProduct(ParameterType id) 
        {
            DBType db_type = create_function(id);
            product = (ProductType)Activator.CreateInstance(typeof(ProductType), db_type);
        }

        public ProductType GetProduct()
        {
            return product;
        }

        protected ProductType product;
        protected Func<ParameterType, DBType> create_function;
    }

    // Specialize default type (int)
    abstract class AbstractBuilder<ProductType, DBType> : AbstractBuilder<ProductType, DBType, int>
    {
        public AbstractBuilder(Func<int, DBType> create_delegate)
            : base(create_delegate)
        { }
    }

}

