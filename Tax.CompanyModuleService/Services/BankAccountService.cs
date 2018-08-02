using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Surging.Core.ProxyGenerator;
using Tax.CompanyModuleService.Domain.Respositories;
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

        public async Task<List<BankAccount>> GetCompanysAsync()
        {
            return await _bankAccountRespository.Entities.ToListAsync();
        }

    }
}