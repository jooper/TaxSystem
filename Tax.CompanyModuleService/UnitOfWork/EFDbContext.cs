using Microsoft.EntityFrameworkCore;
using Tax.ICompanyModuleService.Domain.BaseModel.Models;

namespace Tax.CompanyModuleService.UnitOfWork
{
    class EfDbContext : DbContext
    {
        private static readonly string DefaultSqlConnectionString =
            @"Data Source=192.168.200.200.;Initial Catalog=TestSur;User ID=sa;Password=123456aA;";

//        private DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(DefaultSqlConnectionString).Options;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(DefaultSqlConnectionString);
            base.OnConfiguring(optionsBuilder);
        }

        public EfDbContext()
        {
        }

        public DbSet<TbCompany> TB_COMPANY { set; get; }
        public DbSet<TbRole> TB_ROLE { set; get; }
        public DbSet<TbRight> TB_RIGHT { set; get; }
        public DbSet<TbUserrole> TB_USERROLE { set; get; }
        public DbSet<TbUser> TB_USER { set; get; }
    }
}