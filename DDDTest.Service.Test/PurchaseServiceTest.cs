using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using DDDTest.Data;
using DDDTest.Domain;
using DDDTest.Domain.IProvider;
using DDDTest.Service;
using DDDTest.ServiceContract;

namespace DDDTest.Service.Test
{
    [TestClass]
    public class PurchaseServiceTest
    {
        IPurchaseService _purchaseService = null;
        private static Guid _customerId = Guid.NewGuid();

        public PurchaseServiceTest()
        {
            this._purchaseService = new PurchaseService(new ProductRepository(), new ShoppingCartRepository());
        }

        [TestMethod]
        public void GetShoppingCart_Test()
        {
            var response = this._purchaseService.GetShoppingCart(new ServiceContract.Dto.GetShoppingCartRequest {
                CustomerId = _customerId
            });

            Assert.IsNotNull(response);
        }
    }
}
