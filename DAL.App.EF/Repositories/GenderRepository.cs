using Applications.DAL.App.Repositories;
using Applications.DAL.Base.Repositories;
using DAL.Base.EF.Repositories;
using Domain.App;

namespace DAL.App.EF.Repositories
{
    public class GenderRepository: BaseRepository<Gender, AppDbContext>, IGenderRepository
    {
        public GenderRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}