using System.Threading.Tasks;
using Surging.Core.CPlatform.Ioc;
using Surging.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using Tax.ICompanyModuleService.Domain.BaseModel.DTO;

namespace Tax.ICompanyModuleService.Services
{
    [ServiceBundle("api/{Service}")]
    public interface IUserService : IServiceKey
    {
        Task<string> Login(string account, string md5Pwd);

        Task<string> Authentication(AuthenticationRequestData account);
    }
}