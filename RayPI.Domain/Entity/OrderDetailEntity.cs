using System;
using System.Collections.Generic;
using System.Text;

namespace RayPI.Domain.Entity
{
    public class OrderDetailEntity : BaseEntity
    {
        public long OrderId { get; set; }

        public string GoodsName { get; set; }

        public int Number { get; set; }

        public string Unit { get; set; }
    }
}
