using System.Threading.Tasks;
using Surging.Core.CPlatform.Ioc;
using Tax.ICompanyModuleService.Domain.BaseModel.Models;
using Tax.ICompanyModuleService.Domain.IRepositories;

namespace Tax.CompanyModuleService.Domain.Respositories
{
    public class CompanyRespository : EFBaseRespository<TbCompany>,  ICompanyRespository
    {
        public Task<string> GetCompanyNmae()
        {
            throw new System.NotImplementedException();
        }
    }
}