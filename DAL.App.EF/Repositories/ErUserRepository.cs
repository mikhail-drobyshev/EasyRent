using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Applications.DAL.App.Repositories;
using Applications.DAL.Base.Repositories;
using AutoMapper;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using DTO.App;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace DAL.App.EF.Repositories
{
    public class ErUserRepository : BaseRepository<DAL.App.DTO.ErUser, Domain.App.ErUser, AppDbContext>, IErUserRepository
    {

        public ErUserRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, new ErUserMapper(mapper))
        {
            
        }
        public override async Task<IEnumerable<DAL.App.DTO.ErUser>> GetAllAsync(Guid userId = default, bool noTracking = true)
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

            var res = await query.Select(x=>Mapper.Map(x)).ToListAsync();
            return res!;
        }
        public override async Task<DAL.App.DTO.ErUser?> FirstOrDefaultAsync(Guid id, Guid userId = default, bool noTracking = true)
        {
            var query = CreateQuery(default, noTracking);
            
            
            query = query
                .Include(e => e.Gender);

            var res = await query.FirstOrDefaultAsync(m => m.Id == id && m.AppUserId == userId);

            return Mapper.Map(res);
        }

        public async Task<IEnumerable<DAL.App.DTO.ErUser>> GetAllWithPropertyTypeCountAsync(Guid userId ,bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            var resultQuery = query
                .Select(e => new DAL.App.DTO.ErUser()
                {
                    Id = e.Id,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    PropertiesCount = e.Properties!.Count,
                    Gendervalue = e.Gender!.GenderValue,
                }).OrderBy(x => x.LastName).ThenBy(x => x.FirstName);
                
            return await resultQuery.ToListAsync();
        }
    }
}