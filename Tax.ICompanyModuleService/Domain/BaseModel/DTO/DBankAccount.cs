using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ProtoBuf;
using Tax.ICompanyModuleService.Domain.BaseModel.Entities;
using Tax.ICompanyModuleService.Domain.Entities.Enums;

namespace Tax.ICompanyModuleService.Domain.BaseModel.DTO
{
    [ProtoContract]
    public class DBankAccount : BaseDto
    {
        [ProtoMember(1)] public int Id { set; get; }
        [ProtoMember(2)] public int CompanyId { set; get; }
        [ProtoMember(3)] public string CompanyName { set; get; }
        [ProtoMember(4)] public AccountType AccountType { set; get; } //账户状态
        [ProtoMember(5)] public string LinkMan { set; get; } //联系人
        [ProtoMember(6)] public string LinkManPhone { set; get; } 
        [ProtoMember(7)] public string AccountNumber { set; get; } //账户
        [ProtoMember(8)] public string OpenBankName { set; get; } //开户行
        [ProtoMember(9)] public string State { set; get; } //账户状态
        [ProtoMember(10)] public string SealExplation { set; get; } //印章说明
    }


    public class DBankAccountItem
    {
        public DBankAccountItem()
        {
            Accounts = new List<DBankAccount>();
        }

        public int CompanyId { set; get; }
        public List<DBankAccount> Accounts { set; get; }
    }
}