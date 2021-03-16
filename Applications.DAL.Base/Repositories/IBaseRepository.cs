using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Applications.Domain.Base;

namespace Applications.DAL.Base.Repositories
{
    public interface IBaseRepository<TEntity> : IBaseRepository<TEntity, Guid>
        where TEntity : class, IDomainEntityId
    {
        
    }
    public interface IBaseRepository<TEntity, TKey>
    where TEntity: class, IDomainEntityId<TKey>
    where TKey: IEquatable<TKey>
    {
        Task<IEnumerable<TEntity>> GetAllAsync(bool noTracking = true);
        Task<TEntity> FirstOrDefault(TKey id, bool noTracking = true);
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Remove(TEntity entity);
        Task<TEntity> Remove(TKey id);
        Task<bool> ExistAsync(TKey id);

    }
}