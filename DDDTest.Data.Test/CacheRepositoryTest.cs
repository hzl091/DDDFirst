using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using DDDTest.Domain;
using DDDTest.Core.Data;
using DDDTest.Data;
namespace DDDTest.Data.Test
{
    [TestClass]
    public class CacheRepositoryTest
    {
        [TestMethod]
        public void Insert_Product_Test()
        {
            Product p1 = new Product();
            p1.Id = Guid.NewGuid();
            p1.Title = "iphone7 plus";
            p1.Price = 6000;
            p1.ImgPath = "http://www.abc.com/static/plus6.jpg";

            Product p2 = new Product();
            p2.Id = Guid.NewGuid();
            p1.Title = "Think Pad";
            p1.Price = 5500;
            p1.ImgPath = "http://www.abc.com/static/pad.jpg";

            IRepository<Product> productRepository = new ProductRepository();
            Assert.AreEqual<bool>(true,productRepository.Insert(p1)); 
            Assert.AreEqual<bool>(false, productRepository.Insert(p1)); //插入重复元素

            Assert.AreEqual<bool>(true, productRepository.Insert(p2));
            Assert.AreEqual<int>(2, productRepository.RS.Count);//比较总记录数
        }


        [TestMethod]
        public void Insert_ShoppingCart_Test()
        {
            Product p1 = new Product();
            p1.Id = Guid.NewGuid();
            p1.Title = "iphone7 plus";
            p1.Price = 6000;
            p1.ImgPath = "http://www.abc.com/static/plus6.jpg";

            Product p2 = new Product();
            p2.Id = Guid.NewGuid();
            p2.Title = "Think Pad";
            p2.Price = 5500;
            p2.ImgPath = "http://www.abc.com/static/pad.jpg";

            ShoppingCart cart = new ShoppingCart();
            cart.Id = Guid.NewGuid();
            cart.CustomerId = Guid.NewGuid();
            cart.AddItem(p1.Id,p1.Price, 1);
            cart.AddItem(p2.Id,p2.Price, 2);

            IRepository<ShoppingCart> shoppingCartRepository = new ShoppingCartRepository();
            Assert.AreEqual<bool>(true, shoppingCartRepository.Insert(cart));
            Assert.IsNotNull(shoppingCartRepository.GetById(cart.Id));
        }
    }
}
