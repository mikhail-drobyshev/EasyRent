using System.Threading.Tasks;
using Applications.DAL.Base.Repository;
using Domain.App;

namespace Applications.DAL.App.Repositories
{
    public interface IDisputeRepository : IBaseRepository<Dispute>
    {
        Task DeleteAllByStatusCancelled(DisputeStatus status);
    }
}