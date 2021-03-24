using Applications.DAL.App.Repositories;
using Applications.DAL.Base.Repositories;
using DAL.Base.EF.Repositories;
using Domain.App;

namespace DAL.App.EF.Repositories
{
    public class DisputeStatusRepository: BaseRepository<DisputeStatus, AppDbContext>, IDisputeStatusRepository
    {
        public DisputeStatusRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}