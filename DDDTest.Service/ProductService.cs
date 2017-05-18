using DDDTest.Domain.IProvider;
using DDDTest.Service.Core;
using DDDTest.ServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dto = DDDTest.ServiceContract.Dto;

namespace DDDTest.Service
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }
        public dto.AddProductResponse AddProduct(dto.AddProductRequest request)
        {
            AddProductCore core = new AddProductCore(request, this._productRepository);
            core.Execute();
            var response = core.Response;
            return response;
        }

        public dto.GetProductsResponse GetProducts(dto.GetProductsRequest request)
        {
            GetProductsCore core = new GetProductsCore(request, this._productRepository);
            core.Execute();
            var response = core.Response;
            return response;
        }
    }
}
