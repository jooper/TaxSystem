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
using Tax.ICompanyModuleService.Domain.Entities;
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

        public async Task<List<Company>> GetCompanysAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<int> AddCompnayAsync(DCompany company)
        {
            var entityCompany = company.MapTo<Company, DCompany>();
            entityCompany.RegisterTime = DateTime.Now;
            entityCompany.LegalPerson = "3";
            var result = _repository.Insert(entityCompany);
            return await Task.FromResult(result);
        }

        public async Task UpdateCompanyAsync(DCompany company)
        {
            var entityCompany = GetCompanyAsync(1).Result;
            entityCompany.Name = "test update";
            _repository.Update(entityCompany);
            await Task.CompletedTask;
        }
    }
}