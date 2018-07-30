using System.Runtime.InteropServices.ComTypes;
using Microsoft.EntityFrameworkCore;
using Tax.ICompanyModuleService.Domain.BaseModel.Models;
using Tax.ICompanyModuleService.Domain.Entities;

namespace Tax.CompanyModuleService.UnitOfWork
{
    public class EfDbContext : DbContext
    {
        private static readonly string DefaultSqlConnectionString =
            @"Server=192.168.200.200;database=TestSur;uid=sa;pwd=123456aA";


        //        private DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(DefaultSqlConnectionString).Options;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            var defaultcon = Configuration.GetConnectionString("DefaultConnection");
//            var devcon = Configuration["ConnectionStrings:DevConnection"];
            optionsBuilder.UseSqlServer(DefaultSqlConnectionString,
                    providerOptions => providerOptions.CommandTimeout(160))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Company> Company { set; get; }
        public DbSet<BankAccount> BankAccount { set; get; }
        public DbSet<Customer> Customer { set; get; }

    }
}