using Applications.BLL.App.Services;
using Applications.DAL.App;
using Applications.DAL.App.Repositories;
using BLL.Base.Services;
using Domain.App;

namespace BLL.App.Services
{
    public class PropertyService: BaseEntityService<IAppUnitOfWork, IPropertyRepository, Property>, IPropertyService
    {
        public PropertyService(IAppUnitOfWork serviceUow, IPropertyRepository serviceRepository) : base(serviceUow, serviceRepository)
        {
        }
    }
}