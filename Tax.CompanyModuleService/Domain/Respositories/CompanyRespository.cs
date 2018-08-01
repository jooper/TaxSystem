using System.Threading.Tasks;
using Tax.ICompanyModuleService.Domain.Entities;
using Tax.ICompanyModuleService.Domain.IRepositories;

namespace Tax.CompanyModuleService.Domain.Respositories
{
    public class CompanyRespository : EfBaseRespository<Company>, ICompanyRespository
    {
        public Task<string> GetCompanyNmae()
        {
            return Task.FromResult(string.Empty);
        }
    }
}