using Applications.BLL.App.Services;
using Applications.DAL.App;
using Applications.DAL.App.Repositories;
using BLL.Base.Services;
using Domain.App;

namespace BLL.App.Services
{
    public class PropertyLocationService: BaseEntityService<IAppUnitOfWork, IPropertyLocationRepository, PropertyLocation>, IPropertyLocationService
    {
        public PropertyLocationService(IAppUnitOfWork serviceUow, IPropertyLocationRepository serviceRepository) : base(serviceUow, serviceRepository)
        {
        }
    }
}