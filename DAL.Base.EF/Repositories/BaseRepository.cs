using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using Applications.DAL.Base.Mappers;
using Applications.DAL.Base.Repositories;
using Applications.Domain.Base;
using Microsoft.EntityFrameworkCore;

namespace DAL.Base.EF.Repositories
{
    public class BaseRepository<TDalEntity, TDomainEntity, TDbContext> : BaseRepository<TDalEntity, TDomainEntity, Guid, TDbContext>,
        IBaseRepository<TDalEntity>
        where TDalEntity: class, IDomainEntityId
        where TDomainEntity: class, IDomainEntityId
        where TDbContext: DbContext
    {
        public BaseRepository(TDbContext dbContext, IBaseMapper<TDalEntity,TDomainEntity> mapper) : base(dbContext, mapper)
        {
        }
    }

    public class BaseRepository<TDalEntity, TDomainEntity, TKey, TDbContext> : IBaseRepository<TDalEntity, TKey>
        where TDalEntity: class, IDomainEntityId<TKey>
        where TDomainEntity: class, IDomainEntityId<TKey>
        where TKey : IEquatable<TKey>
        where TDbContext: DbContext
    {
        protected readonly TDbContext RepoDbContext;
        protected readonly DbSet<TDomainEntity> RepoDbSet;
        protected readonly IBaseMapper<TDalEntity, TDomainEntity> Mapper;

        public BaseRepository(TDbContext dbContext, IBaseMapper<TDalEntity,TDomainEntity> mapper)
        {
            RepoDbContext = dbContext;
            Mapper = mapper;
            RepoDbSet = dbContext.Set<TDomainEntity>();
        }
        

        public virtual async Task<IEnumerable<TDalEntity>> GetAllAsync(TKey? userId = default, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            var resultQuery = query.Select(domainEntity => Mapper.Map(domainEntity));
            var result = await resultQuery.ToListAsync();
            return result;
        }
        
        protected IQueryable<TDomainEntity> CreateQuery(TKey? userId = default, bool noTracking = true)
        {
            var query = RepoDbSet.AsQueryable();

            //TODO validate the input entity
            if (userId != null && !userId.Equals(default) && !userId.Equals(default) &&
                typeof(IDomainAppUserId<TKey>).IsAssignableFrom(typeof(TDomainEntity)))
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
        
        public virtual async Task<TDalEntity?> FirstOrDefaultAsync(TKey id, TKey? userId = default, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);

            return await query.Select(d=>Mapper.Map(d)).FirstOrDefaultAsync(e => e!.Id.Equals(id));
        }
        // public IEnumerable<TDalEntity> GetAll(bool noTracking = true)
        // {
        //     return RepoDbSet.ToList();
        // }

       

        public virtual TDalEntity Add(TDalEntity entity)
        {
            return Mapper.Map(RepoDbSet.Add(Mapper.Map(entity)!).Entity)!;
        }

        public virtual TDalEntity Update(TDalEntity entity)
        {
            return Mapper.Map(RepoDbSet.Update(Mapper.Map(entity)!).Entity)!;
        }

        public virtual TDalEntity Remove(TDalEntity entity, TKey? userId = default)
        {
            if (userId != null && !userId.Equals(default) &&
                typeof(IDomainAppUserId<TKey>).IsAssignableFrom(typeof(TDomainEntity)) &&
                !((IDomainAppUserId<TKey>) entity).AppUserId.Equals(userId))
            {
                throw new AuthenticationException($"Bad user id inside entity {typeof(TDalEntity).Name} to be deleted.");
                // TODO: load entity from the db, check that userId inside entity is correct.
            }

            return Mapper.Map(RepoDbSet.Remove(Mapper.Map(entity)!).Entity)!;
        }

        public virtual async Task<TDalEntity> RemoveAsync(TKey id, TKey? userId = default)
        {
            var entity = await FirstOrDefaultAsync(id, userId);
            if (entity == null) throw new NullReferenceException($"Entity {typeof(TDalEntity).Name} with id {id} not found.");
            return Remove(entity!, userId);
        }

        public virtual async Task<bool> ExistsAsync(TKey id, TKey? userId = default)
        {
            if (userId == null || userId.Equals(default)) 
                // no ownership control, userId was null or default
                return await RepoDbSet.AnyAsync(e => e.Id.Equals(id));
            
            // we have userid and it is not null or default (null or 0) - so we should check for appuserid also
            // does the entity actually implement the correct interface
            if (!typeof(IDomainAppUserId<TKey>).IsAssignableFrom(typeof(TDomainEntity)))
                throw new AuthenticationException(
                    $"Entity {typeof(TDomainEntity).Name} does not implement required interface: {typeof(IDomainAppUserId<TKey>).Name} for AppUserId check");
            return await RepoDbSet.AnyAsync(e =>
                e.Id.Equals(id) && ((IDomainAppUserId<TKey>) e).AppUserId.Equals(userId));
        }
    }
}