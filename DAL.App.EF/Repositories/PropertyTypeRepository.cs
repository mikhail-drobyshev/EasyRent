using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Applications.DAL.App.Repositories;
using Applications.DAL.Base.Repositories;
using DAL.Base.EF.Repositories;
using Domain.App;
using DTO.App;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class PropertyTypeRepository: BaseRepository<PropertyType, AppDbContext>, IPropertyTypeRepository
    {
        public PropertyTypeRepository (AppDbContext dbContext) : base(dbContext)
        {
        }
        
        // public override async Task<IEnumerable<PropertyType>> GetAllAsync(Guid userId = default, bool noTracking = true)
        // {
        //     var query = CreateQuery(userId, noTracking);
        //
        //     query = query
        //         .Include(p => p.Properties);
        //     var res = await query.ToListAsync();
        //     return res;
        // }

        public async Task<IEnumerable<PropertyTypeDTO>> GetAllWithPropertyTypeCountAsync(bool noTracking = true)
        {
            var query = CreateQuery(default, noTracking);
            var resultQuery = query.Select(propertyType => new PropertyTypeDTO()
            {
                Id = propertyType.Id,
                PropertyTypeValue = propertyType.PropertyTypeValue,
                PropertyCount = propertyType.Properties!.Count
            });
            var result = await resultQuery.ToListAsync();
            return result;
        }
    }
}