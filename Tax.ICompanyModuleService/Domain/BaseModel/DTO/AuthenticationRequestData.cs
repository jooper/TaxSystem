using ProtoBuf;

namespace Tax.ICompanyModuleService.Domain.BaseModel.DTO
{
    [ProtoContract]
    public class AuthenticationRequestData
    {
        [ProtoMember(1)] public string UserName { get; set; }

        [ProtoMember(2)] public string Password { get; set; }
    }
}