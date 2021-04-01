using System.Threading.Tasks;
using Applications.BLL.App.Services;
using Applications.DAL.App;
using Applications.DAL.App.Repositories;
using BLL.Base.Services;
using Domain.App;

namespace BLL.App.Services
{
    public class DisputeService : BaseEntityService<IAppUnitOfWork, IDisputeRepository, Dispute>, IDisputeService
    {
        public DisputeService(IAppUnitOfWork serviceUow, IDisputeRepository serviceRepository) : base(serviceUow, serviceRepository)
        {
        }

        Task IDisputeRepository.DeleteAllByStatusCancelled(DisputeStatus status)
        {
            throw new System.NotImplementedException();
        }

        Task IDisputeService.DeleteAllByStatusCancelled(DisputeStatus status)
        {
            throw new System.NotImplementedException();
        }
    }
}