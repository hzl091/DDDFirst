using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDDTest.Domain;
using DDDTest.Domain.IProvider;
using DDDTest.ServiceContract;
using dto = DDDTest.ServiceContract.Dto;
using DDDTest.Service.Core;

namespace DDDTest.Service
{
    public class PurchaseService : IPurchaseService
    {
        private IProductRepository _productRepository;
        private IShoppingCartRepository _shoppingCartRepository;


        public PurchaseService(IProductRepository productRepository,
            IShoppingCartRepository shoppingCartRepository)
        {
            this._productRepository = productRepository;
            this._shoppingCartRepository = shoppingCartRepository;
        }
        public dto.GetShoppingCartResponse GetShoppingCart(dto.GetShoppingCartRequest request)
        {
            GetShoppingCartCore core = new GetShoppingCartCore(request,this._shoppingCartRepository);
            core.Execute();
            var response = core.Response;
            return response;
        }

        public dto.AddItemResponse AddItem(dto.AddItemRequest request)
        {
            AddItemCore core = new AddItemCore(request, this._shoppingCartRepository,this._productRepository);
            core.Execute();
            var response = core.Response;
            return response;
        }

        public dto.EditItemQtyResponse EditItemQty(dto.EditItemQtyRequest request)
        {
            throw new NotImplementedException();
        }

        public dto.RemoveItemResponse RemoveItem(dto.RemoveItemRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
