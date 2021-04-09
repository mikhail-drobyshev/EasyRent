using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Applications.DAL.App.Repositories;
using AutoMapper;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Domain.App;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class PropertyRepository : BaseRepository<DAL.App.DTO.Property,Domain.App.Property, AppDbContext>, IPropertyRepository
    {

        public PropertyRepository(AppDbContext dbContext, IMapper mapper
        ) : base(dbContext, new PropertyMapper(mapper))
        {
            
        }
        public override async Task<IEnumerable<DAL.App.DTO.Property>> GetAllAsync(Guid userId = default, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
       

            var resultQuery = query
                .Include(d => d.ErUser)
                .Include(d => d.PropertyType)
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
        public override async Task<DAL.App.DTO.Property?> FirstOrDefaultAsync(Guid id, Guid userId = default, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);

            
            

            var res = Mapper.Map(await query.FirstOrDefaultAsync(m => m.Id == id && m.ErUser!.AppUserId == userId));

            return res;
        }
    }
}