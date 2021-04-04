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
    public class PropertyService: BaseEntityService<IAppUnitOfWork, IPropertyRepository, BLLAppDTO.Property, DALAppDTO.Property>, IPropertyService
    {
        public PropertyService(IAppUnitOfWork serviceUow, IPropertyRepository serviceRepository, IMapper mapper)
            : base(serviceUow, serviceRepository, new PropertyMapper(mapper))
        {
        }
    }
}