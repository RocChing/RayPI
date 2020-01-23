using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace RayPI.Infrastructure.EventBus.Di
{
    public static class EventBusDiExtension
    {
        public static IServiceCollection AddEventBusService(this IServiceCollection services)
        {
            services.AddScoped<IEventBus, EventBus>();

            return services;
        }
    }
}
