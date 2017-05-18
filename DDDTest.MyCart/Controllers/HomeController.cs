using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DDDTest.Core;
using DDDTest.Domain.IProvider;
using DDDTest.ServiceContract;
using DDDTest.Service;
using DDDTest.Data;
using DDDTest.MyCart.Models;
namespace DDDTest.MyCart.Controllers
{
    public class HomeController : Controller
    {
        static readonly IProductService productService = new ProductService(new ProductRepository());
        static readonly IPurchaseService purchaseService = new PurchaseService(new ProductRepository(), new ShoppingCartRepository());

        public ActionResult Index()
        {
            var getProductsResponse = productService.GetProducts(new ServiceContract.Dto.GetProductsRequest { ProductIds = null});
            var getShoppingCartResponse = purchaseService.GetShoppingCart(new ServiceContract.Dto.GetShoppingCartRequest { CustomerId = Guid.Parse("ff28f4e4-1bb6-4471-8205-93d34f438fc1") });
            Sales sales = new Sales();
            sales.Products = getProductsResponse.Products;
            sales.Cart = new ServiceContract.Dto.ShoppingCart();
            sales.Cart.CustomerId = getShoppingCartResponse.CustomerId;
            sales.Cart.Id = getShoppingCartResponse.Id;
            sales.Cart.GoodsTotal = getShoppingCartResponse.GoodsTotal;
            sales.Cart.Items = getShoppingCartResponse.Items;

            return View(sales);
        }

        public ActionResult AddItem(CartItem item)
        {
           var response = purchaseService.AddItem(new ServiceContract.Dto.AddItemRequest {
              ProductId = item.ProductId,
              CustomerId = item.CustomerId
            });

           var cart = new ServiceContract.Dto.ShoppingCart();
           cart.CustomerId = response.CustomerId;
           cart.GoodsTotal = response.GoodsTotal;
           cart.Id = response.Id;
           cart.Items = response.Items;

           return View("_MyCart",cart);
        }
    }
}
