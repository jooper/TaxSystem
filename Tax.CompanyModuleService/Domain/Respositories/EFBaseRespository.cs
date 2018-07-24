using System.Collections.Generic;
using System.Linq;
using Surging.Core.CPlatform.Ioc;
using Tax.CompanyModuleService.UnitOfWork;
using Tax.ICompanyModuleService.Domain.BaseModel;
using Tax.ICompanyModuleService.Domain.IRepositories;

namespace Tax.CompanyModuleService.Domain.Respositories
{
    public class EFBaseRespository<TEntity> : BaseRepository, IRepository<TEntity>
        where TEntity : AggregateRoot
    {
        public EFUnitOfWork UnitOfWork { set; get; }

        public EFBaseRespository(EFUnitOfWork work)
        {
            UnitOfWork = work;
        }


        public EFBaseRespository()
        {
        }

        public IQueryable<TEntity> Entities => UnitOfWork.Context.Set<TEntity>();

        public int Delete(object id)
        {
            var entity = UnitOfWork.Context.Set<TEntity>().Find(id);
            if (entity == null)
                return 0;

            UnitOfWork.RegisterDeleted(entity);
            return UnitOfWork.Commit();
        }

        public int Delete(TEntity entity)
        {
            UnitOfWork.RegisterDeleted(entity);
            return UnitOfWork.Commit();
        }

        public int Delete(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                UnitOfWork.RegisterDeleted(entity);
            }

            return UnitOfWork.Commit();
        }

        public TEntity GetByKey(object key)
        {
            return UnitOfWork.Context.Set<TEntity>().Find(key);
        }

        public int Insert(TEntity entity)
        {
            UnitOfWork.RegisterNew(entity);
            return UnitOfWork.Commit();
        }

        public int Isert(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                UnitOfWork.RegisterNew(entity);
            }

            return UnitOfWork.Commit();
        }

        public int Update(TEntity entity)
        {
            UnitOfWork.RegisterModified(entity);
            return UnitOfWork.Commit();
        }
    }
}