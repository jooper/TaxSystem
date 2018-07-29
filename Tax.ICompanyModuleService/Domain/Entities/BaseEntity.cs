using System;

namespace Tax.ICompanyModuleService.Domain.Entities
{
    public class BaseEntity
    {
        public bool IsValied { set; get; }
        public DateTime CreateTime { set; get; }
        public DateTime UpdateTime { set; get; }
        public string CreateUserId { get; set; }
        public string UpdateUserId { get; set; }
    }
}