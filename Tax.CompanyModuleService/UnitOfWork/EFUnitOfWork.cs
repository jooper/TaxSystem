using System;
using System.Data.Entity;
using Tax.ICompanyModuleService.Domain.BaseModel;
using Tax.ICompanyModuleService.Domain.BaseModel.Models;

namespace Tax.CompanyModuleService.UnitOfWork
{
    public class EFUnitOfWork : IEFUnitOfWork
    {
        public DbContext Context => new EFDbContext();


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


    class EFDbContext : DbContext
    {
        private static readonly string DefaultSqlConnectionString =
            @"Data Source=192.168.200.200.;Initial Catalog=TestSur;User ID=sa;Password=123456aA;";

        public EFDbContext() : base(DefaultSqlConnectionString)
        {
        }

        public DbSet<TbCompany> TB_COMPANY { set; get; }
        public DbSet<TbRole> TB_ROLE { set; get; }
        public DbSet<TbRight> TB_RIGHT { set; get; }
        public DbSet<TbUserrole> TB_USERROLE { set; get; }
        public DbSet<TbUser> TB_USER { set; get; }
    }
}