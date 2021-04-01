using System.Collections.Generic;
using System.Threading.Tasks;
using Applications.BLL.Base.Services;
using Applications.DAL.App.Repositories;
using Domain.App;
using DTO.App;

namespace Applications.BLL.App.Services
{
    public interface IPropertyTypeService: IBaseEntityService<PropertyType>, IPropertyTypeRepository
    {
        Task<IEnumerable<PropertyTypeDTO>> GetAllWithPropertyTypeCountAsync(bool noTracking = true);

    }
}