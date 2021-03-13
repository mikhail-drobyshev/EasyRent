using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Applications.DAL.Base.Repository;
using Applications.Domain.Base;

namespace DAL.Base.EF.Repositories
{
    public class BaseRepository<TEntity> : BaseRepository<TEntity, Guid>, IBaseRepository<TEntity>
        where TEntity : class, IDomainEntity
    {
        
    }

    public class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
        where TEntity : class, IDomainEntity<TKey> 
        where TKey : IEquatable<TKey>
    {
        public Task<IEnumerable<TEntity>> GetAllAsync(bool noTracking = true)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FirstOrDefault(TKey id, bool noTracking = true)
        {
            throw new NotImplementedException();
        }

        public TEntity Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity Remove(TKey id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistAsync(TKey id)
        {
            throw new NotImplementedException();
        }
    }
}