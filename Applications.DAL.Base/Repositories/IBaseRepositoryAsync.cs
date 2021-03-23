using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Applications.Domain.Base;

namespace Applications.DAL.Base.Repositories
{
    
    public interface IBaseRepositoryAsync<TEntity, TKey> : IBaseRepositoryShared<TEntity, TKey>
        where TEntity: class, IDomainEntityId<TKey>
        where TKey: IEquatable<TKey>{
        
        Task<IEnumerable<TEntity>> GetAllAsync(TKey? userId = default, bool noTracking = true);
        Task<TEntity?> FirstOrDefaultAsync(TKey id, TKey? userId = default,  bool noTracking = true);
        Task<bool> ExistsAsync(TKey id, TKey? userId = default);
        Task<TEntity> RemoveAsync(TKey id, TKey? userId = default);
    }
}