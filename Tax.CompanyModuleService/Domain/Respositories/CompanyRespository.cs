using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tax.ICompanyModuleService.Domain.BaseModel.Models;
using Tax.ICompanyModuleService.Domain.IRepositories;

namespace Tax.CompanyModuleService.Respositories
{
    public class CompanyRespository : EFBaseRespository<TbCompany>, ICompanyRespository
    {
        public Task<string> GetCompanyNmae()
        {
            throw new System.NotImplementedException();
        }
    }
}