using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Surging.Core.ProxyGenerator;
using Tax.CompanyModuleService.Domain.Respositories;
using Tax.CompanyModuleService.Ext;
using Tax.ICompanyModuleService.Domain.BaseModel.DTO;
using Tax.ICompanyModuleService.Domain.BaseModel.Entities;
using Tax.ICompanyModuleService.Services;

namespace Tax.CompanyModuleService.Services
{
    public class CompanyService : ProxyServiceBase, ICompanyService
    {
        private readonly CompanyRespository _repository;

        public CompanyService(CompanyRespository repository)
        {
            _repository = repository;
        }

        public async Task<Company> GetCompanyAsync(int id)
        {
            return await Task.FromResult(_repository.GetByKey(id));
        }

        public async Task<List<DCompany>> GetCompanysAsync()
        {
            var companies = await _repository.Entities.Where(w => w.IsValied).Include(x => x.Shareholders)
                .OrderByDescending(o => o.RegisterTime)
                .ToListAsync();

            var dCompanies = companies.Select(x => x.MapTo<DCompany, Company>()).ToList();
            return dCompanies;
        }

        public async Task<int> AddCompnayAsync(DCompany company)
        {
            var entityCompany = company.MapTo<Company, DCompany>();
            entityCompany.RegisterTime = DateTime.Now;
            var result = _repository.Insert(entityCompany);
            return await Task.FromResult(result);
        }

        public async Task<int> UpdateCompanyAsync(DCompany company)
        {
            var entityCompany = company.MapTo<Company, DCompany>();
            var result = _repository.Update(entityCompany);
            return await Task.FromResult(result);
        }

        public async Task<bool> AddShareholderAsync(DShareholder shareholder)
        {
            var company = await GetCompanyAsync(shareholder.CompanyId);
            if (company == null)
                throw new Exception("公司信息不存在！" + shareholder.CompanyId);
            var shareholderEntity = shareholder.MapTo<Shareholder, DShareholder>();
            company.Shareholders = new List<Shareholder>
            {
                shareholderEntity
            };
            _repository.Update(company);
            return true;
        }

        public async Task<int> DeleteCompanyAsync(int companyId)
        {
            var companyEntity = await GetCompanyAsync(companyId);
            companyEntity.IsValied = false;
            var result = _repository.Update(companyEntity);
            return await Task.FromResult(result);
        }
    }
}