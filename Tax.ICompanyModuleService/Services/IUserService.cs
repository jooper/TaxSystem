using System.Threading.Tasks;
using Surging.Core.CPlatform.Filters.Implementation;
using Surging.Core.CPlatform.Ioc;
using Surging.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using Tax.ICompanyModuleService.Domain.BaseModel.DTO;
using Tax.ICompanyModuleService.Domain.BaseModel.Entities;

namespace Tax.ICompanyModuleService.Services
{
    [ServiceBundle("api/{Service}")]
    public interface IUserService : IServiceKey
    {
        Task<User> Authentication(AuthenticationRequestData account);

        [Authorization(AuthType = AuthorizationType.JWT)]
        Task<bool> TestAccessToken();


        [Authorization(AuthType = AuthorizationType.JWT)]
        Task<bool> AddUser(DUser user);
    }
}