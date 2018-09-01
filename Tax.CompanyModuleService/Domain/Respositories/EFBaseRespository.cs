using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.Extensions.DependencyInjection;
using Surging.Core.CPlatform.Ioc;
using Tax.CompanyModuleService.DI;
using Tax.CompanyModuleService.UnitOfWork;
using Tax.ICompanyModuleService.Domain.BaseModel;
using Tax.ICompanyModuleService.Domain.IRepositories;

namespace Tax.CompanyModuleService.Domain.Respositories
{
    public class EfBaseRespository<TEntity> : BaseRepository, IRepository<TEntity>
        where TEntity : AggregateRoot
    {
        public readonly IEfUnitOfWork UnitOfWork = ServiceDiProvider.GetDiProivder().GetService<IEfUnitOfWork>();

        public virtual IQueryable<TEntity> Entities => UnitOfWork.Context.Set<TEntity>();

        public virtual int Delete(object id)
        {
            var entity = UnitOfWork.Context.Set<TEntity>().Find(id);
            if (entity == null)
                return 0;

            UnitOfWork.RegisterDeleted(entity);
            return UnitOfWork.Commit();
        }

        public virtual int Delete(TEntity entity)
        {
            UnitOfWork.RegisterDeleted(entity);
            return UnitOfWork.Commit();
        }

        public virtual int Delete(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                UnitOfWork.RegisterDeleted(entity);
            }

            return UnitOfWork.Commit();
        }

        public virtual bool Exist(TEntity ent)
        {
            return UnitOfWork.Context.Set<TEntity>().Contains(ent);
        }

        public virtual bool Exist(object key)
        {
            var ent = GetByKey(key);
            return ent != null;
        }


        public virtual TEntity GetByKey(object key)
        {
            return UnitOfWork.Context.Set<TEntity>().Find(key);
        }

        public virtual int Insert(TEntity entity)
        {
            if (Exist(entity))
                return 0;
            UnitOfWork.RegisterNew(entity);
            return UnitOfWork.Commit();
        }

        public virtual int Isert(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                if (!Exist(entity))
                    UnitOfWork.RegisterNew(entity);
            }

            return UnitOfWork.Commit();
        }

        public virtual int Update(TEntity entity)
        {
            UnitOfWork.RegisterModified(entity);
            return UnitOfWork.Commit();
        }

        public int Update(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                UnitOfWork.RegisterModified(entity);
            }

            return UnitOfWork.Commit();
        }


        public virtual IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> express)
        {
            Func<TEntity, bool> lamada = express.Compile();
            return UnitOfWork.Context.Set<TEntity>().Where(lamada).AsQueryable<TEntity>();
        }


        public virtual int Delete(Expression<Func<TEntity, bool>> express)
        {
            Func<TEntity, bool> lamada = express.Compile();
            var lstEntity = UnitOfWork.Context.Set<TEntity>().Where(lamada);
            foreach (var entity in lstEntity)
            {
                UnitOfWork.RegisterDeleted(entity);
            }

            return UnitOfWork.Commit();
        }
    }
}