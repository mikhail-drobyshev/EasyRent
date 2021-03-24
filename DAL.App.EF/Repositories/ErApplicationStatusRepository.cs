using Applications.DAL.App.Repositories;
using Applications.DAL.Base.Repositories;
using DAL.Base.EF.Repositories;
using Domain.App;

namespace DAL.App.EF.Repositories
{
    public class ErApplicationStatusRepository: BaseRepository<ErApplicationStatus, AppDbContext>, IErApplicationStatusRepository
    {
        public ErApplicationStatusRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}