using System;
using Applications.DAL.Base.Repositories;
using Applications.Domain.Base;

namespace Applications.BLL.Base.Services
{
    // public interface IBaseRepository<TEntity> : IBaseRepository<TEntity, Guid>
    //     where TEntity : class, IDomainEntityId
    // {
    //     
    // }
    public interface IBaseEntityService<TEntity> : IBaseEntityService<TEntity, Guid>
        where TEntity : class, IDomainEntityId
    {
        
    }
    
    public interface IBaseEntityService<TEntity, TKey> : IBaseService, IBaseRepository<TEntity, TKey>
        where TEntity: class, IDomainEntityId<TKey>
        where TKey: IEquatable<TKey>
    {

    }
}