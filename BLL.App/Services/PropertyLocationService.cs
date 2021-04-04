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
    public class PropertyLocationService: BaseEntityService<IAppUnitOfWork, IPropertyLocationRepository, BLLAppDTO.PropertyLocation, DALAppDTO.PropertyLocation>, IPropertyLocationService
    {
        public PropertyLocationService(IAppUnitOfWork serviceUow, IPropertyLocationRepository serviceRepository, IMapper mapper)
            : base(serviceUow, serviceRepository, new PropertyLocationMapper(mapper))
        {
        }
    }
}