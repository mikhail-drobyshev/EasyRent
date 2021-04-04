using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Applications.DAL.App.Repositories;
using AutoMapper;
using DAL.App.DTO;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace DAL.App.EF.Repositories
{
    public class DisputeRepository : BaseRepository<DAL.App.DTO.Dispute, Domain.App.Dispute, AppDbContext>, IDisputeRepository
    {
        public DisputeRepository(AppDbContext dbContext, IMapper mapper
        ) : base(dbContext, new DisputeMapper(mapper))
        {
        }

        // public async Task DeleteAllByStatusCancelled(DisputeStatus statuss)
        // {
        //     var status = Mapper.Map(statuss);
        //
        //     foreach (var dispute in await RepoDbSet.Where(x=>x.DisputeStatus == status).ToListAsync())
        //     {
        //         Remove(Mapper.Map(dispute)!);
        //     }
        // }

        public override async Task<IEnumerable<DAL.App.DTO.Dispute>> GetAllAsync(Guid userId = default, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);

            var resultQuery = query
                .Include(d => d.DisputeStatus)
                .Include(d => d.ErApplication)
                .Where(c => c.AppUserId == userId)
                .Select(x => Mapper.Map(x));
            var res = await resultQuery.ToListAsync();
            // if (res.Count > 0)
            // {
            //     await RepoDbContext.Entry(res.First())
            //         .Reference(x=>)
            // }
            return res!;
        }
        public override async Task<Dispute?> FirstOrDefaultAsync(Guid id, Guid userId = default, bool noTracking = true)
        {
            var query = RepoDbSet.AsQueryable();

            if (noTracking)
            {
                query = query.AsNoTracking();
            }
            
            query = query
                .Include(d => d.DisputeStatus)
                .Include(d => d.ErApplication);

            var res = Mapper.Map(await query.FirstOrDefaultAsync(m => m.Id == id));

            return res;
        }
    }
}