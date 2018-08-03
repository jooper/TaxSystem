using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tax.CompanyModuleService.UnitOfWork;

namespace Tax.CompanyModuleService.DI
{
    public class ServiceDiProvider
    {
        private static IServiceCollection _serviceCollection;
        private static readonly object Lock = new object();

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
//            _serviceCollection.AddEntityFrameworkSqlServer()
//                .AddDbContext<EfDbContext>(options => { options.UseSqlServer(DefaultSqlConnectionString); },
//                    ServiceLifetime.Scoped);
            _serviceCollection.AddEntityFrameworkSqlServer().AddDbContext<EfDbContext>(ServiceLifetime.Scoped);
            _serviceCollection.AddTransient<IEfUnitOfWork, EfUnitOfWork>();
            _serviceCollection.AddTransient<IEfDbContext, EfDbContext>();
//            var serviceProvider = _serviceCollection.BuildServiceProvider();
//                        var efUnitOfWork = serviceProvider.GetService<IEfUnitOfWork>();


 
        }


        public static ServiceProvider GetDiProivder()
        {
            return SingleServiceCollection().BuildServiceProvider();
        }
    }
}