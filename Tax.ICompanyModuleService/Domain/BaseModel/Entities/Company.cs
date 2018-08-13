using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Tax.ICompanyModuleService.Domain.Entities.Enums;

namespace Tax.ICompanyModuleService.Domain.BaseModel.Entities
{
    //公司
    public sealed class Company : AggregateRoot
    {
        [Key] public int CompanyId { set; get; }
        public string Name { set; get; }
        public BusinessState BusinessState { set; get; } //工商状态
        public string TaxNumber { set; get; } //纳税别号
        public DateTime RegisterTime { set; get; } //公司注册时间
        public double RegisterCapital { set; get; } //注册资本
        public string Addr { set; get; } //乡镇
        public string LinkMan { set; get; } //联系人
        [StringLength(30)]
        public string LinkManPhone { set; get; }
        public string LegalPerson { set; get; } //法人
        [StringLength(30)]
        public string LegalPersonPhone { set; get; }
        public ICollection<Shareholder> Shareholders { set; get; } = new List<Shareholder>();
    }
}