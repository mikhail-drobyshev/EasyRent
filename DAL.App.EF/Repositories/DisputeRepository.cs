using System;
using System.Linq;
using System.Threading.Tasks;
using Applications.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain.App;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class DisputeRepository : BaseRepository<Dispute>, IDisputeRepository
    {
        public DisputeRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task DeleteAllByStatusCancelled(DisputeStatus status)
        {
            foreach (var dispute in await RepoDbSet.Where(x=>x.DisputeStatus == status).ToListAsync())
            {
                Remove(dispute);
            }
        }
    }
}