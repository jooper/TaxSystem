using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Tax.ICompanyModuleService.Domain.BaseModel.Entities;
using Tax.ICompanyModuleService.Domain.Entities;
using Tax.ICompanyModuleService.Domain.IRepositories;

namespace Tax.CompanyModuleService.Domain.Respositories
{
    public class UserRespository : EfBaseRespository<User>, IUserRespository
    {


    }
}