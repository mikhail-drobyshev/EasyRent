using Applications.BLL.App.Services;
using Applications.DAL.App;
using Applications.DAL.App.Repositories;
using BLL.Base.Services;
using Domain.App;

namespace BLL.App.Services
{
    public class DisputeStatusService : BaseEntityService<IAppUnitOfWork, IDisputeStatusRepository, DisputeStatus>, IDisputeStatusService
    {
        public DisputeStatusService(IAppUnitOfWork serviceUow, IDisputeStatusRepository serviceRepository) : base(serviceUow, serviceRepository)
        {
        }
    }
}