using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Tax.ICompanyModuleService.Domain.BaseModel;

namespace Tax.ICompanyModuleService.Domain.IRepositories
{
    /// <summary>
    ///     仓储接口，定义公共的泛型GRUD
    /// </summary>
    /// <typeparam name="TEntity">
    ///     泛型聚合根，因为在DDD里面仓储只能对聚合根做操作
    /// </typeparam>
    public interface IRepository<TEntity> where TEntity : AggregateRoot
    {
        IQueryable<TEntity> Entities { get; }
        int Insert(TEntity entity);
        int Isert(IEnumerable<TEntity> entities);
        int Delete(object id);
        int Delete(TEntity entity);
        int Delete(IEnumerable<TEntity> entities);
        int Update(TEntity entity);
        int Update(IEnumerable<TEntity> entities);
        TEntity GetByKey(object key);
        bool Exist(object key);
        bool Exist(TEntity ent);
        



        /// <summary>
        /// 根据lamada表达式查询集合
        /// </summary>
        /// <param name="express">lamada表达式</param>
        /// <returns></returns>
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> express);

        /// <summary>
        ///     根据lamada表达式删除对象
        /// </summary>
        /// <param name="express"> lamada表达式 </param>
        /// <returns> 操作影响的行数 </returns>
        int Delete(Expression<Func<TEntity, bool>> express);
    }
}