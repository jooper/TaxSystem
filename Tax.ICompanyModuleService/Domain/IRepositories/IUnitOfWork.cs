namespace Tax.ICompanyModuleService.Domain.IRepositories
{
    //工作单元基类接口，具体数据库实现层
    public interface IUnitOfWork
    {
        //是否提交
        bool IsCommitted { set; get; }
        int Commit();
        void Rollback();
    }
}