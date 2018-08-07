using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Surging.Core.ProxyGenerator;
using Tax.ICompanyModuleService.Domain.BaseModel.Entities;
using Tax.ICompanyModuleService.Domain.IRepositories;

namespace Tax.CompanyModuleService.Domain.Respositories
{
    public class RoleRespository : EfBaseRespository<Role>,IRoleRespository
    {
        public async Task<List<Role>> GetRolesAsync(int userId)
        {
            var userRoles = _unitOfWork.Context.Set<UserRole>().Where(w => w.UserId == userId && w.IsValied);
            var roles = Entities.Where(w => userRoles.Select(x => x.RoleId).Contains(w.Id)).Distinct();
            return await Task.FromResult(roles.ToList());
        }
    }
}