using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Tax.ICompanyModuleService.Domain.BaseModel.Enums;

namespace Tax.ICompanyModuleService.Domain.BaseModel.Entities
{
    //公司
    public sealed class Company : AggregateRoot
    {
        [Key] public int CompanyId { set; get; }
        [StringLength(50)]
        public string Name { set; get; }
        public BusinessState BusinessState { set; get; } //工商状态
        [StringLength(80)]
        public string TaxNumber { set; get; } //纳税别号
        public DateTime RegisterTime { set; get; } //公司注册时间
        public double RegisterCapital { set; get; } //注册资本
        [StringLength(100)]
        public string Addr { set; get; } //乡镇
        [StringLength(10)]
        public string LinkMan { set; get; } //联系人
        [StringLength(30)]
        public string LinkManPhone { set; get; }
        [StringLength(10)]
        public string LegalPerson { set; get; } //法人
        [StringLength(30)]
        public string LegalPersonPhone { set; get; }
        public ICollection<Shareholder> Shareholders { set; get; } = new List<Shareholder>();
    }
}