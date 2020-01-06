using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using RayPI.Infrastructure.Treasury.Di;

namespace RayPI.Domain
{
    public static class ConfigureServicesExtension
    {
        public static IServiceCollection AddDomainService(this IServiceCollection services)
        {
            Assembly domainAssembly = Assembly.GetExecutingAssembly();
            services.AddAssemblyServices(domainAssembly, x => x.Name.EndsWith("DomainService"));
            return services;
        }
    }
}
