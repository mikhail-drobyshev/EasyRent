using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Applications.DAL.App.Repositories;
using Applications.DAL.Base.Repositories;
using AutoMapper;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

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
            return res!;
        }
        
        public async Task<IEnumerable<DAL.App.DTO.Property>> GetAllWithUserIdAsync(Guid userId = default, bool noTracking = true)
        {

            var query = CreateQuery(userId, noTracking);
            var resultQuery = query
                .Include(p=>p.PropertyPictures)
                .Select(e => new DAL.App.DTO.Property()
                {
                    Id = e.Id,
                    Title = e.Title,
                    Description = e.Description,
                    BedroomCount = e.BedroomCount,
                    TenantsCount = e.TenantsCount,
                    Price = e.Price,
                    ErUserId = e.ErUserId,
                    PropertyTypeId = e.PropertyTypeId,
                    CreateAt = e.CreateAt,
                    UpdatedAt = e.UpdatedAt
                });
            var res = await resultQuery.ToListAsync();
            

            return res;
        }
        public override async Task<DAL.App.DTO.Property?> FirstOrDefaultAsync(Guid id, Guid userId = default, bool noTracking = true)
        {
            // var query = CreateQuery(userId, noTracking);
            //
            //
            //
            //
            // var res = Mapper.Map(await query.FirstOrDefaultAsync(m => m.Id == id && m.ErUser!.AppUserId == userId));
            //
            // return res;
            var query = RepoDbSet.AsQueryable();

            if (noTracking)
            {
                query = query.AsNoTracking();
            }

            var res = Mapper.Map(await query.FirstOrDefaultAsync(m => m.Id == id));

            return res;
        }
    }
}