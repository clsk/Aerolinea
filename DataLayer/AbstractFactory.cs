using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public abstract class AbstractFactory<InterfaceType, ProductType, DBType, ParameterType> where ProductType : InterfaceType 
    {
        public AbstractFactory(Func<ParameterType, DBType> create_delegate)
        {
            create_function = create_delegate;
        }
  
        virtual public void BuildProduct(ParameterType constraint) 
        {
            DBType db_type = create_function(constraint);
            product = (ProductType)Activator.CreateInstance(typeof(ProductType), db_type);
        }

        public InterfaceType GetProduct()
        {
            return (InterfaceType)product;
        }

        protected ProductType product;
        protected Func<ParameterType, DBType> create_function;
    }

    // Specialize default type (int)
    public abstract class AbstractFactory<InterfaceType, ProductType, DBType> : AbstractFactory<InterfaceType, ProductType, DBType, int> where ProductType : InterfaceType
    {
        public AbstractFactory(Func<int, DBType> create_delegate)
            : base(create_delegate)
        { }
    }

}

