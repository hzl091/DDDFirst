using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DDDTest.Domain;
using DDDTest.Domain.IProvider;
namespace DDDTest.Data
{
    public class ShoppingCartRepository : RepositoryBase<ShoppingCart>,IShoppingCartRepository
    {
        public ShoppingCart GetCart(Guid customerId)
        {
            var cart = this.RS.Where(item => item.CustomerId == customerId).FirstOrDefault();
            if (cart == null)
            {
                cart = ShoppingCartFactory.Create(customerId);
                this.RS.Add(cart);
            }
            return cart;
        }
    }
}
