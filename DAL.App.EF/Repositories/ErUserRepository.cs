using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Applications.DAL.App.Repositories;
using Applications.DAL.Base.Repositories;
using DAL.Base.EF.Repositories;
using Domain.App;
using DTO.App;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace DAL.App.EF.Repositories
{
    public class ErUserRepository : BaseRepository<ErUser, AppDbContext>, IErUserRepository
    {

        public ErUserRepository(AppDbContext dbContext) : base(dbContext)
        {
            
        }
        public override async Task<IEnumerable<ErUser>> GetAllAsync(Guid userId = default, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);

            query = query
                .Include(e => e.Gender)
                .Include(e => e.Properties);
            if (userId != default)
            {
                query = query
                    .Where(c => c.AppUserId == userId);
            }

            var res = await query.ToListAsync();
            // if (res.Count > 0)
            // {
            //     await RepoDbContext.Entry(res.First())
            //         .Reference(x=>)
            // }
            return res;
        }
        public override async Task<ErUser?> FirstOrDefaultAsync(Guid id, Guid userId = default, bool noTracking = true)
        {
            var query = CreateQuery(default, noTracking);
            
            
            query = query
                .Include(e => e.Gender);

            var res = await query.FirstOrDefaultAsync(m => m.Id == id && m.AppUserId == userId);

            return res;
        }

        public async Task<IEnumerable<ErUserDTO>> GetAllWithPropertyTypeCountAsync(Guid userId ,bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            var resultQuery = query
                .Select(e => new ErUserDTO()
                {
                    Id = e.Id,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    PropertiesCount = e.Properties!.Count,
                    Gender = e.Gender!.GenderValue,
                }).OrderBy(x => x.LastName).ThenBy(x => x.FirstName);
                
            return await resultQuery.ToListAsync();
        }
    }
}