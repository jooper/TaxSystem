using System;
using System.Threading.Tasks;
using Surging.Core.ProxyGenerator;
using Tax.ICompanyModuleService;
using Tax.ICompanyModuleService.Domain.BaseModel.Models;

namespace Tax.CompanyModuleService
{
    public class CompanyService : ProxyServiceBase, ICompanyService
    {
        public Task<TbCompany> GetCompany(int id)
        {
            return Task.FromResult(new TbCompany
            {
                Addr = "成都",
                Id = 1,
                Name = "成都科贸"
            });
        }
    }
}