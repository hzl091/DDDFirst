using DDDTest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDTest.Domain
{
    public class ShoppingCart : BaseEntity,IAggregateRoot
    {
        private decimal _goodsTotal = 0m;
        public ShoppingCart()
        {
            Items = new List<ShoppingCartItem>();
        }

        #region Properties

        public Guid CustomerId { get; set; }
        public ICollection<ShoppingCartItem> Items { get; private set; }

        /// <summary>
        /// 购物车商品总价值
        /// </summary>
        public decimal GoodsTotal
        {
            get
            {
                this._goodsTotal = this.Items.Sum(item => item.ItemTotal);
                return this._goodsTotal;
            }
            private set
            {
                this._goodsTotal = value;
            }
        }
        #endregion

        #region Methods
        public void AddItem(Guid productId, decimal salesPrice, int quantity)
        {
            // 如果该产品ID已经存在于购物车中，我们直接更改数量即可
            var cartItem = Items.FirstOrDefault(
                i => i.ProductId == productId);

            if (cartItem != null)
            {
                cartItem.Quantity += quantity;
                return;
            }

            Items.Add(new ShoppingCartItem
            {
                Id = Guid.NewGuid(),
                CartId = this.Id,
                ProductId = productId,
                Quantity = quantity,
                SalesPrice = salesPrice
            });
        }

        // 更改购物车产品数量
        public void EditQty(Guid productId, int newQuantity)
        {
            var items = Items as ICollection<ShoppingCartItem>;
            var existingCartItem = items.FirstOrDefault(
                i => i.ProductId == productId);

            if (existingCartItem == null)
            {
                throw new InvalidOperationException(
                    "Cannot find the product in shopping cart");
            }
            existingCartItem.Quantity = newQuantity;
        }

        // 从购物车中移除该产品
        public void RemoveItem(Guid productId)
        {
            var items = Items as ICollection<ShoppingCartItem>;
            var existingCartItem = items.FirstOrDefault(
                i => i.ProductId == productId);

            if (existingCartItem == null)
            {
                throw new InvalidOperationException(
                    "Cannot find the product in shopping cart");
            }

            items.Remove(existingCartItem);
        }
        #endregion
    }
}
