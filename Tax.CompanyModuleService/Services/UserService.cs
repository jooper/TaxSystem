using System;
using System.Linq;
using System.Threading.Tasks;
using Surging.Core.CPlatform.Ioc;
using Surging.Core.CPlatform.Transport.Implementation;
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


        public async Task<string> Login(string account, string md5Pwd)
        {
            var token = TokenProvider.GenerateToken(account, md5Pwd);
            return await Task.FromResult(token);
        }


        //返回对象，不然框架回默认返回有效token
        public async Task<User> Authentication(AuthenticationRequestData requestData)
        {
            var userEntity = _userRespository
                .Find(x => x.Name == requestData.UserName && x.PwdMd5 == requestData.Password)
                .FirstOrDefault();
            return await Task.FromResult(userEntity);
        }

        public async Task<bool> TestAccessToken()
        {
            //获取网关通过netty传递过来的参数
            var headRequest = RpcContext.GetContext().GetContextParameters().FirstOrDefault();

            throw new Exception("用户Id非法！" + headRequest.Value);
            return await Task.FromResult(true);
        }

        public async Task<bool> AddUser(DUser user)
        {
            var entity = _userRespository.Find(x => x.Account == user.Account).FirstOrDefault();
            if (entity != null)
                return await Task.FromResult(false);

            var userEntity = user.MapTo<User, DUser>();
            userEntity.PwdMd5 = TokenProvider.Hash(user.PwdMd5);
            _userRespository.Insert(userEntity);
            return await Task.FromResult(true);
        }
    }
}