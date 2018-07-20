using Tax.ICompanyModuleService.Domain.IRepositories;
using System.Data.Entity;
using Tax.ICompanyModuleService.Domain.BaseModel.Models;

namespace Tax.CompanyModuleService.UnitOfWork
{
    public interface IEFUnitOfWork : IUnitOfWorkRespositoryContext
    {
        DbContext Context { get; }
    }


    public class EFDbContext : DbContext
    {
        public EFDbContext() : base("name=")
        {
        }
        public DbSet<TbCompany> TB_COMPANY { set; get; }
        public DbSet<TbRole> TB_ROLE { set; get; }
        public DbSet<TbRight> TB_RIGHT { set; get; }
        public DbSet<TbUserrole> TB_USERROLE { set; get; }
        public DbSet<TbUser> TB_USER { set; get; }
    }
}