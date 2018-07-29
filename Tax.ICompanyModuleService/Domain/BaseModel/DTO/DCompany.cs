using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ProtoBuf;
using Surging.Core.System.Intercept;
using Tax.ICompanyModuleService.Domain.Entities;
using Tax.ICompanyModuleService.Domain.Entities.Enums;

namespace Tax.ICompanyModuleService.Domain.BaseModel.DTO
{
    [ProtoContract]
    public class DCompany
    {
        [ProtoMember(1)] [CacheKey(1)] public int Id { set; get; }

        [ProtoMember(1)]
        [Required]
        public string Name { set; get; }

        [ProtoMember(2)] public virtual BusinessState BusinessState { set; get; } //工商状态

        [ProtoMember(3)] public string TaxNumber { set; get; } //纳税别号

        [ProtoMember(4)] public DateTime RegisterTime { set; get; } //公司注册时间

        [ProtoMember(5)] public double RegisterCapital { set; get; } //注册资本

        [ProtoMember(6)] public string Addr { set; get; } //乡镇

        [ProtoMember(7)] public string LinkMan { set; get; } //联系人

        [ProtoMember(8)] public int LinkManPhone { set; get; }

        [ProtoMember(9)] public string LegalPerson { set; get; } //法人

        [ProtoMember(10)] public int LegalPersonPhone { set; get; }

        [ProtoMember(11)] public virtual List<Shareholder> Shareholders { set; get; }
    }
}