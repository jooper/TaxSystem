using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tax.ICompanyModuleService.Domain.Entities
{
    public class User:BaseEntity
    {
        [Key]
        public int Id { set; get; }
        public string Name { set; get; }
        public string Phone { set; get; }
        public string PwdMd5 { set; get; }
        public string NickName { set; get; }
        public virtual List<UserRole> Roles { set; get; }

    }
}