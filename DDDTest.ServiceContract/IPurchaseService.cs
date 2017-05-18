using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDDTest.ServiceContract.Dto;

namespace DDDTest.ServiceContract
{
    public interface IPurchaseService
    {
        /// <summary>
        /// 获取购物车，不存在则自动创建
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetShoppingCartResponse GetShoppingCart(GetShoppingCartRequest request);

        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        AddItemResponse AddItem(AddItemRequest request);

        /// <summary>
        /// 编辑商品购买数
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        EditItemQtyResponse EditItemQty(EditItemQtyRequest request);

        /// <summary>
        /// 删除指定商品
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        RemoveItemResponse RemoveItem(RemoveItemRequest request);
    }
}
