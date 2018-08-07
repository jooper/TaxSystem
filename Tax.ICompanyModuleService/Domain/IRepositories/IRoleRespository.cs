
using System.Collections.Generic;
using System.Threading.Tasks;
using Tax.ICompanyModuleService.Domain.BaseModel.Entities;

namespace Tax.ICompanyModuleService.Domain.IRepositories
{
    public interface IRoleRespository:IRepository<Role>
    {
        Task<List<Role>> GetRolesAsync(int userId);
    }
}