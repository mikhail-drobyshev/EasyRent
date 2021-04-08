using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Applications.BLL.App.Services;
using Applications.DAL.App;
using Applications.DAL.App.Repositories;
using AutoMapper;
using BLL.App.Mappers;
using BLL.Base.Services;
using BLLAppDTO = BLL.App.DTO;
using DALAppDTO = DAL.App.DTO;

namespace BLL.App.Services
{
    public class PropertyTypeService: BaseEntityService<IAppUnitOfWork, IPropertyTypeRepository, BLLAppDTO.PropertyType, DALAppDTO.PropertyType>, IPropertyTypeService
    {
        public PropertyTypeService(IAppUnitOfWork serviceUow, IPropertyTypeRepository serviceRepository, IMapper mapper)
            : base(serviceUow, serviceRepository, new PropertyTypeMapper(mapper))
        {
        }

        public async Task<IEnumerable<BLLAppDTO.PropertyType>> GetAllWithPropertyTypeCountAsync(bool noTracking)
        {
            return (await ServiceRepository.GetAllWithPropertyTypeCountAsync()).Select(x=>Mapper.Map(x))!;
        }
        
    }
}