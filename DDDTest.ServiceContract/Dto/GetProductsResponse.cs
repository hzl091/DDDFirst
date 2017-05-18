using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDTest.ServiceContract.Dto
{
    public class GetProductsResponse
    {
        public GetProductsResponse()
        {
            this.Products = new List<Product>();
        }

        public ICollection<Product> Products { get; set; }
    }
}
