using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RayPI.Domain.Entity;

namespace RayPI.Repository.EFRepository.DbMapping
{
    public class OrderConfig : EntityBaseTypeConfig<OrderEntity>
    {
        public override void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            base.Configure(builder);

            builder.ToTable("T_Order");

            builder.Property(m => m.OrderNo).HasMaxLength(100).IsRequired();
            builder.Property(m => m.OrderType).IsRequired();
            builder.Property(m => m.OrderTypeName).HasMaxLength(100).IsRequired();
            builder.Property(m => m.Operator).HasMaxLength(100);
            builder.HasMany(m => m.OrderDetails).WithOne().HasForeignKey(m => m.OrderId).IsRequired();
        }
    }
}
