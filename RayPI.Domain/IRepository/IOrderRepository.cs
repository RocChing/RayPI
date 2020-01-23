using System;
using System.Collections.Generic;
using System.Text;
using RayPI.Domain.Entity;
using RayPI.Domain.Common;

namespace RayPI.Domain.IRepository
{
    public interface IOrderRepository : IBaseRepository<OrderEntity>
    {
        List<OrderEntity> GetOrderList(OrderStatus status);

        long AddOrder(OrderEntity order);
    }
}
