using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDTest.ServiceContract.Dto
{
    public class ShoppingCartItem
    {
        public Guid Id { get; set; }

        public Guid CartId { get; set; }

        public Guid ProductId { get; set; }
        
        public int Quantity { get; set; }

        public decimal SalesPrice { get; set; }

        public decimal ItemTotal { get; set; }
    }
}
