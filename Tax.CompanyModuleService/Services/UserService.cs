using System.Linq;
using System.Threading.Tasks;
using Surging.Core.CPlatform.Ioc;
using Surging.Core.ProxyGenerator;
using Tax.CompanyModuleService.Domain.Respositories;
using Tax.CompanyModuleService.Uinities;
using Tax.ICompanyModuleService.Domain.BaseModel.DTO;
using Tax.ICompanyModuleService.Domain.IRepositories;
using Tax.ICompanyModuleService.Services;

namespace Tax.CompanyModuleService.Services
{
    [ModuleName("User")]
    public class UserService : ProxyServiceBase, IUserService
    {
        private readonly IUserRespository _userRespository;

        public UserService(UserRespository userRespository)
        {
            _userRespository = userRespository;
        }

        public Task<string> Login(string account, string md5Pwd)
        {
            var token = TokenProvider.GenerateToken(account, md5Pwd);
            return Task.FromResult(token);
        }

        public Task<string> Authentication(AuthenticationRequestData requestData)
        {
            var userEntity = _userRespository
                .Find(x => x.Name == requestData.UserName && x.PwdMd5 == requestData.Password)
                .FirstOrDefault();
            if (userEntity == null)
                return Task.FromResult(string.Empty);
            var token = TokenProvider.GenerateToken(requestData.UserName, requestData.Password);
            return Task.FromResult(token);
        }
    }
}