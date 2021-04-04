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
    public interface IBaseEntityService<TBllEntity, TDalEntity> : IBaseEntityService<TBllEntity, TDalEntity, Guid>
        where TBllEntity : class, IDomainEntityId
        where TDalEntity : class, IDomainEntityId
    {
        
    }
    
    public interface IBaseEntityService<TBllEntity, TDalEntity, TKey> : IBaseService, IBaseRepository<TBllEntity, TKey>
        where TBllEntity: class, IDomainEntityId<TKey>
        where TDalEntity: class, IDomainEntityId<TKey>
        where TKey: IEquatable<TKey>
    {

    }
}