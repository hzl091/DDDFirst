using DDDTest.ServiceContract.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DDDTest.Domain.IProvider;
using domain = DDDTest.Domain;
namespace DDDTest.Service.Core
{
    public class GetProductsCore : OptionBase<GetProductsRequest, GetProductsResponse>
    {
        private IProductRepository _productRepository;
        public GetProductsCore(GetProductsRequest request,
            IProductRepository productRepository) 
            : base(request)
        { 
            this._productRepository = productRepository;
        }
        public override void Execute()
        {
            ICollection<domain.Product> products = null;
            if(this.Request.ProductIds == null || this.Request.ProductIds.Count() == 0)
            {
                products = this._productRepository.GetAll();
            }
            else
            {
                products = this._productRepository.GetByIds(Request.ProductIds);
            }

            this.CreateResponse(products);
        }

        private void CreateResponse(ICollection<domain.Product> products)
        {
            this.Response = new ServiceContract.Dto.GetProductsResponse();
            foreach(var item in products)
            {
                this.Response.Products.Add(new ServiceContract.Dto.Product { 
                    Id = item.Id,
                    Title = item.Title,
                    Price = item.Price,
                    ImgPath = item.ImgPath
                });
            }
        }
    }
}
