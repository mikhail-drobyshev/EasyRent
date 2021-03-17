using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Applications.Domain.Base;

namespace Applications.DAL.Base.Repositories
{
    
    public interface IBaseRepositoryAsync<TEntity, TKey> : IBaseRepositoryShared<TEntity, TKey>
        where TEntity: class, IDomainEntityId<TKey>
        where TKey: IEquatable<TKey>{
        
        Task<TEntity?> FirstOrDefaultAsync(TKey id, bool noTracking = true);
        Task<IEnumerable<TEntity>> GetAllAsync(bool noTracking = true); 
        Task<bool> ExistAsync(TKey id);
        Task<TEntity> RemoveAsync(TKey id);
    }
}