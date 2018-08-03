using Microsoft.Extensions.DependencyInjection;
using Tax.CompanyModuleService.UnitOfWork;

namespace Tax.CompanyModuleService.DI
{
    //Lib内部依赖注入模块
    public class ServiceDiProvider
    {
        private static IServiceCollection _serviceCollection;

        private static readonly object Lock = new object();

        public static ServiceProvider GetDiProivder()
        {
//            var efUnitOfWork = serviceProvider.GetService<IEfUnitOfWork>();
            return SingleServiceCollection().BuildServiceProvider();
        }

        private static IServiceCollection SingleServiceCollection()
        {
            if (_serviceCollection == null)
                lock (Lock)
                {
                    if (_serviceCollection == null)
                    {
                        _serviceCollection = new ServiceCollection();
                        DiContext();
                    }
                }

            return _serviceCollection;
        }

        private static void DiContext()
        {
            //迁移到 EF CORE内部去完成连接串的配置
//            _serviceCollection.AddEntityFrameworkSqlServer()
//                .AddDbContext<EfDbContext>(options => { options.UseSqlServer(DefaultSqlConnectionString); },
//                    ServiceLifetime.Scoped);
            _serviceCollection.AddEntityFrameworkSqlServer().AddDbContext<EfDbContext>(ServiceLifetime.Scoped);
            _serviceCollection.AddTransient<IEfUnitOfWork, EfUnitOfWork>();
            _serviceCollection.AddTransient<IEfDbContext, EfDbContext>();
        }
    }
}