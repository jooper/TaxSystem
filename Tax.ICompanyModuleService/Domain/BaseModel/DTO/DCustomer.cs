using ProtoBuf;
using Tax.ICompanyModuleService.Domain.Entities.Enums;

namespace Tax.ICompanyModuleService.Domain.BaseModel.DTO
{
    [ProtoContract]
    public class DCustomer:BaseDto
    {
        [ProtoMember(1)]
        public int Id { set; get; }
        [ProtoMember(2)]
        public string Name { set; get; }
        [ProtoMember(3)]
        public string LinkPhone { set; get; }
        [ProtoMember(4)]
        public string SpecialTicketPercent { set; get; } //专票税率
        [ProtoMember(5)]
        public string CommonTicketPercent { set; get; } //普票税率
        [ProtoMember(6)]
        public CustomerLevel CustomerLevel { set; get; } //客户等级
        [ProtoMember(7)]
        public double TotalAmmout { set; get; } //合计开票金额
        [ProtoMember(8)]
        public string Remark { set; get; } //备注
    }
}