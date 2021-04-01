using System.Collections.Generic;
using System.Threading.Tasks;
using Applications.BLL.App.Services;
using Applications.DAL.App;
using Applications.DAL.App.Repositories;
using BLL.Base.Services;
using Domain.App;
using DTO.App;

namespace BLL.App.Services
{
    public class PropertyTypeService: BaseEntityService<IAppUnitOfWork, IPropertyTypeRepository, PropertyType>, IPropertyTypeService
    {
        public PropertyTypeService(IAppUnitOfWork serviceUow, IPropertyTypeRepository serviceRepository) : base(serviceUow, serviceRepository)
        {
        }

        public async Task<IEnumerable<PropertyTypeDTO>> GetAllWithPropertyTypeCountAsync(bool noTracking)
        {
            return await ServiceRepository.GetAllWithPropertyTypeCountAsync();
        }
        
    }
}