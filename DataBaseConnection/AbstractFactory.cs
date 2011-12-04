using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBaseConnection
{
    public abstract class AbstractFactory<ProductType, DBType, ParameterType>
    {
        public AbstractFactory(Func<ParameterType, DBType> create_delegate)
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
    public abstract class AbstractFactory<ProductType, DBType> : AbstractFactory<ProductType, DBType, int>
    {
        public AbstractFactory(Func<int, DBType> create_delegate)
            : base(create_delegate)
        { }
    }

}

