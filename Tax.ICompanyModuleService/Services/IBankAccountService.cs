using System.Collections.Generic;
using System.Threading.Tasks;
using Surging.Core.CPlatform.Ioc;
using Surging.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using Tax.ICompanyModuleService.Domain.BaseModel.DTO;
using Tax.ICompanyModuleService.Domain.BaseModel.Entities;

namespace Tax.ICompanyModuleService.Services
{
    [ServiceBundle("api/{Service}")]
    public interface IBankAccountService : IServiceKey
    {
        Task<int> GetCountAsync();
        Task<List<BankAccount>> GetBandAccountsAsync(int offSet, int take);
        Task<int> AddBankAccountAsync(DBankAccount bankAccount);
        Task<int> UpdateBankAccountAsync(DBankAccount bankAccount);
    }
}