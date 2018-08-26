using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Surging.Core.CPlatform.Ioc;
using Surging.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using Tax.ICompanyModuleService.Domain.BaseModel.DTO;
using Tax.ICompanyModuleService.Domain.BaseModel.Entities;
using Tax.ICompanyModuleService.Domain.BaseModel.Enums;

namespace Tax.ICompanyModuleService.Services
{
    [ServiceBundle("api/{Service}")]
    public interface ITaxService : IServiceKey
    {
        Task<int> AddTaxAsync(DTaxList model);

        Task<List<TaxList>> GetTaxListAsync(int offSet, int take, DateTime dateTime, int linkManId, TaxType type,
            TaxState state);

        Task<int> UpdateAsync(DTaxList model);
        Task<int> BatchUpdateAsync(List<DTaxList> modelsLists);
        Task<int> DeleteAsync(int id);
    }
}