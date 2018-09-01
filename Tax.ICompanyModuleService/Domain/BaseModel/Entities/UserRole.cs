using System.ComponentModel.DataAnnotations;

namespace Tax.ICompanyModuleService.Domain.BaseModel.Entities
{
    public class UserRole:BaseEntity
    {
        [Key]
        public new int Id { set; get; }
        public int UserId { set; get; }
        public int RoleId { set; get; }
    }
}