using System;
using System.Collections.Generic;
using System.Text;

namespace RayPI.Domain.Entity
{
    public class OrderDetailEntity : BaseEntity
    {
        /// <summary>
        /// 订单ID
        /// </summary>
        public long OrderId { get; set; }

        /// <summary>
        /// 菜品
        /// </summary>
        public string GoodsName { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get; set; }
    }
}
