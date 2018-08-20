using Microsoft.EntityFrameworkCore;
using Tax.CompanyModuleService.Ext;
using Tax.ICompanyModuleService.Domain.BaseModel.Entities;

namespace Tax.CompanyModuleService.UnitOfWork
{
    public interface IEfDbContext
    {
    }

    public class EfDbContext : DbContext, IEfDbContext
    {
        private static readonly string DefaultSqlConnectionString =
            @"Server=192.168.200.200;database=Tax;uid=sa;pwd=123456aA";

        public DbSet<Company> Companies { set; get; }
        public DbSet<Shareholder> Shareholders { set; get; }
        public DbSet<BankAccount> BankAccounts { set; get; }
        public DbSet<Customer> Customers { set; get; }
        public DbSet<User> Users { set; get; }
        public DbSet<UserRole> UserRoles { set; get; }
        public DbSet<Role> Roles { set; get; }
        public DbSet<RolePower> RolePowers { set; get; }

        public DbSet<TaxList> TaxLists { set; get; }
        //private DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(DefaultSqlConnectionString).Options;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //            var defaultcon = Configuration.GetConnectionString("DefaultConnection");
            //            var devcon = Configuration["ConnectionStrings:DevConnection"];
            optionsBuilder.UseSqlServer(DefaultSqlConnectionString,
                    providerOptions => providerOptions.CommandTimeout(160))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
//            optionsBuilder.UseLazyLoadingProxies();


            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
//            modelBuilder.Entity<Company>().HasMany(m => m.Shareholders).WithOne(p => p.Company)
//                .HasForeignKey(p => p.CompanyId);

//            modelBuilder.Entity<Shareholder>()
//                .HasOne(p => p.Company)
//                .WithMany(b => b.Shareholders);

//            modelBuilder.Entity<Post>().HasOne("Body").WithOne("Post").HasForeignKey("PostId");
//            modelBuilder.Entity<Body>().HasOne("Post").WithOne("Body").HasForeignKey("Id");


            //            modelBuilder.Entity<Company>()
            //                .Property()
            //                .HasMany(b => b.Shareholders);

            //
            //            modelBuilder.Entity<Shareholder>().HasOne(x=>x.Company)
            //                .WithMany().HasForeignKey(x => x.CompanyId);

            //            Database.SetInitializer<SchoolDbContext>(null);//忽略映射

            //            modelBuilder.Entity<Company>().HasMany(x => x.Shareholders);

            //.WithMany(x => x.CompanyCities).HasForeignKey(x => x.CompanyId);
        }
    }
}