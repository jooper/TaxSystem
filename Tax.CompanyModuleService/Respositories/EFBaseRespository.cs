using System.Collections.Generic;
using System.Linq;
using Tax.ICompanyModuleService.Domain.BaseModel;
using Tax.ICompanyModuleService.Domain.IRepositories;

namespace Tax.CompanyModuleService.Respositories
{
    public class EFBaseRespository<TEntity> : IRepository<TEntity>
    where TEntity : AggregateRoot
    {
        public IQueryable<TEntity> Entities => throw new System.NotImplementedException();

        public int Delete(object id)
        {
            throw new System.NotImplementedException();
        }

        public int Delete(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public int Delete(IEnumerable<TEntity> entities)
        {
            throw new System.NotImplementedException();
        }

        public TEntity GetByKey(object key)
        {
            throw new System.NotImplementedException();
        }

        public int Insert(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public int Isert(IEnumerable<TEntity> entities)
        {
            throw new System.NotImplementedException();
        }

        public int Update(TEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}