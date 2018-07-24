using Tax.ICompanyModuleService.Domain.BaseModel.Models;
using Tax.ICompanyModuleService.Domain.IRepositories;

namespace Tax.CompanyModuleService.Domain.Respositories
{
    public class UserRespository:EFBaseRespository<TbUser>,IUserRespository
    {
        
    }
}