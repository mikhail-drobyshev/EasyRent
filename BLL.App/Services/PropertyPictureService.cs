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
    public class PropertyPictureService: BaseEntityService<IAppUnitOfWork, IPropertyPictureRepository, BLLAppDTO.PropertyPicture, DALAppDTO.PropertyPicture>, IPropertyPictureService
    {
        public PropertyPictureService(IAppUnitOfWork serviceUow, IPropertyPictureRepository serviceRepository, IMapper mapper)
            : base(serviceUow, serviceRepository, new PropertyPictureMapper(mapper))
        
        {
        }
    }
}