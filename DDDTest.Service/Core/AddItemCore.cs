using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DDDTest.ServiceContract.Dto;
using DDDTest.Domain.IProvider;
namespace DDDTest.Service.Core
{
    public class AddItemCore : OptionBase<AddItemRequest,AddItemResponse>
    {
        private IShoppingCartRepository _shoppingCartRepository;
        private IProductRepository _productRepository;

        public AddItemCore(AddItemRequest request,
            IShoppingCartRepository shoppingCartRepository,
            IProductRepository productRepository) 
            : base(request)
        { 
            this._shoppingCartRepository = shoppingCartRepository;
            this._productRepository = productRepository;
        }
        public override void Execute()
        {
            var cart = this._shoppingCartRepository.GetCart(this.Request.CustomerId);
            var product = this._productRepository.GetById(this.Request.ProductId);
            if(product == null){throw new Exception(string.Format("product [{0}] not found",this.Request.ProductId));}

            decimal salesPrice = product.Price;
            cart.AddItem(product.Id,product.Price,1);

            this.Response = new AddItemResponse();
            this.Response.CustomerId = cart.CustomerId;
            this.Response.Id = cart.Id;
            this.Response.GoodsTotal = cart.GoodsTotal;
            foreach (var item in cart.Items)
            {
                this.Response.Items.Add(new ShoppingCartItem
                {
                    Id = item.Id,
                    CartId = item.CartId,
                    ProductId = item.ProductId,
                    SalesPrice = item.SalesPrice,
                    Quantity = item.Quantity,
                    ItemTotal = item.ItemTotal
                });
            }
        }
    }
}
