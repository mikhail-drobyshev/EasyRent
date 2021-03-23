using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using Applications.DAL.Base.Repositories;
using Applications.Domain.Base;
using Microsoft.EntityFrameworkCore;

namespace DAL.Base.EF.Repositories
{
    public class BaseRepository<TEntity, TDbContext> : BaseRepository<TEntity, Guid, TDbContext>, IBaseRepository<TEntity>
        where TEntity : class, IDomainEntityId
        where TDbContext: DbContext
    {
        public BaseRepository(TDbContext dbContext) : base(dbContext)
        {
        }
    }

    public class BaseRepository<TEntity, TKey, TDbContext> : IBaseRepository<TEntity, TKey>
        where TEntity : class, IDomainEntityId<TKey> 
        where TKey : IEquatable<TKey>
        where TDbContext: DbContext
    {
        protected readonly TDbContext RepoDbContext;
        protected readonly DbSet<TEntity> RepoDbSet;

        public BaseRepository(TDbContext dbContext)
        {
            RepoDbContext = dbContext;
            RepoDbSet = dbContext.Set<TEntity>();
        }
        

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(TKey? userId = default, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);

            return await query.ToListAsync();
        }
        
        protected IQueryable<TEntity> CreateQuery(TKey? userId = default, bool noTracking = true)
        {
            var query = RepoDbSet.AsQueryable();

            if (userId != null && !userId.Equals(default) &&
                typeof(IDomainAppUserId<TKey>).IsAssignableFrom(typeof(TEntity)))
            {
                // ReSharper disable once SuspiciousTypeConversion.Global
                query = query.Where(e => ((IDomainAppUserId<TKey>) e).AppUserId.Equals(userId));
            }

            if (noTracking)
            {
                query = query.AsNoTracking();
            }

            return query;
        }
        
        public virtual async Task<TEntity?> FirstOrDefaultAsync(TKey id, TKey? userId = default, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);

            return await query.FirstOrDefaultAsync(e => e.Id.Equals(id));
        }
        public IEnumerable<TEntity> GetAll(bool noTracking = true)
        {
            return RepoDbSet.ToList();
        }

       

        public virtual TEntity Add(TEntity entity)
        {
            return RepoDbSet.Add(entity).Entity;
        }

        public virtual TEntity Update(TEntity entity)
        {
            return RepoDbSet.Update(entity).Entity;
        }

        public virtual TEntity Remove(TEntity entity, TKey? userId = default)
        {
            if (userId != null && !userId.Equals(default) &&
                typeof(IDomainAppUserId<TKey>).IsAssignableFrom(typeof(TEntity)) &&
                !((IDomainAppUserId<TKey>) entity).AppUserId.Equals(userId))
            {
                throw new AuthenticationException($"Bad user id inside entity {typeof(TEntity).Name} to be deleted.");
                // TODO: load entity from the db, check that userId inside entity is correct.
            }

            return RepoDbSet.Remove(entity).Entity;
        }

        public virtual async Task<TEntity> RemoveAsync(TKey id, TKey? userId = default)
        {
            var entity = await FirstOrDefaultAsync(id, userId);
            if (entity == null) throw new NullReferenceException($"Entity {typeof(TEntity).Name} with id {id} not found.");
            return Remove(entity!, userId);
        }

        public virtual async Task<bool> ExistsAsync(TKey id, TKey? userId = default)
        {
            if (userId == null || userId.Equals(default)) 
                // no ownership control, userId was null or default
                return await RepoDbSet.AnyAsync(e => e.Id.Equals(id));
            
            // we have userid and it is not null or default (null or 0) - so we should check for appuserid also
            // does the entity actually implement the correct interface
            if (!typeof(IDomainAppUserId<TKey>).IsAssignableFrom(typeof(TEntity)))
                throw new AuthenticationException(
                    $"Entity {typeof(TEntity).Name} does not implement required interface: {typeof(IDomainAppUserId<TKey>).Name} for AppUserId check");
            return await RepoDbSet.AnyAsync(e =>
                e.Id.Equals(id) && ((IDomainAppUserId<TKey>) e).AppUserId.Equals(userId));
        }
    }
}