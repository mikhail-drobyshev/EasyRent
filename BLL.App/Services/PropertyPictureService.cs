using Applications.BLL.App.Services;
using Applications.DAL.App;
using Applications.DAL.App.Repositories;
using BLL.Base.Services;
using Domain.App;

namespace BLL.App.Services
{
    public class PropertyPictureService: BaseEntityService<IAppUnitOfWork, IPropertyPictureRepository, PropertyPicture>, IPropertyPictureService
    {
        public PropertyPictureService(IAppUnitOfWork serviceUow, IPropertyPictureRepository serviceRepository) : base(serviceUow, serviceRepository)
        {
        }
    }
}