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
    public class PropertyLocationRepository : BaseRepository<DAL.App.DTO.PropertyLocation, Domain.App.PropertyLocation, AppDbContext>, IPropertyLocationRepository
    {

        public PropertyLocationRepository(AppDbContext dbContext, IMapper mapper
        ) : base(dbContext, new PropertyLocationMapper(mapper))
        {
            
        }
        public override async Task<IEnumerable<DAL.App.DTO.PropertyLocation>> GetAllAsync(Guid userId = default, bool noTracking = true)
        {
            //TODO all repos 
            var query = CreateQuery(userId, noTracking);

            var queryResult = query
                .Include(p => p.Property)
                .Select(x => Mapper.Map(x));
            var res = await queryResult.ToListAsync();
            // if (res.Count > 0)
            // {
            //     await RepoDbContext.Entry(res.First())
            //         .Reference(x=>)
            // }
            return res!;
        }
        public override async Task<DAL.App.DTO.PropertyLocation?> FirstOrDefaultAsync(Guid id, Guid userId = default, bool noTracking = true)
        {
            var query = RepoDbSet.AsQueryable();

            if (noTracking)
            {
                query = query.AsNoTracking();
            }

            query = query
                .Include(p => p.Property);

            var res = Mapper.Map(await query.FirstOrDefaultAsync(m => m.Id == id));

            return res;
        }
    }
}