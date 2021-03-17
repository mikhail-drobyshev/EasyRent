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
    public interface IBaseRepository<TEntity, TKey> : IBaseRepositoryAsync<TEntity, TKey>
    where TEntity: class, IDomainEntityId<TKey>
    where TKey: IEquatable<TKey>
    {

    }
}