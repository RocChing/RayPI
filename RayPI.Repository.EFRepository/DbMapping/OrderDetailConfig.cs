using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using RayPI.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace RayPI.Repository.EFRepository.DbMapping
{
    public class OrderDetailConfig : EntityBaseTypeConfig2<OrderDetailEntity>
    {
        public override void Configure(EntityTypeBuilder<OrderDetailEntity> builder)
        {
            base.Configure(builder);

            builder.ToTable("T_OrderDetail");

            builder.Property(m => m.GoodsName).HasMaxLength(200).IsRequired();
            builder.Property(m => m.Number).IsRequired();
            builder.Property(m => m.Unit).HasMaxLength(50);
        }
    }
}
