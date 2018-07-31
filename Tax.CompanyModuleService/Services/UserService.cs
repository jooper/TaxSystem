using System;
using System.Linq;
using JWT.Algorithms;
using JWT.Builder;
using Surging.Core.ProxyGenerator;
using Tax.CompanyModuleService.Uinities;
using Tax.ICompanyModuleService.Domain.Entities;
using Tax.ICompanyModuleService.Domain.IRepositories;
using Tax.ICompanyModuleService.Services;


namespace Tax.CompanyModuleService.Services
{
    public class UserService : ProxyServiceBase, IUserService
    {
        private readonly IUserRespository _userRespository;


        public UserService(IUserRespository userRespository)
        {
            _userRespository = userRespository;
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