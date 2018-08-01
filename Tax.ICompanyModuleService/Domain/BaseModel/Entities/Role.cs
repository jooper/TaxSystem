namespace Tax.ICompanyModuleService.Domain.BaseModel.Entities
{
    public class Role:AggregateRoot
    {
        public int Id { set; get; }
        public string Name { set; get; }
    }
}