using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tax.CompanyModuleService.DI;
using Tax.ICompanyModuleService.Domain.BaseModel;

namespace Tax.CompanyModuleService.UnitOfWork
{
    public class EfUnitOfWork : IEfUnitOfWork
    {
        //        public IEfDbContext
        //            EfDbContextContext = ServiceDiProvider.GetDiProivder().GetService<IEfDbContext>(); //new EfDbContext();
        //        public DbContext Context =>EfDbContextContext as EfDbContext;

        public DbContext Context { get; set; }
        public EfUnitOfWork(EfDbContext context)
        {
            Context = context;
        }

        public void RegisterNew<TEntiy>(TEntiy entity) where TEntiy : AggregateRoot
        {
            var state = Context.Entry(entity).State;
            if (state == EntityState.Detached)
            {
                Context.Entry(entity).CurrentValues.SetValues(entity);
//                Context.Entry(entity).Property(p => p.c).CurrentValue = "Michael";  //可以在底层默认调整此字段
                Context.Entry(entity).State = EntityState.Added;
            }

            IsCommitted = false;
        }

        public void RegisterModified<TEntiy>(TEntiy entity) where TEntiy : AggregateRoot
        {
            var state = Context.Entry(entity).State;
            if (state == EntityState.Detached) Context.Set<TEntiy>().Attach(entity);
            Context.Attach(entity);
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
            if (IsCommitted) return 0;

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
            if (!IsCommitted) Commit();

            Context.Dispose();
        }

        
    }
}