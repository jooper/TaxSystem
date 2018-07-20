using System.Data.Entity;
using Tax.ICompanyModuleService.Domain.BaseModel;
using Tax.ICompanyModuleService.Domain.BaseModel.Models;

namespace Tax.CompanyModuleService.UnitOfWork
{
    public class EFUnitOfWork : IEFUnitOfWork
    {
        public bool IsCommitted { get; set; }

        public int Commit()
        {
            throw new System.NotImplementedException();
        }

        public void Rollback()
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public void RegisterNew<TEntiy>(TEntiy entity) where TEntiy : AggregateRoot
        {
            throw new System.NotImplementedException();
        }

        public void RegisterModified<TEntiy>(TEntiy entity) where TEntiy : AggregateRoot
        {
            throw new System.NotImplementedException();
        }

        public void RegisterDeleted<TEntiy>(TEntiy entity) where TEntiy : AggregateRoot
        {
            throw new System.NotImplementedException();
        }

        public DbContext Context => new EFDbContext();
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