using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Applications.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain.App;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class DisputeRepository : BaseRepository<Dispute, AppDbContext>, IDisputeRepository
    {
        public DisputeRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task DeleteAllByStatusCancelled(DisputeStatus status)
        {
            
            foreach (var dispute in await RepoDbSet.Where(x=>x.DisputeStatus == status).ToListAsync())
            {
                Remove(dispute);
            }
        }

        public override async Task<IEnumerable<Dispute>> GetAllAsync(bool noTracking = true)
        {
            var query = RepoDbSet.AsQueryable();
            if (noTracking)
            {
                query = query.AsNoTracking();
            }

            query = query
                .Include(d => d.DisputeStatus)
                .Include(d => d.ErApplication);
            var res = await query.ToListAsync();
            // if (res.Count > 0)
            // {
            //     await RepoDbContext.Entry(res.First())
            //         .Reference(x=>)
            // }
            return res;
        }
        public override async Task<Dispute?> FirstOrDefaultAsync(Guid id, bool noTracking = true)
        {
            var query = RepoDbSet.AsQueryable();

            if (noTracking)
            {
                query = query.AsNoTracking();
            }
            
            query = query
                .Include(d => d.DisputeStatus)
                .Include(d => d.ErApplication);

            var res = await query.FirstOrDefaultAsync(m => m.Id == id);

            return res;
        }



    }
}