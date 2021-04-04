using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Applications.DAL.App.Repositories;
using AutoMapper;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Domain.App;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class ErUserReviewRepository : BaseRepository<DAL.App.DTO.ErUserReview, Domain.App.ErUserReview, AppDbContext>, IErUserReviewRepository
    {

        public ErUserReviewRepository(AppDbContext dbContext, IMapper mapper
        ) : base(dbContext, new ErUserReviewMapper(mapper))
        {
            
        }
        public override async Task<IEnumerable<DAL.App.DTO.ErUserReview>> GetAllAsync(Guid userId = default, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);

            var resultQuery = query
                .Include(e => e.ErUser)
                .Where(c => c.ErUser!.AppUserId == userId)
                .Select(x => Mapper.Map(x));

            var res = await resultQuery.ToListAsync();
            // if (res.Count > 0)
            // {
            //     await RepoDbContext.Entry(res.First())
            //         .Reference(x=>)
            // }
            return res!;
        }
        public override async Task<DAL.App.DTO.ErUserReview?> FirstOrDefaultAsync(Guid id, Guid userId = default, bool noTracking = true)
        {
            var query = RepoDbSet.AsQueryable();

            if (noTracking)
            {
                query = query.AsNoTracking();
            }
            
            query = query
                .Include(e => e.ErUser);

            var res = Mapper.Map(await query.FirstOrDefaultAsync(m => m.Id == id));

            return res;
        }
    }
}