using System;

namespace Tax.ICompanyModuleService.Domain.Entities
{
    public class RolePower:BaseEntity
    {
        public int Id { set; get; }
        public int RoleId { set; get; }
    }
}