using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Applications.DAL.App.Repositories;
using Applications.DAL.Base.Repositories;
using AutoMapper;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class ErApplicationRepository: BaseRepository<DAL.App.DTO.ErApplication, Domain.App.ErApplication, AppDbContext>, IErApplicationRepository
    {
        public ErApplicationRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, new ErApplicationMapper(mapper))
        {
        }
        

        public override async Task<IEnumerable<DAL.App.DTO.ErApplication>> GetAllAsync(Guid userId = default, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);

            var resultQuery = query
                .Include(e => e.ErApplicationStatus)
                .Include(e => e.ErUser)
                .Include(e => e.Property)
                .Where(c => c.ErUser!.AppUserId == userId)
                .Select(x => Mapper.Map(x));;

            var res = await resultQuery.ToListAsync();
            // if (res.Count > 0)
            // {
            //     await RepoDbContext.Entry(res.First())
            //         .Reference(x=>)
            // }
            return res!;
        }
        public override async Task<DAL.App.DTO.ErApplication?> FirstOrDefaultAsync(Guid id, Guid userId = default, bool noTracking = true)
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

            var res = Mapper.Map(await query.FirstOrDefaultAsync(m => m.Id == id));

            return res;
        }



    }
}