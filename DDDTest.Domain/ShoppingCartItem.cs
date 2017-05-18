using DDDTest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDTest.Domain
{
    public class ShoppingCartItem : BaseEntity
    {
        private decimal _itemTotal = 0m;

        public Guid CartId { get; set; }

        public Guid ProductId { get; set; }
        
        public int Quantity { get; set; }

        public decimal SalesPrice { get; set; }

        public decimal ItemTotal 
        {
            get 
            {
                return this.Quantity * this.SalesPrice;
            }
            private set
            {
                this._itemTotal = value;
            }
        }
    }
}
