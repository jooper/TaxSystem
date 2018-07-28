using System;
using System.Collections.Generic;
using System.Linq;
using Tax.ICompanyModuleService.Domain.BaseModel;

namespace Tax.ICompanyModuleService.Domain.IRepositories
{
    /// <summary>
    ///     仓储接口，定义公共的泛型GRUD
    /// </summary>
    /// <typeparam name="TEntiy">
    ///     泛型聚合根，因为在DDD里面仓储只能对聚合根做操作
    /// </typeparam>
    public interface IRepository<TEntiy> where TEntiy : AggregateRoot
    {
        IQueryable<TEntiy> Entities { get; }
        int Insert(TEntiy entity);
        int Isert(IEnumerable<TEntiy> entities);
        int Delete(object id);
        int Delete(TEntiy entity);
        int Delete(IEnumerable<TEntiy> entities);
        int Update(TEntiy entity);
        TEntiy GetByKey(object key);
        bool Exist(object key);
        bool Exist(TEntiy ent);
    }
}