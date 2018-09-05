using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tax.ICompanyModuleService.Domain.BaseModel.Entities;
using Tax.ICompanyModuleService.Domain.BaseModel.Enums;
using Tax.ICompanyModuleService.Domain.IRepositories;

namespace Tax.CompanyModuleService.Domain.Respositories
{
    public class TaxRespository : EfBaseRespository<TaxList>, ITaxRespository
    {
        public async Task<decimal> CalcCustomerTaxTotalAccountAsync(int uid)
        {
            var userTaxList = Find(x =>
                    x.LinkManId == uid && x.IsValied && x.State != TaxState.Discarded && x.State != TaxState.UnKnown)
                .Select(s => s.TaxAccount);

            var sumAsync = userTaxList.Sum(x => x);

            return await Task.FromResult(sumAsync);
        }


        public async Task<List<(int, decimal)>> BatchCalcCustomerTaxToatalAccountAsync(ICollection<int> uids)
        {
            if (!uids.Any())
                return new List<(int, decimal)>();
            var taxs = Find(x =>
                    uids.Contains(x.LinkManId) && x.IsValied && x.State != TaxState.Discarded &&
                    x.State != TaxState.UnKnown).GroupBy(g => g.LinkManId)
                .Select(s => new ValueTuple<int, decimal>() {Item1 = s.Key, Item2 = s.Sum(w => w.TaxAccount)});
            return await Task.FromResult(taxs.ToList());
        }
    }
}