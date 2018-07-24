using System;
using System.Text;
using Autofac;
using Microsoft.Extensions.Logging;
using Surging.Core.Caching.Configurations;
using Surging.Core.CPlatform;
using Surging.Core.CPlatform.Configurations;
using Surging.Core.CPlatform.Utilities;
using Surging.Core.ProxyGenerator;
using Surging.Core.ServiceHosting;
using Surging.Core.ServiceHosting.Internal.Implementation;
using Tax.Services.Server;
//using Surging.Core.EventBusKafka;
//using Surging.Core.Zookeeper;
//using Surging.Core.Zookeeper.Configurations;

namespace Surging.Services.Server
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var host = new ServiceHostBuilder()
                .RegisterServices(builder =>
                {
                    builder.AddMicroService(option =>
                    {
                        option.AddServiceRuntime()
                            .AddRelateService()
                            .AddConfigurationWatch()
                            //option.UseZooKeeperManager(new ConfigInfo("127.0.0.1:2181")); 
                            .AddServiceEngine(typeof(SurgingServiceEngine));
                        builder.Register(p => new CPlatformContainer(ServiceLocator.Current));
                    });
                })
                .ConfigureLogging(logger =>
                {
                    logger.AddConfiguration(
                        AppConfig.GetSection("Logging"));
                })
                .UseServer(options => { })
                .UseConsoleLifetime()
                .Configure(build =>
                    build.AddCacheFile("${cachepath}|cacheSettings.json", false, true))
                .Configure(build =>
                    build.AddCPlatformFile("${surgingpath}|surgingSettings.json", false, true))
                .UseStartup<Startup>()
                .Build();

            using (host.Run())
            {
                // ReSharper disable once LocalizableElement
                Console.WriteLine($"服务端启动成功，{DateTime.Now}。");
            }
        }
    }
}