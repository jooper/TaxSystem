using Tax.ICompanyModuleService.Domain.BaseModel.Entities;
using Tax.ICompanyModuleService.Domain.IRepositories;

namespace Tax.CompanyModuleService.Domain.Respositories
{
    public class BankAccountRespository : EfBaseRespository<BankAccount>, IBankAccountRespository
    {
    }
}