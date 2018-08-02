using System.Collections.Generic;
using System.Threading.Tasks;
using Surging.Core.CPlatform.Ioc;
using Tax.ICompanyModuleService.Domain.BaseModel.Entities;

namespace Tax.ICompanyModuleService.Services
{
    public interface IBankAccountSevice : IServiceKey
    {
        Task<List<BankAccount>> GetCompanysAsync();
    }
}