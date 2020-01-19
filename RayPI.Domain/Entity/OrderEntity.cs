using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RayPI.Domain.Entity
{
    public class OrderEntity : EntityBase
    {
        public int OrderType { get; set; }

        public string OrderTypeName { get; set; }

        public string DesktopName { get; set; }

        public int CustomerCount { get; set; }

        public string OrderNo { get; set; }

        public string Operator { get; set; }

        public List<OrderDetailEntity> OrderDetails { get; set; }
    }
}
