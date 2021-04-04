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
    public class PropertyReviewRepository : BaseRepository<DAL.App.DTO.PropertyReview,Domain.App.PropertyReview, AppDbContext>, IPropertyReviewRepository
    {

        public PropertyReviewRepository(AppDbContext dbContext, IMapper mapper
        ) : base(dbContext, new PropertyReviewMapper(mapper))
        {
            
        }
        public override async Task<IEnumerable<DAL.App.DTO.PropertyReview>> GetAllAsync(Guid userId = default, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);

            var resultQuery = query
                .Include(p => p.ErUser)
                .Include(p => p.Property)
                .Select(x => Mapper.Map(x));
            var res = await resultQuery.ToListAsync();

            return res!;
        }
        public override async Task<DAL.App.DTO.PropertyReview?> FirstOrDefaultAsync(Guid id, Guid userId = default, bool noTracking = true)
        {
            var query = RepoDbSet.AsQueryable();

            if (noTracking)
            {
                query = query.AsNoTracking();
            }

            query = query
                .Include(p => p.ErUser)
                .Include(p => p.Property);

            var res = Mapper.Map(await query.FirstOrDefaultAsync(m => m.Id == id));

            return res;
        }
    }
}