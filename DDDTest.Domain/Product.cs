using DDDTest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDTest.Domain
{
    /// <summary>
    /// 产品信息
    /// </summary>
    public class Product : BaseEntity,IAggregateRoot
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 图片源
        /// </summary>
        public string ImgPath { get; set; }
    }
}
