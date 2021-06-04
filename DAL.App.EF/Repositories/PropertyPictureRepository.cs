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
    public class PropertyPictureRepository : BaseRepository<DAL.App.DTO.PropertyPicture, Domain.App.PropertyPicture, AppDbContext>, IPropertyPictureRepository
    {

        public PropertyPictureRepository(AppDbContext dbContext, IMapper mapper
        ) : base(dbContext, new PropertyPictureMapper(mapper))
        {
            
        }
        public override async Task<IEnumerable<DAL.App.DTO.PropertyPicture>> GetAllAsync(Guid userId = default, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);

            query = query
                .Include(p => p.Property);

            var res = await query.Select(x=>Mapper.Map(x)).ToListAsync();
            return res!;
        }
        public async Task<IEnumerable<DAL.App.DTO.PropertyPicture>> GetAllWithPropertyIdAsync(Guid userId = default, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            var resultQuery = query
                .Select(e => new DAL.App.DTO.PropertyPicture()
                {
                    Id = e.Id,
                    PictureUrl = e.PictureUrl,
                    Title = e.Title,
                    PropertyId = e.PropertyId
                });
            var res = await resultQuery.ToListAsync();


            return res;
        }
        public override async Task<DAL.App.DTO.PropertyPicture?> FirstOrDefaultAsync(Guid id, Guid userId = default, bool noTracking = true)
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