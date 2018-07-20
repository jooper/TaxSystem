using System;
using Tax.ICompanyModuleService.Domain.BaseModel;

namespace Tax.ICompanyModuleService.Domain.IRepositories
{
    //仓储上下文工作单元接口，使用这个的一般情况是多个仓储之间存在事务性的操作，用于标记聚合根的增删改状态
    public interface IUnitOfWorkRespositoryContext : IUnitOfWork, IDisposable
    {
        /// <summary>
        /// 将聚合根的状态标记为新建，但EF上下文此时并未提交
        /// </summary>
        /// <typeparam name="TEntiy"></typeparam>
        /// <param name="entity"></param>
        void RegisterNew<TEntiy>(TEntiy entity) where TEntiy : AggregateRoot;



        /// <summary>
        /// 将聚合根的状态标记为修改，但EF上下文此时并未提交
        /// </summary>
        /// <typeparam name="TEntiy"></typeparam>
        /// <param name="entity"></param>
        void RegisterModified<TEntiy>(TEntiy entity) where TEntiy : AggregateRoot;



        /// <summary>
        /// 将聚合根的状态标记为删除，但EF上下文此时并未提交
        /// </summary>
        /// <typeparam name="TEntiy"></typeparam>
        /// <param name="entity"></param>
        void RegisterDeleted<TEntiy>(TEntiy entity) where TEntiy : AggregateRoot;
    }
}