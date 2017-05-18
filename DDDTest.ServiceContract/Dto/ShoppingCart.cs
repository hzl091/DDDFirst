using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDTest.ServiceContract.Dto
{
    public class ShoppingCart
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public ICollection<ShoppingCartItem> Items { get; set; }

        public decimal GoodsTotal{ get; set; }
    }
}
