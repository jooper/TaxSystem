﻿using System;
using Microsoft.EntityFrameworkCore;
using Tax.ICompanyModuleService.Domain.BaseModel;

namespace Tax.CompanyModuleService.UnitOfWork
{
    public class EfUnitOfWork : IEfUnitOfWork
    {
        public EfUnitOfWork(EfDbContext context)
        {
            Context = context;
        }
        //        public IEfDbContext
        //            EfDbContextContext = ServiceDiProvider.GetDiProivder().GetService<IEfDbContext>(); //new EfDbContext();
        //        public DbContext Context =>EfDbContextContext as EfDbContext;

        public DbContext Context { get; set; }

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
            if (state == EntityState.Detached)
            {
                //                Context.Entry(entity).CurrentValues.SetValues(entity);
                //                Context.Entry<TEntiy>(entity).CurrentValues.SetValues(entity);
                //先撤销跟踪
                Context.Entry(entity).State = EntityState.Detached; //把当前实体从上下文中detach掉，否则在Update方法中无法更新
//                Context.Set<TEntiy>().Attach(entity);
                entity.UpdateTime = DateTime.Now;
                Context.ChangeTracker.TrackGraph(entity, e => e.Entry.State = EntityState.Detached);
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