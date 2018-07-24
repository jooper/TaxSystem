using Microsoft.EntityFrameworkCore;
using System;
using Surging.Core.CPlatform.Ioc;
//using System.Data.Entity;
using Tax.ICompanyModuleService.Domain.BaseModel;

namespace Tax.CompanyModuleService.UnitOfWork
{
    public class EfUnitOfWork: IEFUnitOfWork
    {
        public DbContext Context => new EfDbContext();

        public void RegisterNew<TEntiy>(TEntiy entity) where TEntiy : AggregateRoot
        {
            var state = Context.Entry(entity).State;
            if (state == EntityState.Detached)
            {
                Context.Entry(entity).State = EntityState.Added;
            }

            IsCommitted = false;
        }

        public void RegisterModified<TEntiy>(TEntiy entity) where TEntiy : AggregateRoot
        {
            var state = Context.Entry(entity).State;
            if (state == EntityState.Detached)
            {
                Context.Set<TEntiy>().Attach(entity);
            }

            Context.Entry(entity).State = EntityState.Modified;
            IsCommitted = false;
        }

        public void RegisterDeleted<TEntiy>(TEntiy entity) where TEntiy : AggregateRoot
        {
            Context.Entry(entity).State = EntityState.Deleted;
            IsCommitted = false;
        }

        //unitOfWork
        public bool IsCommitted { get; set; }

        public int Commit()
        {
            //已提交则返回，未提交执行提交
            if (IsCommitted)
            {
                return 0;
            }

            try
            {
                var result = Context.SaveChanges();
                IsCommitted = true;
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Rollback()
        {
            IsCommitted = false;
        }

        public void Dispose()
        {
            if (!IsCommitted)
            {
                Commit();
            }

            Context.Dispose();
        }
    }
}