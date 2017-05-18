using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDDTest.ServiceContract.Dto;

namespace DDDTest.ServiceContract
{
    public interface IProductService
    {
        AddProductResponse AddProduct(AddProductRequest request);
        GetProductsResponse GetProducts(GetProductsRequest request);
    }
}
