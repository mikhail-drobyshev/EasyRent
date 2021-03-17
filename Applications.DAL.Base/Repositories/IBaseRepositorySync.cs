using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Applications.Domain.Base;

namespace Applications.DAL.Base.Repositories
{
    
    public interface IBaseRepositorySync<TEntity, TKey> : IBaseRepositoryShared<TEntity, TKey>
        where TEntity: class, IDomainEntityId<TKey>
        where TKey: IEquatable<TKey>
    {
        
        IEnumerable<TEntity> GetAll(bool noTracking = true);
        TEntity FirstOrDefault(TKey id, bool noTracking = true);
        TEntity Remove(TKey id);
        bool Exist(TKey id);
    }
}