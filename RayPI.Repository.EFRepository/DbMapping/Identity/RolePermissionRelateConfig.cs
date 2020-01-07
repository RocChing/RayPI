using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RayPI.Domain.IdentityDomain.Entity;

namespace RayPI.Repository.EFRepository.DbMapping.Identity
{
    public class RolePermissionRelateConfig : EntityBaseTypeConfig<RolePermissionRelateEntity>
    {
        public override void Configure(EntityTypeBuilder<RolePermissionRelateEntity> builder)
        {
            //表名
            builder.ToTable("RolePermissionRelate");

            base.Configure(builder);
        }
    }
}
