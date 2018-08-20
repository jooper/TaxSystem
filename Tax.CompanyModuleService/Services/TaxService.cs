using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Surging.Core.ProxyGenerator;
using Tax.CompanyModuleService.Domain.Respositories;
using Tax.CompanyModuleService.Ext;
using Tax.ICompanyModuleService.Domain.BaseModel.DTO;
using Tax.ICompanyModuleService.Domain.BaseModel.Entities;
using Tax.ICompanyModuleService.Domain.IRepositories;
using Tax.ICompanyModuleService.Services;

namespace Tax.CompanyModuleService.Services
{
    public class TaxService : ProxyServiceBase, ITaxService
    {
        private readonly ITaxRespository _taxRespository;

        public TaxService(TaxRespository taxRespository)
        {
            _taxRespository = taxRespository;
        }

        public async Task<int> AddTaxAsync(DTaxList tax)
        {
            var result = _taxRespository.Insert(tax);
            return await Task.FromResult(result);
        }

        public async Task<List<TaxList>> GetTaxListAsync(int offSet, int take)
        {
            var taxLists = await _taxRespository.Entities.Where(w => w.IsValied)
                .OrderByDescending(o => o.UpdateTime).Skip(offSet)
                .Take(take).ToListAsync();
            return taxLists;
        }

        public async Task<int> UpdateAsync(DTaxList model)
        {
            var entity = model.MapTo<TaxList, DTaxList>();
            var result = _taxRespository.Update(entity);
            return await Task.FromResult(result);
        }

        public async Task<int> DeleteAsync(int id)
        {
            var result = _taxRespository.Find(x => x.Id == id && x.IsValied).FirstOrDefault();
            if (result == null)
                return await Task.FromResult(0);
            result.IsValied = false;
            var update = _taxRespository.Update(result);
            return await Task.FromResult(update);
        }
    }
}