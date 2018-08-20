﻿using System.Collections.Generic;
using ProtoBuf;
using Tax.ICompanyModuleService.Domain.BaseModel.Entities;

namespace Tax.ICompanyModuleService.Domain.BaseModel.DTO
{
    [ProtoContract]
    public class AuthorazationUser
    {
        [ProtoMember(1)] public int Id { set; get; }
        [ProtoMember(2)] public string Name { set; get; }
        [ProtoMember(3)] public string Phone { set; get; }
        [ProtoMember(4)] public string PwdMd5 { set; get; }
        [ProtoMember(5)] public string NickName { set; get; }
        [ProtoMember(6)] public string Account { set; get; }
    }
}