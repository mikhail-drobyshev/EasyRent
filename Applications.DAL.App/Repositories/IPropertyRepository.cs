using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Applications.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Applications.DAL.App.Repositories
{
    public interface IPropertyRepository: IBaseRepository<Property>, IPropertyRepositoryCustom<Property>
    {
        
    }
    
    public interface IPropertyRepositoryCustom<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllWithUserIdAsync(Guid userId = default ,bool noTracking = true);
    }
}