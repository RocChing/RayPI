using System;
using System.Collections.Generic;
using System.Text;
using RayPI.Domain.Entity;
using RayPI.Domain.IRepository;

namespace RayPI.Repository.EFRepository.Repository
{
    public class OrderRepository : BaseRepository<OrderEntity>, IOrderRepository
    {
        public OrderRepository(MyDbContext myDbContext) : base(myDbContext)
        {

        }
    }
}
