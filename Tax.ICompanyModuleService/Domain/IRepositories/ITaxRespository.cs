using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tax.ICompanyModuleService.Domain.BaseModel.Entities;
using Tax.ICompanyModuleService.Domain.BaseModel.Enums;

namespace Tax.ICompanyModuleService.Domain.IRepositories
{
    public interface ITaxRespository : IRepository<TaxList>
    {
        Task<decimal> CalcCustomerTaxTotalAccountAsync(int uid);
        Task<List<(int, decimal)>> BatchCalcCustomerTaxToatalAccountAsync(ICollection<int> uids);
    }
}