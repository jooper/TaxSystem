using System.Linq;
using System.Threading.Tasks;
using Surging.Core.ProxyGenerator;
using Tax.CompanyModuleService.Domain.Respositories;
using Tax.CompanyModuleService.Uinities;
using Tax.ICompanyModuleService.Domain.IRepositories;
using Tax.ICompanyModuleService.Services;

namespace Tax.CompanyModuleService.Services
{
    public class UserService : ProxyServiceBase, IUserService
    {
        private readonly IUserRespository _userRespository;

        public UserService(UserRespository userRespository)
        {
            _userRespository = userRespository;
        }

        public Task Login(string account, string md5Pwd)
        {
            return Task.CompletedTask;
        }

        public string GetToken(string account, string pwd)
        {
            var userEntity = _userRespository.Find(x => x.Name == account && x.PwdMd5 == pwd).FirstOrDefault();
            var token = TokenProvider.GenerateToken(account, userEntity);
            TokenProvider.ResolveToken(token);
            return string.Empty;
        }
    }
}