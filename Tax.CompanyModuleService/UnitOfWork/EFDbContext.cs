using Microsoft.EntityFrameworkCore;
using Tax.ICompanyModuleService.Domain.BaseModel.Entities;

namespace Tax.CompanyModuleService.UnitOfWork
{
    public interface IEfDbContext
    {
    }

    public class EfDbContext : DbContext, IEfDbContext
    {
        private static readonly string DefaultSqlConnectionString =
            @"Server=192.168.200.200;database=TestSur;uid=sa;pwd=123456aA";

        public DbSet<Company> Company { set; get; }
        public DbSet<BankAccount> BankAccount { set; get; }
        public DbSet<Customer> Customer { set; get; }
        public DbSet<User> User { set; get; }
        public DbSet<UserRole> UserRole { set; get; }
        public DbSet<Role> Role { set; get; }
        public DbSet<RolePower> RowPower { set; get; }

        //private DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(DefaultSqlConnectionString).Options;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            var defaultcon = Configuration.GetConnectionString("DefaultConnection");
//            var devcon = Configuration["ConnectionStrings:DevConnection"];
            optionsBuilder.UseSqlServer(DefaultSqlConnectionString,
                    providerOptions => providerOptions.CommandTimeout(160))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            base.OnConfiguring(optionsBuilder);
        }
    }
}