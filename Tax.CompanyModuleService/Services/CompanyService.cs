﻿using System;
using System.Threading.Tasks;
using Surging.Core.ProxyGenerator;
using Tax.CompanyModuleService.Domain.Respositories;
using Tax.ICompanyModuleService.Domain.BaseModel.DTO;
using Tax.ICompanyModuleService.Domain.BaseModel.Models;
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

        public Task<TbCompany> GetCompany(int id)
        {
            return Task.FromResult(_repository.GetByKey(id));
        }

        public Task<int> AddCompnay(DCompany company)
        {
            var entityCompany = new TbCompany {Id = company.Id, Addr = company.Name, Name = company.Name};
//            _repository.Insert(entityCompany);
            return Task.FromResult(1);
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