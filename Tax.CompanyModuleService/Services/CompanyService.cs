using System.Threading.Tasks;
using Surging.Core.ProxyGenerator;
using Tax.ICompanyModuleService;
using Tax.ICompanyModuleService.Domain.BaseModel.Models;
using Tax.ICompanyModuleService.Domain.IRepositories;
using Tax.ICompanyModuleService.Services;

namespace Tax.CompanyModuleService.Services
{
    public class CompanyService : ProxyServiceBase, ICompanyService
    {
        public ICompanyRespository CompanyRespository { set; get; }

//        public CompanyService(ICompanyRespository companyRespository)
//        {
//            CompanyRespository = companyRespository;
//        }

        public Task<TbCompany> GetCompany(int id)
        {
            return Task.FromResult(CompanyRespository.GetByKey(0));
        }
    }
}