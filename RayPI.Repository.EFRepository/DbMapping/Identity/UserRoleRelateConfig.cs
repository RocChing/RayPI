using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RayPI.Domain.Entity.Identity;

namespace RayPI.Repository.EFRepository.DbMapping.Identity
{
    public class UserRoleRelateConfig:EntityBaseTypeConfig<UserRoleRelateEntity>
    {
        public override void Configure(EntityTypeBuilder<UserRoleRelateEntity> builder)
        {
            //表名
            builder.ToTable("UserRoleRelate");

            //基础字段
            base.Configure(builder);
        }
    }
}
