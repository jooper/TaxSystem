using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Surging.Core.ProxyGenerator;
using Tax.CompanyModuleService.Domain.Respositories;
using Tax.CompanyModuleService.Ext;
using Tax.CompanyModuleService.Uinities;
using Tax.ICompanyModuleService.Domain.BaseModel.DTO;
using Tax.ICompanyModuleService.Domain.BaseModel.Entities;
using Tax.ICompanyModuleService.Domain.BaseModel.Enums;
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

        public async Task<int> AddTaxAsync(DTaxList model)
        {
            var entity = model.MapTo<TaxList, DTaxList>();
            var result = _taxRespository.Insert(entity);
            return await Task.FromResult(result);
        }

        public async Task<int> GetAllCountAsync()
        {
            var count = _taxRespository.Entities.Count(w => w.IsValied);
            return await Task.FromResult(count);
        }

        public async Task<List<TaxList>> GetTaxListAsync(int offSet, int take, DateTime dateTime, int linkManId,
            int companyId,
            TaxType type, TaxState state)
        {
            var taxLists = _taxRespository.Entities.AsNoTracking()
                .Where(w => w.IsValied && w.OpenTaxDateTime.Month.Equals(dateTime.Month))
                .AsEnumerable()
                .WhereIf(companyId != -1 && companyId != 0, w => w.OpenTaxCompnayId == companyId)
                .WhereIf(linkManId != -1, w => w.LinkManId == linkManId)
                .WhereIf(type != TaxType.UnKnown, w => w.TaxType == type)
                .WhereIf(state != TaxState.UnKnown, w => w.State == state)
                .OrderByDescending(o => o.UpdateTime).Skip(offSet)
                .Take(take).ToList();
            return await Task.FromResult(taxLists);
        }

        public async Task<int> UpdateAsync(DTaxList model)
        {
            var entity = model.MapTo<TaxList, DTaxList>();
            var result = _taxRespository.Update(entity);
            return await Task.FromResult(result);
        }


        public async Task<int> BatchUpdateAsync(List<DTaxList> modelsLists)
        {
            var list = new List<TaxList>();
            modelsLists.ForEach(item =>
            {
                var entity = item.MapTo<TaxList, DTaxList>();
                list.Add(entity);
            });
            var result = _taxRespository.Update(list);
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