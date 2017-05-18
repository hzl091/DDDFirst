using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DDDTest.ServiceContract.Dto;
namespace DDDTest.MyCart.Models
{
    public class Sales
    {
        public ICollection<Product> Products { get; set; }
        public ShoppingCart Cart { get; set; }
    }
}