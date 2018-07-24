using MessagePack;
using ProtoBuf;
using Surging.Core.System.Intercept;

namespace Tax.ICompanyModuleService.Domain.BaseModel.Models
{
    [ProtoContract]
    public class TbCompany : AggregateRoot
    {
        [ProtoMember(1)] [CacheKey(1)]
        public int Id { set; get; }
        [ProtoMember(2)] public string Name { set; get; }
        [ProtoMember(3)] public string Addr { set; get; }
    }
}