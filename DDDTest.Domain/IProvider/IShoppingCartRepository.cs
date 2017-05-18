using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDDTest.Core.Data;

namespace DDDTest.Domain.IProvider
{
    public interface IShoppingCartRepository : IRepository<ShoppingCart>
    {
        /// <summary>
        /// 获取指定用户购物车
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <returns></returns>
        ShoppingCart GetCart(Guid customerId);
    }
}
