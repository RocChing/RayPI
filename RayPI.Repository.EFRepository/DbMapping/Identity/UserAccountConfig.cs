using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RayPI.Domain.Entity.Identity;

namespace RayPI.Repository.EFRepository.DbMapping.Identity
{
    public class UserAccountConfig:EntityBaseTypeConfig<UserAccountEntity>
    {
        public override void Configure(EntityTypeBuilder<UserAccountEntity> builder)
        {
            //表名
            builder.ToTable("UserAccount");

            //基础字段
            base.Configure(builder);
        }
    }
}
