using System.Collections.Generic;
using System.Threading.Tasks;
using Surging.Core.CPlatform.Ioc;
using Surging.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using Tax.ICompanyModuleService.Domain.BaseModel.DTO;
using Tax.ICompanyModuleService.Domain.BaseModel.Entities;

namespace Tax.ICompanyModuleService.Services
{
    [ServiceBundle("api/{Service}")]
    public interface ITaxService : IServiceKey
    {
        Task<int> AddTaxAsync(DTaxList customer);
        Task<List<TaxList>> GetTaxListAsync(int offSet, int take);
        Task<int> UpdateAsync(DTaxList model);
        Task<int> DeleteAsync(int id);
    }
}