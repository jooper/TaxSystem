﻿using Tax.ICompanyModuleService.Domain.BaseModel.Entities;
using Tax.ICompanyModuleService.Domain.Entities;

namespace Tax.ICompanyModuleService.Domain.BaseModel
{
    /// <summary>
    /// 聚合根的抽象实现类，定义聚合根的公共属性和行为
    /// </summary>
    public class AggregateRoot : BaseEntity, IAggregateRoot
    {
    }
}