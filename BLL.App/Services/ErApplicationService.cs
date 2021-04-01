using Applications.BLL.App.Services;
using Applications.DAL.App;
using Applications.DAL.App.Repositories;
using BLL.Base.Services;
using Domain.App;

namespace BLL.App.Services
{
    public class ErApplicationService: BaseEntityService<IAppUnitOfWork, IErApplicationRepository, ErApplication>, IErApplicationService
    {
        public ErApplicationService(IAppUnitOfWork serviceUow, IErApplicationRepository serviceRepository) : base(serviceUow, serviceRepository)
        {
        }
    }
}