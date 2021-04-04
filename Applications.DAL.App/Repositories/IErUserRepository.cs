using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Applications.DAL.Base.Repositories;
using DAL.App.DTO;


namespace Applications.DAL.App.Repositories
{
    public interface IErUserRepository : IBaseRepository<ErUser>, IErUserRepositoryCustom<ErUser>
    {

    }
    
    public interface IErUserRepositoryCustom<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllWithPropertyTypeCountAsync(Guid userId,bool noTracking = true);

    }
}