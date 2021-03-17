using System.Collections.Generic;
using System.Threading.Tasks;
using Applications.DAL.App.Repositories;
using Applications.DAL.Base.Repositories;
using DAL.Base.EF.Repositories;
using Domain.App;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class ErUserRepository : BaseRepository<ErUser, AppDbContext>, IErUserRepository
    {

        public ErUserRepository(AppDbContext dbContext) : base(dbContext)
        {
            
        }
        public override async Task<IEnumerable<ErUser>> GetAllAsync(bool noTracking = true)
        {
            var query = RepoDbSet.AsQueryable();
            if (noTracking)
            {
                query = query.AsNoTracking();
            }

            query = query
                .Include(e => e.ErUserPicture)
                .Include(e => e.Gender);
            var res = await query.ToListAsync();
            // if (res.Count > 0)
            // {
            //     await RepoDbContext.Entry(res.First())
            //         .Reference(x=>)
            // }
            return res;
        }
    }
}