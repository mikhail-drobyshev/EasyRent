using Applications.BLL.App.Services;
using Applications.DAL.App;
using Applications.DAL.App.Repositories;
using BLL.Base.Services;
using Domain.App;

namespace BLL.App.Services
{
    public class ErApplicationStatusService : BaseEntityService<IAppUnitOfWork, IErApplicationStatusRepository, ErApplicationStatus>, IErApplicationStatusService
    {
        public ErApplicationStatusService(IAppUnitOfWork serviceUow, IErApplicationStatusRepository serviceRepository) : base(serviceUow, serviceRepository)
        {
        }
    }
}