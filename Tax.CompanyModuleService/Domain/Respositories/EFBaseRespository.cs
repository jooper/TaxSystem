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
        private readonly IEfUnitOfWork _unitOfWork = ServiceDiProvider.GetDiProivder().GetService<IEfUnitOfWork>();

        public virtual IQueryable<TEntity> Entities => _unitOfWork.Context.Set<TEntity>();

        public virtual int Delete(object id)
        {
            var entity = _unitOfWork.Context.Set<TEntity>().Find(id);
            if (entity == null)
                return 0;

            _unitOfWork.RegisterDeleted(entity);
            return _unitOfWork.Commit();
        }

        public virtual int Delete(TEntity entity)
        {
            _unitOfWork.RegisterDeleted(entity);
            return _unitOfWork.Commit();
        }

        public virtual int Delete(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                _unitOfWork.RegisterDeleted(entity);
            }

            return _unitOfWork.Commit();
        }

        public virtual bool Exist(TEntity ent)
        {
            return _unitOfWork.Context.Set<TEntity>().Contains(ent);
        }

        public virtual bool Exist(object key)
        {
            var ent = GetByKey(key);
            return ent != null;
        }

        public virtual TEntity GetByKey(object key)
        {
            return _unitOfWork.Context.Set<TEntity>().Find(key);
        }

        public virtual int Insert(TEntity entity)
        {
            if (Exist(entity))
                return 0;
            _unitOfWork.RegisterNew(entity);
            return _unitOfWork.Commit();
        }

        public virtual int Isert(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                if (!Exist(entity))
                    _unitOfWork.RegisterNew(entity);
            }

            return _unitOfWork.Commit();
        }

        public virtual int Update(TEntity entity)
        {
            _unitOfWork.RegisterModified(entity);
            return _unitOfWork.Commit();
        }


        public virtual IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> express)
        {
            Func<TEntity, bool> lamada = express.Compile();
            return _unitOfWork.Context.Set<TEntity>().Where(lamada).AsQueryable<TEntity>();
        }


        public virtual int Delete(Expression<Func<TEntity, bool>> express)
        {
            Func<TEntity, bool> lamada = express.Compile();
            var lstEntity = _unitOfWork.Context.Set<TEntity>().Where(lamada);
            foreach (var entity in lstEntity)
            {
                _unitOfWork.RegisterDeleted(entity);
            }

            return _unitOfWork.Commit();
        }
    }
}