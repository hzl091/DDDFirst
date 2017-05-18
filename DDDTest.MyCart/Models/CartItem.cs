using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DDDTest.MyCart.Models
{
    public class CartItem
    {
        public Guid CustomerId { get; set; }

        public Guid ProductId { get; set; }
    }
}