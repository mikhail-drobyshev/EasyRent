using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Applications.DAL.Base.Repositories;
using Domain.App;
using DTO.App;

namespace Applications.DAL.App.Repositories
{
    public interface IPropertyTypeRepository: IBaseRepository<PropertyType>
    {
        Task<IEnumerable<PropertyTypeDTO>> GetAllWithPropertyTypeCountAsync(bool noTracking = true);

    }
}