using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Tax.ICompanyModuleService.Domain.BaseModel;
using Tax.ICompanyModuleService.Domain.Entities.Enums;

namespace Tax.ICompanyModuleService.Domain.Entities
{
    //公司
    public class Company: AggregateRoot
    {
        [Key]
        public int Id { set; get; }
        public string Name { set; get; }
        public virtual BusinessState BusinessState { set; get; } //工商状态
        public string TaxNumber { set; get; } //纳税别号
        public DateTime RegisterTime { set; get; } //公司注册时间
        public double RegisterCapital { set; get; } //注册资本
        public string Addr { set; get; } //乡镇
        public string LinkMan { set; get; } //联系人
        public int LinkManPhone { set; get; }
        public string LegalPerson { set; get; } //法人
        public int LegalPersonPhone { set; get; }
        public virtual ICollection<Shareholder> Shareholders { set; get; }
    }

    
    

    
}