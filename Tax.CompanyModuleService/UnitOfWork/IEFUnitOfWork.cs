using System.Data.Entity;
using Tax.ICompanyModuleService.Domain.IRepositories;

namespace Tax.CompanyModuleService.UnitOfWork
{
    public interface IEFUnitOfWork : IUnitOfWorkRespositoryContext
    {
        DbContext Context { get; }
    }
}