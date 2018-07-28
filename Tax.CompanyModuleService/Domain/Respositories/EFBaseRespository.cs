using System.Collections.Generic;
using System.Linq;
using Surging.Core.CPlatform.Ioc;
using Tax.CompanyModuleService.UnitOfWork;
using Tax.ICompanyModuleService.Domain.BaseModel;
using Tax.ICompanyModuleService.Domain.IRepositories;

namespace Tax.CompanyModuleService.Domain.Respositories
{
    public class EfBaseRespository<TEntity> : BaseRepository, IRepository<TEntity>
        where TEntity : AggregateRoot
    {
        private readonly EfUnitOfWork _unitOfWork=new EfUnitOfWork();

        public IQueryable<TEntity> Entities => _unitOfWork.Context.Set<TEntity>();

        public int Delete(object id)
        {
            var entity = _unitOfWork.Context.Set<TEntity>().Find(id);
            if (entity == null)
                return 0;

            _unitOfWork.RegisterDeleted(entity);
            return _unitOfWork.Commit();
        }

        public int Delete(TEntity entity)
        {
            _unitOfWork.RegisterDeleted(entity);
            return _unitOfWork.Commit();
        }

        public int Delete(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                _unitOfWork.RegisterDeleted(entity);
            }

            return _unitOfWork.Commit();
        }

        public TEntity GetByKey(object key)
        {
            return _unitOfWork.Context.Set<TEntity>().Find(key);
        }

        public int Insert(TEntity entity)
        {
            _unitOfWork.RegisterNew(entity);
            return _unitOfWork.Commit();
        }

        public int Isert(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                _unitOfWork.RegisterNew(entity);
            }

            return _unitOfWork.Commit();
        }

        public int Update(TEntity entity)
        {
            _unitOfWork.RegisterModified(entity);
            return _unitOfWork.Commit();
        }
    }
}