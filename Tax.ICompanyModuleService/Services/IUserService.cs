using System.Threading.Tasks;
using Surging.Core.CPlatform.Filters.Implementation;
using Surging.Core.CPlatform.Ioc;
using Surging.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using Tax.ICompanyModuleService.Domain.BaseModel.DTO;
using Tax.ICompanyModuleService.Domain.BaseModel.Entities;
using Tax.ICompanyModuleService.Domain.Entities;

namespace Tax.ICompanyModuleService.Services
{
    [ServiceBundle("api/{Service}")]
    public interface IUserService : IServiceKey
    {
        Task<string> Login(string account, string md5Pwd);

        Task<User> Authentication(AuthenticationRequestData account);

        [Authorization(AuthType = AuthorizationType.JWT)]
        Task<bool> TestAccessToken();

        Task<bool> AddUser(DUser user);
    }
}