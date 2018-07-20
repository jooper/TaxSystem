namespace Tax.ICompanyModuleService.Domain.BaseModel.Models
{
    public class TbCompany : AggregateRoot
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Addr { set; get; }
    }
}