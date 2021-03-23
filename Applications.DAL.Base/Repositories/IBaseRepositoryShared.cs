using System;
using Applications.Domain.Base;

namespace Applications.DAL.Base.Repositories
{
    
    public interface IBaseRepositoryShared<TEntity, TKey>
        where TEntity: class, IDomainEntityId<TKey>
        where TKey: IEquatable<TKey>
    {
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Remove(TEntity entity, TKey? userId = default);
        
    }
}