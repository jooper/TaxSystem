using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Surging.Core.ProxyGenerator;
using Tax.CompanyModuleService.Domain.Respositories;
using Tax.CompanyModuleService.Ext;
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

        public async Task<List<BankAccount>> GetBandAccountsAsync(int offSet, int take)
        {
            var bankEntities = _bankAccountRespository.Entities.OrderByDescending(o => o.UpdateTime)
                .Where(w => w.IsValied)
                .GroupBy(g => g.CompayId).Select(x => new
                {
                    CompanyId = x.Key,
                    Account = x.Select(w => new BankAccount
                    {
                        CompayId = w.CompayId,
                        OpenBankName = w.OpenBankName,
                        CompanyName = w.CompanyName,
                        AccountType = w.AccountType,
                        AccountNumber = w.AccountNumber,
                        LinkMan = w.LinkMan,
                        LinkManPhone = w.LinkManPhone,
                        State = w.State,
                        SealExplation = w.SealExplation
                    })
                });

            var ddd = await bankEntities.Skip(offSet).Take(take).ToListAsync();


            var companies = await _bankAccountRespository.Entities.Where(w => w.IsValied)
                .OrderByDescending(o => o.UpdateTime).Skip(offSet).Take(take)
                .ToListAsync();
            return companies;
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