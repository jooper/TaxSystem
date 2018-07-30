using System.ComponentModel.DataAnnotations;

namespace Tax.ICompanyModuleService.Domain.Entities
{
    public class UserRole:BaseEntity
    {
        [Key]
        public int Id { set; get; }
        public int UserId { set; get; }
        public int RoleId { set; get; }
    }
}