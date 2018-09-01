using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Tax.ICompanyModuleService.Domain.BaseModel;
using Tax.ICompanyModuleService.Domain.BaseModel.Entities;

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

        public DbContext Context { get; }

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
            //            var state = Context.Entry(entity).State;
            //            if (state == EntityState.Detached)
            //            {
            //                Context.Attach(entity);
            //
            //                //                Context.Entry(entity).CurrentValues.SetValues(entity);
            //                //                Context.Entry<TEntiy>(entity).CurrentValues.SetValues(entity);
            //                //先撤销跟踪
            //                Context.Entry(entity).State = EntityState.Detached; //把当前实体从上下文中detach掉，否则在Update方法中无法更新
            //
            //                entity.UpdateTime = DateTime.Now;
            //                Context.ChangeTracker.TrackGraph(entity, e => e.Entry.State = EntityState.Detached);
            //            }


            //            Context.ChangeTracker.AutoDetectChangesEnabled = true;
            //
            //            Context.ChangeTracker.TrackGraph(entity, node =>
            //            {
            //                var entry = node.Entry;
            //
            //                if ((int) entry.Property("CompanyId").CurrentValue < 0)
            //                {
            //                    entry.State = EntityState.Added;
            //                    entry.Property("CompanyId").IsTemporary = true;
            //                }
            //                else
            //                {
            //                    entry.State = EntityState.Modified;
            //                }
            //            });


            //            Context.Attach(entity);
            //            entity.UpdateTime = DateTime.Now;

            //            Context.Entry(entity).State = EntityState.Modified;


            //                                    Context.Update(entity);

            //            Context.Entry(entity).CurrentValues.SetValues(entity);

            //            Context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;


            //            var state = Context.Entry(entity).State;
            //            if (state == EntityState.Detached)
            //            {
            //                Context.Attach(entity);
            //            }
            //
            //            Context.Update(entity);
            //            Context.ChangeTracker.TrackGraph(entity, e => e.Entry.State = EntityState.Modified);

            //            DetachAllEntities();
            //            Context.Entry(entity).State = EntityState.Modified;


            //            var local = Context.Set<TEntiy>()
            //                .FirstOrDefault(entry => entry.Equals(entity));
            //            if (local != null)
            //            {
            //                Context.Entry(local).State = EntityState.Detached;
            //            }
            //
            //            Context.Entry(entity).State = EntityState.Modified;
            Context.DetachLocal(entity, x => x.Id == entity.Id);
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
                DisplayStates();
                var result = Context.SaveChanges();
                IsCommitted = true;
//                DetachAllEntities();
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


        private void DisplayStates()
        {
            var entries = Context.ChangeTracker.Entries();
            foreach (var entry in entries)
                Console.WriteLine($"Entity: {entry.Entity.GetType().Name},State: {entry.State.ToString()}");
        }

        public void DetachAllEntities()
        {
            var entries = Context.ChangeTracker.Entries();
            var entityEntries = entries.Where(e => e.State == EntityState.Added ||
//                                                   e.State == EntityState.Unchanged ||
                                                   e.State == EntityState.Modified ||
                                                   e.State == EntityState.Deleted);
            foreach (var entity in entityEntries) Context.Entry(entity.Entity).State = EntityState.Detached;
        }
    }

    public static class DbContextEx
    {
        public static void DetachLocal<T>(this DbContext context, T t, Expression<Func<T, bool>> express)
            where T : BaseEntity
        {
            var lamada = express.Compile();

            var local = context.Set<T>()
                .Local.Where(lamada)
                .FirstOrDefault();
            if (local != null) context.Entry(local).State = EntityState.Detached;

            context.Entry(t).State = EntityState.Modified;
        }

        public static void DetachLocal<T>(this DbContext context, T t, int entryId)
            where T : BaseEntity
        {
            var local = context.Set<T>()
                .Local
                .FirstOrDefault(entry => entry.Id.Equals(entryId));
            if (local != null) context.Entry(local).State = EntityState.Detached;

            context.Entry(t).State = EntityState.Modified;
        }
    }
}