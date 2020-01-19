using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RayPI.Repository.EFRepository
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MyDbContext>
    {
        public MyDbContext CreateDbContext(string[] args)
        {
            //IConfigurationRoot configuration = new ConfigurationBuilder()
            //            .SetBasePath(Directory.GetCurrentDirectory())
            //            .Build();
            //Data Source=D:\GitHub\RayPI\RayPI.OpenApi\App_Data\MTS.db3
            var builder = new DbContextOptionsBuilder();
            builder.UseSqlite(@"Data Source=D:\GitHub\RayPI\RayPI.OpenApi\App_Data\MTS.db3");
            return new MyDbContext(builder.Options);
        }
    }
}
