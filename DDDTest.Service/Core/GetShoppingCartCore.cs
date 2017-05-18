using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDDTest.ServiceContract.Dto;
using DDDTest.Domain.IProvider;

namespace DDDTest.Service.Core
{
    public class GetShoppingCartCore :OptionBase<GetShoppingCartRequest,GetShoppingCartResponse>
    {
        IShoppingCartRepository _shoppingCartRepository;
        public GetShoppingCartCore(GetShoppingCartRequest request,IShoppingCartRepository shoppingCartRepository)
            : base(request)
        {
            this._shoppingCartRepository = shoppingCartRepository;
        }
        public override void Execute()
        {
            var cart = this._shoppingCartRepository.GetCart(this.Request.CustomerId);
            this.Response = new GetShoppingCartResponse();
            this.Response.CustomerId = cart.CustomerId;
            this.Response.Id = cart.Id;
            this.Response.GoodsTotal = cart.GoodsTotal;
            foreach(var item in cart.Items)
            {
                this.Response.Items.Add(new ShoppingCartItem { Id = item.Id,
                    CartId = item.CartId,
                    ProductId = item.ProductId,
                    SalesPrice = item.SalesPrice,
                    Quantity = item.Quantity,
                    ItemTotal = item.ItemTotal });    
            }
        }
    }
}
