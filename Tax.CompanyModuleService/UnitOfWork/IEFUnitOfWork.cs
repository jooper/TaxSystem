using Microsoft.EntityFrameworkCore;
using Surging.Core.CPlatform.Ioc;
using Tax.ICompanyModuleService.Domain.IRepositories;

namespace Tax.CompanyModuleService.UnitOfWork
{
    public interface IEfUnitOfWork : IUnitOfWorkRespositoryContext
    {
        DbContext Context { get; }
    }
}