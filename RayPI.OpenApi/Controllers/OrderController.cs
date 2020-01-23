using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RayPI.Domain.Common;
using RayPI.Domain.Entity;
using RayPI.Business;

namespace RayPI.OpenApi.Controllers
{
    /// <summary>
    /// 订单接口
    /// </summary>
    [Produces("application/json")]
    [Route("api/Order")]
    public class OrderController : Controller
    {
        private OrderBusiness orderBusiness;
        public OrderController(OrderBusiness orderBusiness)
        {
            this.orderBusiness = orderBusiness;
        }

        [HttpGet]
        [Route(nameof(GetOrderList))]
        public List<OrderEntity> GetOrderList(OrderStatus status)
        {
            return orderBusiness.GetOrderList(status);
        }

        [HttpPost]
        [Route(nameof(Add))]
        public bool Add([FromBody] OrderEntity order)
        {
            return orderBusiness.Add(order);
        }
    }
}