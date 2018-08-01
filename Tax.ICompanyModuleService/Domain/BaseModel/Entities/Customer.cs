using System.ComponentModel.DataAnnotations;
using Tax.ICompanyModuleService.Domain.Entities.Enums;

namespace Tax.ICompanyModuleService.Domain.BaseModel.Entities
{
    public class Customer : BaseEntity
    {
        [Key] public int Id { set; get; }

        public string Name { set; get; }
        public string LinkPhone { set; get; }
        public string SpecialTicketPercent { set; get; } //专票税率
        public string CommonTicketPercent { set; get; } //普票税率
        public CustomerLevel CustomerLevel { set; get; } //客户等级
        public double TotalAmmout { set; get; } //合计开票金额
        public string Remark { set; get; } //备注
 
    }
}