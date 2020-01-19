using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BeetleX;
using BeetleX.EventArgs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace RayPI.OpenApi
{
    public class MTBackgroundService : BackgroundService
    {
        private ServerOptions serverOptions;
        //private IServerHandler serverHandler;
        private ILogger<MTBackgroundService> logger;
        private IServiceProvider serviceProvider;
        public MTBackgroundService(ILogger<MTBackgroundService> logger, IServiceProvider services)
        {
            this.logger = logger;
            serverOptions = new ServerOptions();
            serverOptions.BufferSize = 102400;
            serverOptions.Port = 9100;
            serverOptions.LogLevel = LogType.Info;
            serviceProvider = services;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            logger.LogWarning("监听服务启动");
            return base.StartAsync(cancellationToken);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var handler = scope.ServiceProvider.GetRequiredService<IServerHandler>();
                IServer server = SocketFactory.CreateTcpServer(handler, null, serverOptions);
                server.Open();

                logger.LogWarning(server.ToString());
            }
            return Task.FromResult(0);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogWarning("监听服务关闭");
            return base.StopAsync(cancellationToken);
        }
    }
}
