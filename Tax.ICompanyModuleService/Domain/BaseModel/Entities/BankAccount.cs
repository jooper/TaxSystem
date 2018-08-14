using System.ComponentModel.DataAnnotations;
using Tax.ICompanyModuleService.Domain.Entities.Enums;

namespace Tax.ICompanyModuleService.Domain.BaseModel.Entities
{
    /// <summary>
    /// 公司开户信息
    /// </summary>
    public class BankAccount:AggregateRoot
    {
        [Key] public int Id { set; get; }
        public int CompayId { set; get; }
        [StringLength(100)]
        public string CompanyName { set; get; }
        public AccountType AccountType { set; get; } //账户类型
        [StringLength(10)]
        public string LinkMan { set; get; } //联系人
        [StringLength(18)]
        public string LinkManPhone { set; get; } //联系人
        [StringLength(50)]
        public string AccountNumber { set; get; } //账户
        [StringLength(100)]
        public string OpenBankName { set; get; } //开户行
        [StringLength(10)]
        public string State { set; get; } //账户状态
        [StringLength(100)]
        public string SealExplation { set; get; } //印章说明
    }
}