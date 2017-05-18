using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain = DDDTest.Domain;
using DDDTest.Domain.IProvider;
using DDDTest.ServiceContract.Dto;

namespace DDDTest.Service.Core
{
    public class AddProductCore : OptionBase<AddProductRequest, AddProductResponse>
    {
        private IProductRepository _productRepository;

        public AddProductCore(AddProductRequest request,
            IProductRepository productRepository) 
            : base(request)
        { 
            this._productRepository = productRepository;
        }
        public override void Execute()
        {
            Guid productId = Guid.NewGuid();
            domain.Product product = new domain.Product {
                Id = productId,
                 Title = this.Request.Title,
                 Price = this.Request.Price,
                 ImgPath = this.Request.ImgPath
            };

            this._productRepository.Insert(product);
            this.Response = new AddProductResponse { ProductId = productId };
        }
    }
}
