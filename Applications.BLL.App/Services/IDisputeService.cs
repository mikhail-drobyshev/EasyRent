using System.Threading.Tasks;
using Applications.BLL.Base.Services;
using Applications.DAL.App.Repositories;
using Domain.App;

namespace Applications.BLL.App.Services
{
    public interface IDisputeService : IBaseEntityService<Dispute>, IDisputeRepository
    {
        Task DeleteAllByStatusCancelled(DisputeStatus status);
    }
}