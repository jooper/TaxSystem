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

        public async Task<int> GetAllCountAsync()
        {
            var count = _repository.Entities.Count(w => w.IsValied);
            return await Task.FromResult(count);
        }

        public async Task<List<DCompany>> GetCompanysAsync(int offSet, int take)
        {
            //            var companies = _repository.Entities.Where(w => w.IsValied).AsNoTracking()
            //                .Include(x => x.Shareholders)
            //                .OrderByDescending(o => o.RegisterTime).Skip(offSet).Take(take)
            //                .ToList();
                        var companies = _repository.Entities.Where(w => w.IsValied).AsNoTracking()
                            .Include(x => x.Shareholders)
                            .Select(x => new {entities = x, shareholders = x.Shareholders.Where(w => w.IsValied)})
                            .Select(t => new Company
                            {
                                BusinessState = t.entities.BusinessState,
                                CompanyId = t.entities.CompanyId,
                                HomeTownAddr = t.entities.HomeTownAddr,
                                Id = t.entities.Id,
                                LegalPerson = t.entities.LegalPerson,
                                LegalPersonPhone = t.entities.LegalPersonPhone,
                                LinkMan = t.entities.LinkMan,
                                LinkManPhone = t.entities.LinkManPhone,
                                Name = t.entities.Name,
                                RegisterCapital = t.entities.RegisterCapital,
                                RegisterTime = t.entities.RegisterTime,
                                TaxNumber = t.entities.TaxNumber,
                                CreateUserId = t.entities.CreateUserId,
                                UpdateTime = t.entities.UpdateTime,
                                UpdateUserId = t.entities.UpdateUserId,
                                Addr = t.entities.Addr,
                                Shareholders = t.shareholders.ToList(),
                            })
                            .OrderByDescending(o => o.RegisterTime).Skip(offSet).Take(take)
                            .ToList();

//
//            var companies = _repository.Entities.Where(w => w.IsValied).AsNoTracking()
//                .Include(x => x.Shareholders)
//                .Select(x => new { entities = x.MapTo<DCompany,Company>(), shareholders = x.Shareholders.Where(w => w.IsValied) })
//                .Select(()=> { return Company(); })
//                .OrderByDescending(o => o.RegisterTime).Skip(offSet).Take(take)
//                .ToList();

            var dCompanies =companies.Select(x => x.MapTo<DCompany, Company>()).ToList();
            return await Task.FromResult(dCompanies);
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
            entityCompany.Id = entityCompany.CompanyId;
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
            company.Id = company.CompanyId;
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

        public async Task<int> UpdateShareholderAsync(DShareholder shareholder)
        {
//            var company = await GetCompanyAsync(model.CompanyId);
//            if (company == null)
//                throw new Exception("公司信息不存在！" + model.CompanyId);
//
            var entity = shareholder.MapTo<Shareholder, DShareholder>();
            
//
//            company.Shareholders = new List<Shareholder>
//            {
//                entity
//            };
//
//
//            var result = _repository.Update(company);

            var result = await _repository.UpdateShareholderAsync(entity);
            return await Task.FromResult(result);
        }

        public async Task<int> DeleteShareholderAsync(int id)
        {
            var result = await _repository.DeleteShareholderAsync(id);
            return result;
        }
    }
}