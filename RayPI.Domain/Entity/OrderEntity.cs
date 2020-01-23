using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RayPI.Domain.Common;

namespace RayPI.Domain.Entity
{
    public class OrderEntity : EntityBase
    {
        /// <summary>
        /// 订单类型
        /// </summary>
        public int OrderType { get; set; }

        /// <summary>
        /// 订单类型名称
        /// </summary>
        public string OrderTypeName { get; set; }

        /// <summary>
        /// 桌号
        /// </summary>
        public string DesktopName { get; set; }

        /// <summary>
        /// 就餐人数
        /// </summary>
        public int CustomerCount { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNo { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        public string Operator { get; set; }

        /// <summary>
        /// 下单时间
        /// </summary>
        public string OrderTime { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        public int Status { get; set; }

        public List<OrderDetailEntity> OrderDetails { get; set; }

        public OrderEntity(bool flag)
        {
            if (flag)
            {
                OrderDetails = new List<OrderDetailEntity>();
            }
            Status = (int)OrderStatus.DBC;
        }

        public OrderEntity()
        {

        }

        public bool IsValid()
        {
            if (string.IsNullOrEmpty(OrderNo)) return false;
            if (string.IsNullOrEmpty(OrderTypeName)) return false;
            if (OrderDetails == null || OrderDetails.Count < 1) return false;
            return true;
        }
    }
}
