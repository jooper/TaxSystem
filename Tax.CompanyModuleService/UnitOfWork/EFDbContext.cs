using Microsoft.EntityFrameworkCore;
using Tax.ICompanyModuleService.Domain.BaseModel.Models;

namespace Tax.CompanyModuleService.UnitOfWork
{
    class EfDbContext : DbContext
    {
        private static readonly string DefaultSqlConnectionString =
            @"server=192.168.200.200;uid=sa;pwd=123456aA;database=TestSur";
        

        //        private DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(DefaultSqlConnectionString).Options;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DefaultSqlConnectionString,
                    providerOptions => providerOptions.CommandTimeout(160))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            base.OnConfiguring(optionsBuilder);
        }


        public EfDbContext()
        {
        }

        public DbSet<TbCompany> TbCompanys{ set; get; }
//        public DbSet<TbRole> TB_ROLE { set; get; }
//        public DbSet<TbRight> TB_RIGHT { set; get; }
//        public DbSet<TbUserrole> TB_USERROLE { set; get; }
//        public DbSet<TbUser> TB_USER { set; get; }
    }
}