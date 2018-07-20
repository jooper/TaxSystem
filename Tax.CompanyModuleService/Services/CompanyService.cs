using System;
using System.Threading.Tasks;
using Surging.Core.ProxyGenerator;
using Tax.ICompanyModuleService;
using Tax.ICompanyModuleService.Domain.BaseModel.Models;
using Tax.ICompanyModuleService.Domain.IRepositories;

namespace Tax.CompanyModuleService
{
    public class CompanyService : ProxyServiceBase, ICompanyService
    {
        public ICompanyRespository CompanyRespository { set; get; }

        public Task<TbCompany> GetCompany(int id)
        {
            return Task.FromResult(CompanyRespository.GetByKey(0));
        }
    }
}