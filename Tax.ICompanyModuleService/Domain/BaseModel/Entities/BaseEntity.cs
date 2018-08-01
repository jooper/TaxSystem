using System;

namespace Tax.ICompanyModuleService.Domain.BaseModel.Entities
{
    public class BaseEntity
    {
        public bool IsValied { set; get; }=true;
        public DateTime CreateTime { set; get; }=DateTime.Now;
        public DateTime UpdateTime { set; get; } = DateTime.Now;
        public string CreateUserId { get; set; }
        public string UpdateUserId { get; set; }
    }
}