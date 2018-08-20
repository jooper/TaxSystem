using System;
using System.ComponentModel.DataAnnotations;
using Tax.ICompanyModuleService.Domain.BaseModel.Enums;

namespace Tax.ICompanyModuleService.Domain.BaseModel.Entities
{
    public class TaxList:AggregateRoot
    {
        [Key] public int Id { set; get; }
        [MaxLength(50)] public int LinkManId { set; get; }
        [StringLength(50)] public string LinkMan { set; get; }
        [StringLength(50)] public string BuyParty { get; set; }
        [StringLength(3)] public TaxState State { set; get; }
        [StringLength(3)] public TaxType TaxType { set; get; }
        [StringLength(50)] public string SalesParty { get; set; }
        [MaxLength(20)] public DateTime OpenTaxDateTime { set; get; }
        [MaxLength(30)] public decimal Account { set; get; }
        [MaxLength(10)] public double TaxPercent { set; get; }
        [MaxLength(80)] public decimal TaxAccount { set; get; }
        [StringLength(100)] public string Remark { get; set; }
    }
}