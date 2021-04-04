using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Applications.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Applications.DAL.App.Repositories
{
    public interface IPropertyTypeRepository: IBaseRepository<PropertyType>, IPropertyTypeRepositoryCustom<PropertyType>
    {

    }
    
    public interface IPropertyTypeRepositoryCustom<TEntity>
    {
        
        Task<IEnumerable<TEntity>> GetAllWithPropertyTypeCountAsync(bool noTracking = true);

        
    }
}