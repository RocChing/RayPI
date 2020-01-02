using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RayPI.Domain.Entity.Identity;

namespace RayPI.Repository.EFRepository.DbMapping.Identity
{
    public class RoleConfig : EntityBaseTypeConfig<RoleEntity>
    {
        public override void Configure(EntityTypeBuilder<RoleEntity> builder)
        {
            //表名
            builder.ToTable("Role");

            base.Configure(builder);
        }
    }
}
