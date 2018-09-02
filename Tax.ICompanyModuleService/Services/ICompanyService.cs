using System.Collections.Generic;
using System.Threading.Tasks;
using Surging.Core.CPlatform.Ioc;
using Surging.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using Tax.ICompanyModuleService.Domain.BaseModel.DTO;
using Tax.ICompanyModuleService.Domain.BaseModel.Entities;


namespace Tax.ICompanyModuleService.Services
{
    [ServiceBundle("api/{Service}")]
    public interface ICompanyService : IServiceKey
    {
//        [Command(Strategy = StrategyType.Injection, ShuntStrategy = AddressSelectorMode.HashAlgorithm,
//            ExecutionTimeoutInMilliseconds = 2500, BreakerRequestVolumeThreshold = 3, Injection = @"return  null;", RequestCacheEnabled = false)]
        Task<Company> GetCompanyAsync(int id);
        Task<int> GetAllCountAsync();
        Task<List<DCompany>> GetCompanysAsync(int offSet, int take);
        Task<int> AddCompnayAsync(DCompany company);
        Task<int> UpdateCompanyAsync(DCompany company);
        Task<bool> AddShareholderAsync(DShareholder shareholder);
        Task<int> DeleteCompanyAsync(int companyId);

        Task<int> UpdateShareholderAsync(DShareholder shareholder);
        Task<int> DeleteShareholderAsync(int id);
    }
}