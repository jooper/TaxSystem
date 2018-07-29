using System.Threading.Tasks;
using Tax.ICompanyModuleService.Domain.BaseModel.Models;
using Tax.ICompanyModuleService.Domain.Entities;

namespace Tax.ICompanyModuleService.Domain.IRepositories
{
    /// <summary>
    /// 公司聚合根的仓储接口
    /// </summary>
    public interface ICompanyRespository : IRepository<Company>
    {
        Task<string> GetCompanyNmae();
    }
}