using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDTest.Domain
{
    public class ShoppingCartFactory
    {
        public static ShoppingCart Create(Guid customerId)
        {
            return new ShoppingCart {  Id = Guid.NewGuid(), CustomerId = customerId};
        }
    }
}
