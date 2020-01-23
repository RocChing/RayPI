using System;
using System.Collections.Generic;
using System.Text;
using RayPI.Domain.Common;
using RayPI.Domain.Entity;
using RayPI.Domain.IRepository;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RayPI.Repository.EFRepository.Repository
{
    public class OrderRepository : BaseRepository<OrderEntity>, IOrderRepository
    {
        public OrderRepository(MyDbContext myDbContext) : base(myDbContext)
        {

        }

        public List<OrderEntity> GetOrderList(OrderStatus orderStatus)
        {
            int status = (int)orderStatus;
            return DbContext.Set<OrderEntity>().Include(m => m.OrderDetails).Where(m => m.Status == status && m.IsDeleted == false).OrderByDescending(m => m.CreateTime).ToList();
        }

        public long AddOrder(OrderEntity order)
        {
            if (Any(o => o.OrderNo == order.OrderNo))
            {
                return -1;
            }
            return Add(order);
        }
    }
}
