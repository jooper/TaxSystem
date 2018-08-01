using System.ComponentModel.DataAnnotations;
using Tax.ICompanyModuleService.Domain.Entities.Enums;

namespace Tax.ICompanyModuleService.Domain.BaseModel.Entities
{
    public class BankAccount:BaseEntity
    {
        [Key] public int Id { set; get; }
        public int CompayId { set; get; }
        public string CompanyName { set; get; }
        public AccountType AccountType { set; get; } //账户状态
        public string LinkMan { set; get; } //联系人
        public string AccountNumber { set; get; } //账户
        public string OpenBankName { set; get; } //开户行
        public string State { set; get; } //账户状态
        public string SealExplation { set; get; } //印章说明
    }
}