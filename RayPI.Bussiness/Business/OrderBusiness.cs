using System;
using System.Collections.Generic;
using System.Text;
using RayPI.Domain.Entity;
using RayPI.Domain.IRepository;
using RayPI.Domain.Common;
using System.Linq;

namespace RayPI.Business
{
    public class OrderBusiness
    {
        private IOrderRepository orderRepository;
        public OrderBusiness(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public bool Add(OrderEntity order)
        {
            long id = orderRepository.AddOrder(order);
            return id > 0;
        }

        public List<OrderEntity> GetOrderList(OrderStatus orderStatus)
        {
            return orderRepository.GetOrderList(orderStatus);
        }

        public List<OrderEntity> GetOrderList(OrderEntity order)
        {
            Add(order);
            return orderRepository.GetOrderList(OrderStatus.DBC);
        }
    }
}
