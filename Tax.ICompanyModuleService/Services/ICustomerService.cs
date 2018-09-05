using System.Collections.Generic;
using System.Threading.Tasks;
using Surging.Core.CPlatform.Ioc;
using Surging.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using Tax.ICompanyModuleService.Domain.BaseModel.DTO;
using Tax.ICompanyModuleService.Domain.BaseModel.Entities;

namespace Tax.ICompanyModuleService.Services
{
    [ServiceBundle("api/{Service}")]
    public interface ICustomerService : IServiceKey
    {
        Task<Customer> GetCustomerByIdAsync(int id);
        Task<int> GetAllCustomerCountAsync();
        Task<IList<Customer>> GetCustomersAsync(int offSet, int take);
        Task<int> AddCustomerAsync(DCustomer customer);
        Task<int> UpdateCustomerAsync(DCustomer customer);
        Task<int> DeleteCustomerAsync(int id);
        Task<int> BatchCalcCustomerTotalTaxAccountAsync(List<(int,decimal)> list);
        
    }
}