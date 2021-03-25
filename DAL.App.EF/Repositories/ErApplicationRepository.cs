using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Applications.DAL.App.Repositories;
using Applications.DAL.Base.Repositories;
using DAL.Base.EF.Repositories;
using Domain.App;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class ErApplicationRepository : BaseRepository<ErApplication, AppDbContext>, IErApplicationRepository
    {
        public ErApplicationRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        

        public override async Task<IEnumerable<ErApplication>> GetAllAsync(Guid userId = default, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);

            query = query
                .Include(e => e.ErApplicationStatus)
                .Include(e => e.ErUser)
                .Include(e => e.Property)
                .Where(c => c.ErUser!.AppUserId == userId);

            var res = await query.ToListAsync();
            // if (res.Count > 0)
            // {
            //     await RepoDbContext.Entry(res.First())
            //         .Reference(x=>)
            // }
            return res;
        }
        public override async Task<ErApplication?> FirstOrDefaultAsync(Guid id, Guid userId = default, bool noTracking = true)
        {
            var query = RepoDbSet.AsQueryable();

            if (noTracking)
            {
                query = query.AsNoTracking();
            }
            
            query = query
                .Include(e => e.ErApplicationStatus)
                .Include(e => e.ErUser)
                .Include(e => e.Property);

            var res = await query.FirstOrDefaultAsync(m => m.Id == id);

            return res;
        }



    }
}