using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Surging.Core.ProxyGenerator;
using Tax.CompanyModuleService.Domain.Respositories;
using Tax.CompanyModuleService.Ext;
using Tax.ICompanyModuleService.Domain.BaseModel.DTO;
using Tax.ICompanyModuleService.Domain.BaseModel.Entities;
using Tax.ICompanyModuleService.Services;

namespace Tax.CompanyModuleService.Services
{
    public class BankAccountService : ProxyServiceBase, IBankAccountSevice
    {
        private readonly BankAccountRespository _bankAccountRespository;

        public BankAccountService(BankAccountRespository bankAccountRespository)
        {
            _bankAccountRespository = bankAccountRespository;
        }

        public async Task<List<BankAccount>> GetBandAccountsAsync()
        {
            return await _bankAccountRespository.Entities.ToListAsync();
        }

        public async Task<int> AddBankAccountAsync(DBankAccount bankAccount)
        {
            var entity = bankAccount.MapTo<BankAccount, DBankAccount>();
            var result = _bankAccountRespository.Insert(entity);
            return await Task.FromResult(result);
        }

        public async Task<int> UpdateBankAccountAsync(DBankAccount bankAccount)
        {
            var entity = bankAccount.MapTo<BankAccount, DBankAccount>();
            var result = _bankAccountRespository.Update(entity);
            return await Task.FromResult(result);
        }
    }
}