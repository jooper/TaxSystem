using System.Data.Entity;
using Tax.ICompanyModuleService.Domain.BaseModel;

namespace Tax.CompanyModuleService.UnitOfWork
{
    public class EFUnitOfWork:IEFUnitOfWork
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

        public DbContext Context { get; }
    }
}