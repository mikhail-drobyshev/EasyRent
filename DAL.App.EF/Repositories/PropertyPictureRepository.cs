using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Applications.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain.App;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class PropertyPictureRepository : BaseRepository<PropertyPicture, AppDbContext>, IPropertyPictureRepository
    {

        public PropertyPictureRepository(AppDbContext dbContext) : base(dbContext)
        {
            
        }
        public override async Task<IEnumerable<PropertyPicture>> GetAllAsync(bool noTracking = true)
        {
            var query = RepoDbSet.AsQueryable();
            if (noTracking)
            {
                query = query.AsNoTracking();
            }

            query = query
                .Include(p => p.Property);
            var res = await query.ToListAsync();
            // if (res.Count > 0)
            // {
            //     await RepoDbContext.Entry(res.First())
            //         .Reference(x=>)
            // }
            return res;
        }
        public override async Task<PropertyPicture?> FirstOrDefaultAsync(Guid id, bool noTracking = true)
        {
            var query = RepoDbSet.AsQueryable();

            if (noTracking)
            {
                query = query.AsNoTracking();
            }

            query = query
                .Include(p => p.Property);

            var res = await query.FirstOrDefaultAsync(m => m.Id == id);

            return res;
        }
    }
}