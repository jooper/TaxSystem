using System.Linq;
using System.Threading.Tasks;
using Surging.Core.CPlatform.Ioc;
using Surging.Core.ProxyGenerator;
using Tax.CompanyModuleService.Domain.Respositories;
using Tax.CompanyModuleService.Ext;
using Tax.CompanyModuleService.Uinities;
using Tax.ICompanyModuleService.Domain.BaseModel.DTO;
using Tax.ICompanyModuleService.Domain.BaseModel.Entities;
using Tax.ICompanyModuleService.Domain.Entities;
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


        //返回对象，不然框架回默认返回有效token
        public Task<User> Authentication(AuthenticationRequestData requestData)
        {
            var userEntity = _userRespository
                .Find(x => x.Name == requestData.UserName && x.PwdMd5 == requestData.Password)
                .FirstOrDefault();

            return Task.FromResult(new User{Name = "jooper",PwdMd5 = "dfdafd"});
        }

        public Task<bool> TestAccessToken()
        {
            return Task.FromResult(true);
        }

        public Task<bool> AddUser(DUser user)
        {
            var userEntity = user.MapTo<User, DUser>();
            _userRespository.Insert(userEntity);
            return Task.FromResult(true);
        }
    }
}