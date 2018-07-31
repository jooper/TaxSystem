using System;
using System.Threading.Tasks;
using Surging.Core.ProxyGenerator;
using Tax.CompanyModuleService.Domain.Respositories;
using Tax.CompanyModuleService.Ext;
using Tax.ICompanyModuleService.Domain.BaseModel.DTO;
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

        public Task<Company> GetCompany(int id)
        {
            return Task.FromResult(_repository.GetByKey(id));
        }

        public Task<int> AddCompnay(DCompany company)
        {
            var entityCompany = company.MapTo<Company, DCompany>();
            entityCompany.RegisterTime = DateTime.Now;
            entityCompany.CreateTime=DateTime.Now;
            entityCompany.UpdateTime=DateTime.Now;
            entityCompany.CreateUserId = "1";
            entityCompany.UpdateUserId = "2";
            entityCompany.LegalPerson = "3";
            var result = _repository.Insert(entityCompany);
            return Task.FromResult(result);
        }

        public Task UpdateCompany(DCompany company)
        {
            var entityCompany = GetCompany(1).Result;
            entityCompany.Name = "test update";
            _repository.Update(entityCompany);
            return null;
        }
    }
}