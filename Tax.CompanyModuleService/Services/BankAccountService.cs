using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Surging.Core.ProxyGenerator;
using Tax.CompanyModuleService.Domain.Respositories;
using Tax.CompanyModuleService.Ext;
using Tax.CompanyModuleService.Uinities;
using Tax.ICompanyModuleService.Domain.BaseModel.DTO;
using Tax.ICompanyModuleService.Domain.BaseModel.Entities;
using Tax.ICompanyModuleService.Domain.IRepositories;
using Tax.ICompanyModuleService.Services;

namespace Tax.CompanyModuleService.Services
{
    public class BankAccountService : ProxyServiceBase, IBankAccountService
    {
        private readonly IBankAccountRespository _bankAccountRespository;

        public BankAccountService(BankAccountRespository bankAccountRespository)
        {
            _bankAccountRespository = bankAccountRespository;
        }

        public async Task<int> GetCountAsync()
        {
            var count = _bankAccountRespository.Entities.Count(w => w.IsValied);
            return await Task.FromResult(count);
        }

        public async Task<List<DBankAccountItem>> GetBandAccountsAsync(int offSet, int take, string openAccountCompanyName = "")

        {
            var bankEntities = _bankAccountRespository.Entities.OrderByDescending(o => o.UpdateTime).AsNoTracking()
                .Where(w => w.IsValied).AsEnumerable()
                .WhereIf(openAccountCompanyName!=string.Empty,w=>w.CompanyName.Contains(openAccountCompanyName))
                .GroupBy(g => g.CompanyId).Select(x => new DBankAccountItem
                {
                    CompanyId = x.Key,
                    Accounts = x.Select(w => new DBankAccount
                    {
                        Id=w.Id,
                        CompanyId = w.CompanyId,
                        OpenBankName = w.OpenBankName,
                        CompanyName = w.CompanyName,
                        AccountType = w.AccountType,
                        AccountNumber = w.AccountNumber,
                        LinkMan = w.LinkMan,
                        LinkManPhone = w.LinkManPhone,
                        State = w.State,
                        SealExplation = w.SealExplation
                    }).ToList()
                });

            var resultAccountItems =  bankEntities.Skip(offSet).Take(take);
            return await  Task.FromResult(resultAccountItems.ToList());
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

        public async Task<int> DeleteBankAccountAsync(int id)
        {
            var bankAccount = _bankAccountRespository.Find(x => x.Id == id).AsNoTracking().FirstOrDefault();
            if (bankAccount == null)
                return await Task.FromResult(0);
            bankAccount.IsValied = false;
            var result = _bankAccountRespository.Update(bankAccount);
            return await Task.FromResult(result);
        }
    }
}