using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DAL.Base.EF
{
    public class BaseUnitOfWork<TDbContext> : DAL.Base.BaseUnitOfWork
    where TDbContext: DbContext
    {
        protected readonly TDbContext UowDbContext;
        public BaseUnitOfWork(TDbContext uowDbContext)
        {
            UowDbContext = uowDbContext;
        }
        public override Task<int> SaveChangesAsync()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is DomainEntityId && (
                    e.State == EntityState.Added
                    || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((DomainEntityId)entityEntry.Entity).UpdatedAt = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((DomainEntityId)entityEntry.Entity).CreateAt = DateTime.Now;
                }
            }
            
            return UowDbContext.SaveChangesAsync();
        }
    }
}