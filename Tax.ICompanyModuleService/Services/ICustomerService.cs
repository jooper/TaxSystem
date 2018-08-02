using System.Collections.Generic;
using System.Threading.Tasks;
using Surging.Core.CPlatform.Ioc;
using Tax.ICompanyModuleService.Domain.BaseModel.DTO;
using Tax.ICompanyModuleService.Domain.BaseModel.Entities;

namespace Tax.ICompanyModuleService.Services
{
    public interface ICustomerService : IServiceKey
    {
        Task<IList<Customer>> GetCustomersAsync();
        Task<int> AddCustomer(DCustomer customer);
        Task<int> UpdateCustomer(DCustomer customer);
    }
}